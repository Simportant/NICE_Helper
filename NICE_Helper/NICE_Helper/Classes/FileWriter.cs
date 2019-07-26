using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.IO.Compression;

namespace NICE_Helper
{
    class FileWriter : IDisposable
    {

        StreamWriter _file;
        public FileWriter()
        {
        }
        public FileWriter(string fileName)
        {
            _file = new StreamWriter(fileName, false);
        }
        public void WriteLine(string ln)
        {
            if (_file != null)
            {
                _file.WriteLine(ln);
            }
        }

        public void Compress(DirectoryInfo SourceFolder, string TargetFolder, bool InludeConfigs)
        {
            try {
                string newCompressedFile;

                foreach (var fileToCompress in SourceFolder.GetFiles().Where(s => s.Name.ToLower().Contains(".log")))
                {
                    using (FileStream originalFileStream = fileToCompress.OpenRead())
                    {
                        if ((File.GetAttributes(fileToCompress.FullName)
                                    & FileAttributes.Hidden) != FileAttributes.Hidden
                                    & fileToCompress.Extension != ".gz")
                        {

                            newCompressedFile = string.Concat(TargetFolder, "\\", fileToCompress.Name, ".gz");

                            // Avoid CA2202: Do not dispose objects multiple times.
                            // Don't use "using()" as there is already a FileStream object in this scope which will get Disposed();
                            FileStream compressedFileStream = new FileStream(newCompressedFile, FileMode.Create);

                            using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                            
                        }
                    }
                }

                if (InludeConfigs)
                    foreach (var fileToCompress in SourceFolder.GetFiles().Where(s => s.Name.ToLower().Contains(".exe.config")))
                    {
                        using (FileStream originalFileStream = fileToCompress.OpenRead())
                        {
                            if ((File.GetAttributes(fileToCompress.FullName)
                                        & FileAttributes.Hidden) != FileAttributes.Hidden
                                        & fileToCompress.Extension != ".gz")
                            {
                                newCompressedFile = string.Concat(TargetFolder, "\\", fileToCompress.Name, ".gz");

                                // Avoid CA2202: Do not dispose objects multiple times.
                                // Don't use "using()" as there is already a FileStream object in this scope which will get Disposed();
                                FileStream compressedFileStream = new FileStream(newCompressedFile, FileMode.Create);

                                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                                {
                                    originalFileStream.CopyTo(compressionStream);
                                }                                
                            }
                        }
                    }
            }
            catch (Exception) { throw; }
        }

        public int Uncompress(DirectoryInfo SourceFolder)
        {
            try {
                // Unzip using 7-zip
                // Windows version:
                //string zPath = @"C:\Program Files\7-Zip\7zG.exe";
                // CMD version:
                string zPath = @"C:\Program Files\7-Zip\7z.exe";

                string UnzippedFolder = string.Concat(SourceFolder.FullName, @"Unzipped\");
                string ZippedFolder = string.Concat(SourceFolder.FullName, @"Zipped\");

                if (!File.Exists(zPath))
                    return 0;

                string newPathFileName = string.Empty;
                string PathFileLessExtension = string.Empty;
                int ProjectCount = 0;

                Helper.MakeFolder(UnzippedFolder);
                Helper.MakeFolder(ZippedFolder);

                foreach (FileInfo zippedFile in SourceFolder.GetFiles().Where(s => s.Name.ToLower().Contains(".zproj")))
                {
                    PathFileLessExtension = string.Concat(UnzippedFolder, zippedFile.Name.Replace(".zproj", ""));
                    newPathFileName = string.Concat(UnzippedFolder, zippedFile.Name.Replace(".zproj", ".dproj"));

                    Unzip(UnzippedFolder, zPath, newPathFileName, PathFileLessExtension, zippedFile);

                    if (File.Exists(string.Concat(ZippedFolder, zippedFile.Name)))
                        File.Delete(string.Concat(ZippedFolder, zippedFile.Name));

                    File.Move(zippedFile.FullName, string.Concat(ZippedFolder, zippedFile.Name));

                    ProjectCount += 1;
                }

                foreach (FileInfo zippedFile in SourceFolder.GetFiles().Where(s => s.Name.ToLower().Contains(".zesx")))
                {
                    PathFileLessExtension = string.Concat(UnzippedFolder, zippedFile.Name.Replace(".zesx", ""));
                    newPathFileName = string.Concat(UnzippedFolder, zippedFile.Name.Replace(".zesx", ".resx"));

                    Unzip(UnzippedFolder, zPath, newPathFileName, PathFileLessExtension, zippedFile);

                    if (File.Exists(string.Concat(ZippedFolder, zippedFile.Name)))
                        File.Delete(string.Concat(ZippedFolder, zippedFile.Name));

                    File.Move(zippedFile.FullName, string.Concat(ZippedFolder, zippedFile.Name));
                }

                return ProjectCount;

            }
            catch (Exception)  { throw; }
        }

        private void Unzip(string DestinationFolder, string zPath, string newName, string originalName, FileInfo zippedFile)
        {

            ProcessStartInfo pro = new ProcessStartInfo
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,

                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = zPath,
                Arguments = "x \"" + zippedFile.FullName + "\" -o\"" + DestinationFolder + "\""
            };

            Process x = new Process();
            x.StartInfo = pro;
            x.Start();
            x.WaitForExit();
            x.Dispose();
            
            if (File.Exists(newName))
                BackupOldFile(newName);

            File.Move(originalName, newName);
        }

        private void BackupOldFile(string FileName)
        {
            int cnt = 1;
            string bakName = string.Concat(FileName, "_", cnt.ToString());

            while (File.Exists(bakName))
            {
                cnt += 1;
                bakName = string.Concat(FileName, "_", cnt.ToString());

                if (cnt > 99)
                    throw new System.ArgumentException("Too many backups in ", FileName);
            }
            File.Move(FileName, bakName);
        }



        #region Deconstructor Stuff

        private bool _disposed;

        ~FileWriter()
        {
            this.Dispose(false);
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }

                // Dispose unmanaged resources here.
                if (_file != null)
                {
                    _file.Close();
                    _file = null;
                }
            }

            _disposed = true;
        }
        #endregion


    }
}

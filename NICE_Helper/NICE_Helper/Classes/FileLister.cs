using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Log_Viewer
{
    class FileLister
    {
        readonly string _FileDefinition;
        readonly string _StartPath;
        readonly Boolean _DoSubFolders;

        public FileLister(string def, string startpath, Boolean DoSubFolders )
        {
            Stack<string> stack = new Stack<string>();
            CurrentFiles = new BindingList<FileDetail>();

            _FileDefinition = def;
            _StartPath = startpath;
            _DoSubFolders = DoSubFolders;
            stack.Push(_StartPath);
            GetFiles(stack);
        }

        public int count { get { return CurrentFiles.Count; } }
        public BindingList<FileDetail> CurrentFiles { get; }

        private void GetFiles(Stack<string> stack)
        {
            // Recursivly Get files that meet the criteria.
            string path;
            FileInfo oFileInfo;
            DateTime dtCreationTime;

            while (stack.Count > 0)
            {
                path = stack.Pop();

                // Don't really want to do this folder - it's full of c&*p......
                if (!path.StartsWith("C:\\Temp", StringComparison.CurrentCultureIgnoreCase) )
                {
                    try
                    {
                        // Only do sub folders if necessary.
                        if (_DoSubFolders)
                        {
                            String[] subDirectories;
                            subDirectories = System.IO.Directory.GetDirectories(path);
                            foreach (string p in subDirectories)
                            {
                                stack.Push(p);
                            }
                        }

                        String[] subFiles;
                        subFiles = System.IO.Directory.GetFiles(path, _FileDefinition);

                        // Grab file Details
                        foreach (string f in subFiles)
                        {
                            oFileInfo = new FileInfo(f);
                            dtCreationTime = oFileInfo.CreationTime;
                            CurrentFiles.Add(new FileDetail(oFileInfo.Name,
                                                        dtCreationTime.ToString(),
                                                        path,
                                                        oFileInfo.Length));
                        }
                    }

                    catch (System.UnauthorizedAccessException) { CurrentFiles.Add(new FileDetail("No Access", DateTime.Now.ToString(), path, 0));}
                    catch (Exception) { CurrentFiles.Add(new FileDetail("Exception", DateTime.Now.ToString(), path, 0)); }                        
                }

                // Recurse for all folders left on the Stack.
                GetFiles(stack);

            }  // End While.

            return;
        }






    }


}

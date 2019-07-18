using System;
namespace NICE_Helper
{
    public static class Extension
    {
              

        public static string NullToString(this object value)
        {
            return (value ?? string.Empty).ToString();
        }
        public static int NullToInt(this object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(value);
        }
        public static double NullToDouble(this object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            else
                return Convert.ToDouble(value);
        }
        public static bool IsDate(this object Expression)
        {
            if (Expression != null && Expression != DBNull.Value)
            {
                if (Expression is DateTime)
                    return true;
                if (Expression is string)
                    return DateTime.TryParse((string)Expression, out DateTime time1);
            }
            return false;
        }
        public static bool IsNumeric(this object anyString)
        {   
            if (anyString == null || anyString == DBNull.Value)
                return false;

            string val = anyString.ToString();            

            if (val.Length > 0)
            {               
                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", true);
                return Double.TryParse(val, System.Globalization.NumberStyles.Any, cultureInfo.NumberFormat, out double dummyOut);                
            }
            else
                return false;
        }

        public static void StretchLastColumn(this System.Windows.Forms.DataGridView dataGridView)
        {
            var lastColIndex = dataGridView.Columns.Count - 1;
            var lastCol = dataGridView.Columns[lastColIndex];
            lastCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        }
        public static void StretchThisColumn(this System.Windows.Forms.DataGridView dataGridView, int idx)
        {   
            var lastCol = dataGridView.Columns[idx];
            lastCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}

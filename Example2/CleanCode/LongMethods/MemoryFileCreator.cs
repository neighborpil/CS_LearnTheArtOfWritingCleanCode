using System;
using System.Data;
using System.IO;

namespace FooFoo
{
    public class MemoryFileCreator
    {
        public System.IO.MemoryStream CreateMemoryFile(DataTable dataTable)
        {
            var returnStream = new MemoryStream();

            StreamWriter sw = new StreamWriter(returnStream);
            WriteColumn(dataTable, sw);
            WriteRows(dataTable, sw);
            sw.Flush();
            sw.Close();

            return returnStream;
        }

        private static void WriteRows(DataTable dt, StreamWriter sw)
        {
            foreach (DataRow dr in dt.Rows)
            {
                WriteRow(dt, dr, sw);

                sw.WriteLine();
            }
        }

        private static void WriteRow(DataTable dt, DataRow dr, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                WriteCell(dr, i, sw);
                WriteSeparatorIfRequired(dt, sw, i);
            }
        }

        private static void WriteSeparatorIfRequired(DataTable dt, StreamWriter sw, int i)
        {
            if (i < dt.Columns.Count - 1)
                sw.Write(",");
        }

        private static void WriteCell(DataRow dr, int i, StreamWriter sw)
        {
            if (!Convert.IsDBNull(dr[i]))
            {
                string str = $"\"{dr[i].ToString():c}\"".Replace("\r\n", " ");
                sw.Write(str);
            }
            else
            {
                sw.Write("");
            }
        }

        private static void WriteColumn(DataTable dt, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }

            sw.WriteLine();
        }
    }
}
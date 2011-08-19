using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utility
{
    public class FileOperation
    {
        public static bool WriteToFile(string strPath, ref byte[] buffer)
        {
            bool flag = true;
            try
            {
                // Create a file
                FileStream newFile = new FileStream(strPath, FileMode.Create);

                // Write data to the file

                newFile.Write(buffer, 0, buffer.Length);

                // Close file

                newFile.Close();
            }
            catch (Exception)
            {
                flag = false;
                throw;
            }
            return flag;
        }
    }
}

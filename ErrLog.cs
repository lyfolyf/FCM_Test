using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace FCM_Test
{
    static class ErrLog
    {
        public static void WriteLogData(string errMsg)
        {
            try
            {
                string log_Path = string.Format("{0}{1}.log", Application.StartupPath + "\\Logs\\", DateTime.Now.ToString("yyyy-MM-dd"));
                using (StreamWriter streamWriter = new StreamWriter(log_Path, true, Encoding.Default))
                {
                    streamWriter.WriteLine(string.Format("{0}->{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), errMsg));
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        public static void WriteLogEx(string errMsg)
        {
            try
            {
                string log_Path = string.Format("{0}{1}.log", Application.StartupPath + "\\Logs\\", DateTime.Now.ToString("yyyy-MM-dd"));
                using (StreamWriter streamWriter = new StreamWriter(log_Path, true, Encoding.Default))
                {
                    streamWriter.WriteLine(string.Format("{0}->{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), errMsg));
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

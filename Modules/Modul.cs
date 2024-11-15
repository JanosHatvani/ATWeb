using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Modules
{
      
    public class WaitTime
    {
                        
        public static void Wait(int minute)
        {
            Thread.Sleep(minute*1000);
        }
                   
    }
    public class LogWriterT
    { 

        public static void LogDirFileCreate(string Folderpath, string testname)
        {
            try
            {              
                string logfilename = Folderpath + testname + ".txt";
                DirectoryInfo logDirInfo = new DirectoryInfo(Folderpath);

                if (!logDirInfo.Exists && (!File.Exists(logfilename))) 
                {
                    Directory.CreateDirectory(Folderpath);                    
                    File.Create(logfilename);                    
                }
                else
                {
                    FileInfo[] files = logDirInfo.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                    Directory.Delete(Folderpath);
                    Directory.CreateDirectory(Folderpath);                     
                    File.Create(logfilename);                    
                }

            }
            catch
            {

            }
        }

        public static void Errorlog(string element, string msg, bool append = true)
        {
            //c://User/user/dekstop mapp�ba val� ment�s

            string date = DateTime.Now.ToString("yyyyMMddhhmmss");

            string logdir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            string errlogfilename = logdir + "error" +element + date + ".txt"; 
            using (FileStream stream = new FileStream(errlogfilename, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            using (StreamWriter sw = new StreamWriter(stream))
            {
               sw.WriteLine("A keresett element: " + element + " " + msg + " id�pont:" + DateTime.Now);
            }          

        }

        public static async Task WriteLog(string Folderpath, string testname, string msg, bool append = true)
        {
            string logFilePath = Path.Combine(Folderpath, testname + ".txt");

            // A f�jl megnyit�sa az Append m�dban, biztos�tva, hogy az �j �zenet a f�jl v�g�re ker�lj�n
            using (FileStream stream = new FileStream(logFilePath, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            using (StreamWriter sw = new StreamWriter(stream))
            {
                await sw.WriteAsync(msg); // �j �zenet �r�sa a f�jlba
            }
        }

    }

    public class Valuecheck
    {

        public static string GetText(string element, PropertyTypes elementtype, IWebDriver driver)
        {
            
                if (elementtype == PropertyTypes.Id)
                {
                    return driver.FindElement(By.Id(element)).GetAttribute("value");                   
                }

                if (elementtype == PropertyTypes.Name)
                {
                    return driver.FindElement(By.Name(element)).GetAttribute("value");                   
                }

                if (elementtype == PropertyTypes.Xpath)
                {
                    return driver.FindElement(By.XPath(element)).GetAttribute("value");                   
                }

                if (elementtype == PropertyTypes.TagName)
                {
                    return driver.FindElement(By.TagName(element)).GetAttribute("value");                   
                }

                if (elementtype == PropertyTypes.ClassName)
                {
                    return driver.FindElement(By.ClassName(element)).GetAttribute("value");                   
                }

                else
                {
                return String.Empty;
                }                         
        }
       
    }    
 }

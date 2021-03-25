using System;
using System.Collections.Generic;
using System.IO;


namespace Logger
{
    public class Logger : ILogger
    {
        private List<string> _uniqueWarning = new List<string>();
        private List<string> _uniqueError = new List<string>();
        
        public void Fatal(string message)
        {
            WriteTextIntoFile(message,"Fatal","Fatal");
        }

        public void Fatal(string message, Exception e)
        {
            WriteTextIntoFile(message,e,"Fatal","Fatal");
        }

        public void Error(string message)
        {
            WriteTextIntoFile(message,"Error","Error");
            ErrorUnique(message,new Exception());//Вот тут костыль, я хз зачем вызывать метод с исключением, из метода в котором нет исключения
        }

        public void Error(string message, Exception e)
        {
            WriteTextIntoFile(message,e,"Error","Error");
            ErrorUnique("",e);
        }

        public void Error(Exception ex)
        {
            WriteTextIntoFile(ex,"Error","Error");
            ErrorUnique("",ex);
        }

        public void ErrorUnique(string message, Exception e)
        {
            if (message == "")
            {
                if (!_uniqueError.Contains(e.Message))
                {
                    _uniqueError.Add(e.Message);
                    WriteTextIntoFile(e, "UniqueError", "UniqueError");
                }
            }
            else if (e.Message=="")
            {
                if (!_uniqueError.Contains(message))
                {
                    _uniqueError.Add(message);
                    WriteTextIntoFile(message, "UniqueError", "UniqueError");
                }
            }
            else
            {
                if (!_uniqueError.Contains(e.Message)||!_uniqueError.Contains(message))
                {
                    _uniqueError.Add(message);
                    WriteTextIntoFile(message, e, "UniqueError", "UniqueError");
                }
            }
            
        }

        public void Warning(string message)
        {
            WriteTextIntoFile(message,"Warning","Warning");
            WarningUnique(message);
        }

        public void Warning(string message, Exception e)
        {
            WriteTextIntoFile(message,e,"Warning","Warning");
            WarningUnique(message);
        }

        public void WarningUnique(string message)
        {
            if(!_uniqueWarning.Contains(message))
            {
                _uniqueWarning.Add(message);
                WriteTextIntoFile(message,"UniqueWarning","NewUniqueWarning");
            }
        }

        public void Info(string message)
        {
            WriteTextIntoFile(message,"Info","Info");
        }

        public void Info(string message, Exception e)
        {
            WriteTextIntoFile(message,e,"Info","Info");
        }

        public void Info(string message, params object[] args)
        {
            WriteTextIntoFile(message,"info","Info");
        }

        public void Debug(string message)
        {
            WriteTextIntoFile(message,"Debug","Debug");
        }

        public void Debug(string message, Exception e)
        {
            WriteTextIntoFile(message,e,"Debug","Debug");
        }

        public void DebugFormat(string message, params object[] args)
        {
            var newMessage = $"{message}\n";
            foreach (var t in args)
            {
                newMessage += "\n"+Convert.ToString(t);
            }
            WriteTextIntoFile($"{newMessage}","DebugFormat","DebugFormat");
        }

        public void SystemInfo(string message, Dictionary<object, object> properties)
        {
            var newMessage="";
            foreach (var (key, value) in properties)
            {
                newMessage += $"{message} {key} {value}\n";
            }
            WriteTextIntoFile($"{newMessage}","SystemInfo","SystemInfo");
        }

        private static void CreateDirectoryWithCurrentDate()
        {
            if (!Directory.Exists($"C:\\Logs\\{DateTime.Now.ToShortDateString()}"))
            {
                Directory.CreateDirectory($"C:\\Logs\\{DateTime.Now.ToShortDateString()}");  
            }
        }

        private static void CreateFileWithName(string name)
        {
            CreateDirectoryWithCurrentDate();
            if (!File.Exists($"C:\\Logs\\{ DateTime.Now.ToShortDateString()}\\{name}.txt"))
            {
                FileStream fstream = new FileStream($"C:\\Logs\\{ DateTime.Now.ToShortDateString()}\\{name}.txt", FileMode.Create);
                fstream.Close();
               /* File.Create($"C:\\Logs\\{ DateTime.Now.ToShortDateString()}\\{name}.txt");*/
            }
        }

        private static void WriteTextIntoFile(string message,string fileName,string exceptionName)
        {
            CreateFileWithName(fileName);
            using (var sr = new StreamWriter($"C:\\Logs\\{DateTime.Now.ToShortDateString()}\\{fileName}.txt", true))
            {
                sr.Flush();
                sr.WriteLine($"{DateTime.Now.ToLongTimeString()} | {exceptionName}");
                sr.WriteLine("Message:");
                sr.WriteLine(message);
                sr.WriteLine("--------------------");
            }
        }
        
        private static void WriteTextIntoFile(Exception ex,string fileName,string exceptionName)
        {
            CreateFileWithName(fileName);
            using (var sr = new StreamWriter($"C:\\Logs\\{DateTime.Now.ToShortDateString()}\\{fileName}.txt", true))
            {
                
                sr.WriteLine($"{DateTime.Now.ToLongTimeString()} | {exceptionName}");
                sr.WriteLine("Exception:");
                sr.WriteLine(ex.Message);
                sr.WriteLine("--------------------");
            }
        }
        
        private static void WriteTextIntoFile(string message,Exception ex,string fileName,string exceptionName)
        {
            CreateFileWithName(fileName);
            using (var sr = new StreamWriter($"C:\\Logs\\{ DateTime.Now.ToShortDateString()}\\{fileName}.txt", true))
            {
                sr.Flush();
                sr.WriteLine($"{DateTime.Now.ToLongTimeString()} | {exceptionName}");
                sr.WriteLine("Message:");
                sr.WriteLine(message);
                sr.WriteLine("Exception:");
                sr.WriteLine(ex.Message);
                sr.WriteLine("--------------------");
            }
        }
    }
}
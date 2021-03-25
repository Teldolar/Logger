using System;
using System.Collections;
using System.Collections.Generic;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.Fatal("Fatal");
            logger.Error(new Exception("тут что-то есть"));
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add(1,"первое значение");
            dict.Add(2, "второе значение");
            logger.SystemInfo("SystemInfo", dict);
            logger.Warning("Warning");
        }
    }
}
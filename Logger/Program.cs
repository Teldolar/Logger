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
            logger.Fatal("Fatal error!");
            logger.Error(new IndexOutOfRangeException());
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add(1,"100");
            dict.Add(2, "200");
            dict.Add(3, "300");
            logger.SystemInfo("SystemInfo", dict);
            logger.Warning("Warning");
        }
    }
}
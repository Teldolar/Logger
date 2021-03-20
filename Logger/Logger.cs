using System;
using System.Collections.Generic;


namespace Logger
{
    public class Logger : IInfoLogger,IDebugLogger,IErrorLogger,IFatalLogger,IWarningLogger,ISystemInfoLogger
    {
        void IFatalLogger.Fatal(string message)
        {
            Console.WriteLine(123);
        }

        void IFatalLogger.Fatal(string message, Exception e)
        {
            
        }

        void IErrorLogger.Error(string message)
        {
            
        }

        void IErrorLogger.Error(string message, Exception e)
        {
            
        }

        void IErrorLogger.Error(Exception ex)
        {
            
        }

        void IErrorLogger.ErrorUnique(string message, Exception e)
        {
            
        }

        void IWarningLogger.Warning(string message)
        {
            
        }

        void IWarningLogger.Warning(string message, Exception e)
        {
            
        }

        void IWarningLogger.WarningUnique(string message)
        {
            
        }

        void IInfoLogger.Info(string message)
        {
            
        }

        void IInfoLogger.Info(string message, Exception e)
        {
            
        }

        void IInfoLogger.Info(string message, params object[] args)
        {
            
        }

        void IDebugLogger.Debug(string message)
        {
            
        }

        void IDebugLogger.Debug(string message, Exception e)
        {
            
        }

        void IDebugLogger.DebugFormat(string message, params object[] args)
        {
            
        }

        void ISystemInfoLogger.SystemInfo(string message, Dictionary<object, object> properties)
        {
            
        }
    }
}
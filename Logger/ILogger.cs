using System;
using System.Collections.Generic;

namespace Logger
{
    public interface IFatalLogger
    {
        /// <summary>
        /// Критичная ошибка:приложение не может далее функционировать
        /// </summary>
        /// <param name="message">сообщение</param>
        void Fatal(string message);

        /// <summary>
        /// Критичная ошибка:приложение не может далее функционировать
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="e">Exception</param>
        void Fatal(string message, Exception e);
    }
    
    public interface IErrorLogger
    {
        /// <summary>
        /// Ошибка в работе приложения: операция расчета завершается, но приложение продолжает работу
        /// </summary>
        /// <param name="message">сообщение</param>
        void Error(string message);

        /// <summary>
        /// Ошибка в работе приложения: операция расчета завершается, но приложение продолжает работу
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="e">Exception</param>
        void Error(string message, Exception e);

        /// <summary>
        /// Ошибка в работе приложения: операция расчета завершается, но приложение продолжает работу
        /// </summary>
        /// <param name="ex"></param>
        void Error(Exception ex);

        /// <summary>
        /// Запись уникальных ошибок
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void ErrorUnique(string message, Exception e);
    }
    
    public interface IWarningLogger
    {
        /// <summary>
        /// Предупреждение: на работу приложения не влияет, 
        /// но может сообщать о потенциальных проблемах в расчете
        /// </summary>
        /// <param name="message">сообщение</param>
        void Warning(string message);

        /// <summary>
        /// Предупреждение: на работу приложения не влияет, 
        /// но может сообщать о потенциальных проблемах в расчете
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="e">Exception</param>
        void Warning(string message, Exception e);


        /// <summary>
        /// Пишет в лог уникальные в течении дня ошибки 
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <remarks>
        /// Если в течении дня поступают сообщения с одинаковым содержанием,
        ///  то в лог попадут только первые вхождения. 
        /// По прошествию дня уникальность возобновляется.
        /// </remarks>>
        void WarningUnique(string message);
    }
    
    public interface IInfoLogger
    {
        /// <summary>
        /// Информирование: не влияет на работу приложения,
        /// является инструментом информирования
        /// </summary>
        /// <param name="message">сообщение</param>
        void Info(string message);

        /// <summary>
        /// Информирование: не влияет на работу приложения,
        /// является инструментом информирования
        /// </summary>
        /// <param name="message">сообщение</param>
        ///  /// <param name="e">Exception</param>
        void Info(string message, Exception e);

        /// <summary>
        /// Информирование: не влияет на работу приложения,
        /// является инструментом информирования
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="args">аргументы</param>
        void Info(string message, params object[] args);
    }
    
    public interface IDebugLogger
    {
        /// <summary>
        /// Дебагирование: инструмент для трассировки и отладки
        /// </summary>
        /// <param name="message">сообщение</param>
        void Debug(string message);

        /// <summary>
        /// Дебагирование: инструмент для трассировки и отладки
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="e">Exception</param>
        void Debug(string message, Exception e);

        /// <summary>
        /// Дебагирование: инструмент для трассировки и отладки
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args">аргументы</param>
        void DebugFormat(string message, params object[] args);
    }
    
    public interface ISystemInfoLogger
    {
        /// <summary>
        /// Запись системных логов информационного характера
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        void SystemInfo(string message, Dictionary<object, object> properties = null);
    }
}
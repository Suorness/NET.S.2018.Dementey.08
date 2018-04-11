namespace Logger
{
    using System;
    using NLog;

    /// <summary>
    /// A class that implements logging using NLog
    /// </summary>
    public class NLogLogger : ILogger
    {
        private readonly Logger _logger;

        public NLogLogger(string className)
        {
            if (string.IsNullOrEmpty(className))
            {
                throw new ArgumentException($"{nameof(className)} must not be Null Or Empty");
            }

            _logger = LogManager.GetLogger(className);
        }

        /// <summary>
        /// Displays a message to the Debug level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        /// <summary>
        /// Displays a message to the Error level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        public void Error(string message)
        {
            _logger.Error(message);
        }

        /// <summary>
        /// Displays a message to the Error level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        /// <param name="exception">error description</param>
        public void Error(string message, Exception exception)
        {
            _logger.Error(exception, message);
        }

        /// <summary>
        /// Displays a message to the Fatal level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        /// <summary>
        /// Displays a message to the Fatal level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        /// <param name="exception">error description</param>
        public void Fatal(string message, Exception exception)
        {
            _logger.Fatal(exception, message);
        }

        /// <summary>
        /// Displays a message to the Info level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        public void Info(string message)
        {
            _logger.Info(message);
        }

        /// <summary>
        /// Displays a message to the Trace level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        /// <summary>
        /// Displays a message to the Warn level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        /// <summary>
        /// Displays a message to the Warn level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        /// <param name="exception">error description</param>
        public void Warn(string message, Exception exception)
        {
            _logger.Warn(exception, message);
        }
    }
}

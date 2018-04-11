namespace Logger
{
    using System;

    /// <summary>
    /// Logger interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Displays a message to the Info level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        void Info(string message);

        /// <summary>
        /// Displays a message to the Trace level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        void Trace(string message);

        /// <summary>
        /// Displays a message to the Debug level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        void Debug(string message);

        /// <summary>
        /// Displays a message to the Warn level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        void Warn(string message);

        /// <summary>
        /// Displays a message to the Warn level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        /// <param name="exception">error description</param>
        void Warn(string message, Exception exception);

        /// <summary>
        /// Displays a message to the Error level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        void Error(string message);

        /// <summary>
        /// Displays a message to the Error level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        /// <param name="exception">error description</param>
        void Error(string message, Exception exception);

        /// <summary>
        /// Displays a message to the Fatal level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        void Fatal(string message);

        /// <summary>
        /// Displays a message to the Fatal level. 
        /// </summary>
        /// <param name="message">diagnostic message</param>
        /// <param name="exception">error description</param>
        void Fatal(string message, Exception exception);
    }
}

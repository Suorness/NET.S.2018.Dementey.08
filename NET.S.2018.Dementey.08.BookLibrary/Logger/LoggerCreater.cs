namespace Logger
{
    public class LoggerCreater
    {
        public static ILogger GetLogger(string className)
        {
            return new NLogLogger(className);
        }
    }
}

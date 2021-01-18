using Framework.Logging;
using NUnit.Framework;
using System;
using System.IO;

namespace Framework
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. SetLogger() first.");

        [ThreadStatic]
        
        public static DirectoryInfo CurrentTestDirectory;

        [ThreadStatic]
        private static Logger _logger;

        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY + "TestResults";

            if(Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testDirectory);
        }

        public static void SetLogger()
        {
            lock(_setLoggerLock)
            {
                var testResultsDir = WORKSPACE_DIRECTORY + "TestResults";
                var testName= TestContext.CurrentContext.Test.Name; 
                var fullPath = $"{testResultsDir}/{testName}";

                if(Directory.Exists(fullPath))
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath + TestContext.CurrentContext.Test.ID);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath);
                }
                
                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
            }

        }

        private static object _setLoggerLock = new object();
    }   
}
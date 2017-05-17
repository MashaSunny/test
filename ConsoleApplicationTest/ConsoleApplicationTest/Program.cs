using System;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Test
{
    class Program
    {
        static string[] testsToRun;
        static void Main(string[] args)
        {
            Base TrialTest;
            testsToRun = new string[] {
                "Test.TestCase01",
                "Test.TestCase02",
                "Test.TestCase03",
                "Test.TestCase04",
                "Test.TestCase05",
                "Test.TestCase06",
                "Test.TestCase07",
                "Test.TestCase08",
                "Test.TestCase09",
                };

            foreach (string test in testsToRun)
            {
                TrialTest = (Base)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(test);
                TrialTest.Run();
                TrialTest.Dispose();
            }
        }
    }
}

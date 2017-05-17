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
                    "Test.TestCase0",
                    "Test.TestCase1","Test.TestCase2","Test.TestCase3","Test.TestCase4","Test.TestCase5",
                    "Test.TestCase6","Test.TestCase7","Test.TestCase8","Test.TestCase9","Test.TestCase10",
                    "Test.TestCase11","Test.TestCase12","Test.TestCase13","Test.TestCase14","Test.TestCase15",
                    "Test.TestCase16","Test.TestCase17","Test.TestCase18","Test.TestCase19","Test.TestCase20",
                    "Test.TestCase21","Test.TestCase22","Test.TestCase23","Test.TestCase24","Test.TestCase25",

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

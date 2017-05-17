using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Remote;
using System.IO;

namespace Test
{
    public class Base : IDisposable
    {
        public RemoteWebDriver driver;

        public string name;
        public string description;
        bool errors = false;

        public struct Step
        {
            public string name;
            public Action action;
        }


        public string
            Site = "https://realtimeboard.com/signup/",
            Logo = "overlay__logo",
            Nam = "Mery",
            Login = "masha_korchazhno@mail.ru",
            Password = "Qwerty123456",
            InputName = "//input[@name='signup[name]']",
            InputLogin = "//input[@name='signup[email]']",
            InputPassword = "//input[@name='signup[password]']",
            RegistrationForm = "//button[text()='Get started now']",
            IDoNotRememberPassword = "//a[text()='Я не помню пароль']",
            Cabinet = "//a[contains(text(), 'кабинет')]";



        public Actions actions;
        public WebDriverWait waiter;
        public Step[] steps;
        public Type[] drivers = new Type[]
        {
            typeof(ChromeDriver)
        };


        public void RunDriver(Type driverType)
        {
            driver = (RemoteWebDriver)Activator.CreateInstance(driverType);
            //driver.Manage().Window.Maximize();
            actions = new Actions(driver);
            waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void Run()
        {
            DateTime fullStart, fullStop, start, stop;
            TimeSpan fullDuration, Duration;
            String separator = "________________________________________________________________________________";

            foreach (Type driverType in drivers)
            {
                RunDriver(driverType);
                Console.WriteLine();
                Console.WriteLine("Название теста - " + name);
                Console.WriteLine("Описание к тесту - " + description);
                Console.WriteLine("Тест запущен");
                Console.WriteLine();


                fullStart = DateTime.Now;
                for (int i = 0; i < steps.Length; i++)
                {

                    start = DateTime.Now;
                    try
                    {
                        Console.WriteLine("Выполняется шаг - " + steps[i].name);
                        steps[i].action();
                    }


                    catch (Exception Except)
                    {

                        Console.WriteLine("Произошла ошибка - " + Except.Message);
                        File.AppendAllText("ErrorLog.txt", separator);
                        File.AppendAllText("ErrorLog.txt", Except.Message);
                        Console.WriteLine();
                        Console.WriteLine("Подробнее об ошибке - " + Except.StackTrace);
                        File.AppendAllText("ErrorLog.txt", Except.StackTrace);
                        Console.WriteLine();
                        Console.WriteLine("Данные об ошибке записаны в файл errorlog");
                        errors = true;
                        goto error;


                    }
                    finally
                    {
                        stop = DateTime.Now;
                        Duration = stop - start;
                        Console.WriteLine("Шаг выполнялся - " + Duration + " сек.");
                        Console.WriteLine();
                    }
                }
            error:
                fullStop = DateTime.Now;
                fullDuration = fullStop - fullStart;
                Console.WriteLine("Продолжительность теста составляет - " + fullDuration + " сек.");
                Console.WriteLine();
                if (errors)
                {
                    Console.WriteLine("Результат - Тест провален");
                }
                else
                {
                    Console.WriteLine("Результат - Тест успешно завершен");
                }
                Console.WriteLine(separator);
                Dispose();
            }
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        public enum MouseAction
        {
            Click, DblClick, RightClick, Hover
        }

        public void WaitForElement(By by)
        {
            waiter.Until(d => d.FindElement(by));
        }

        public void SendKeys(By by, string textsend)
        {
            WaitForElement(by);
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(textsend);
        }

        public void WaitAndAction(By by, MouseAction action)
        {
            WaitForElement(by);
            var element = driver.FindElement(by);
            switch (action)
            {
                case MouseAction.Click:
                    element.Click();
                    break;
                case MouseAction.DblClick:
                    actions.DoubleClick(element).Perform();
                    break;
                case MouseAction.RightClick:
                    actions.ContextClick(element).Perform();
                    break;
                case MouseAction.Hover:
                    actions.MoveToElement(element).Perform();
                    break;
                default:
                    break;
            }
        }

    }
}

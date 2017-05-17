 using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase08: Base

    {
        public TestCase08()
        {
            name = "Проверка на часть незаполненных полей";
            description = "Проверка на часть незаполненных полей";

            steps = new Step[] {

                new Step() {
                    name = "Переход по url",
                    action = new Action(() => {
                        driver.Navigate().GoToUrl(Site);
                        WaitForElement(By.ClassName(Logo));
                    })
                },
                   new Step()
                {
                    name = "Проверка на часть незаполненных полей",
                    action = new Action(() => {
                        SendKeys(By.XPath(InputPassword), "тестст");
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Please enter your name']"));
                        WaitForElement(By.XPath("//div[text()='Please enter your email address']"));
                    })
                },

    };
        }
    }
}

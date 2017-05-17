using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase03: Base

    {
        public TestCase03()
        {
            name = "Некорректный адрес электронной почты";
            description = "Проверка валидации некорректного адреса электронной почты";

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
                    name = "Проверка валидации некорректного адреса электронной почты",
                    action = new Action(() => {
                        SendKeys(By.XPath(InputName), Nam);
                        SendKeys(By.XPath(InputLogin), "qwerty");
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='This doesn’t look like an email address. Please check it for typos and try again.']"));
                    })
                },

    };
        }
    }
}

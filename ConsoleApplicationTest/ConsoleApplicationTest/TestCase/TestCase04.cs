using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase04: Base

    {
        public TestCase04()
        {
            name = "Регистрация";
            description = "Проверка регистрации при верных данных";

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
                    name = "Проверка регистрации при верных данных",
                    action = new Action(() => {
                        SendKeys(By.XPath(InputName), Nam);
                        SendKeys(By.XPath(InputLogin), "Tes6t@mail.ru");
                        SendKeys(By.XPath(InputPassword), "qwerty1");
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[@class='rtbLoader_sticker']"));
                    })
                },

    };
        }
    }
}

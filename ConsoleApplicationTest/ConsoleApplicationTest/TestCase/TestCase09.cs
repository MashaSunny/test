using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase09: Base

    {
        public TestCase09()
        {
            name = "Регистрация дубля";
            description = "Проверка валидации на дублирующийся учетные записи";

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
                    name = "Проверка валидации на дублирующийся учетные записи",
                    action = new Action(() => {
                        SendKeys(By.XPath(InputName), "qwerty");
                        SendKeys(By.XPath(InputLogin), Login);
                        SendKeys(By.XPath(InputPassword), "qwerty");
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Sorry, name and password cannot be the same']"));
                    })
                },

    };
        }
    }
}

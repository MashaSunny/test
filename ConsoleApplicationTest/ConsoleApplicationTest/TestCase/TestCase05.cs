using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase05: Base

    {
        public TestCase05()
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
                        SendKeys(By.XPath(InputName), "qwerty1");
                        SendKeys(By.XPath(InputLogin), "Тест@вар.рф");
                        SendKeys(By.XPath(InputPassword), "тестст");
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Sorry, this email is already registered']"));
                    })
                },

    };
        }
    }
}

using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase02 : Base
    {
        public TestCase02()
        {
            name = "Пароль менее 6 символов";
            description = "Проверка вывода сообщения о некорректном пароле";

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
                    name = "Проверка вывода сообщения о некорректном пароле",
                    action = new Action(() => {
                        SendKeys(By.XPath(InputName), "qwerty");
                        SendKeys(By.XPath(InputLogin), "qwerty@qwerty.ru");
                        SendKeys(By.XPath(InputPassword), "qw");
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Password must be 6+ characters']"));
                    })
                },

    };
        }
    }
}

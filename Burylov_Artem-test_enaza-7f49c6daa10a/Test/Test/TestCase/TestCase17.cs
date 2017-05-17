using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase17 : Base
    {
        public TestCase17()
        {
            name = "Регистрация нового пользователя при некорректным e-mail";
            description = "Проверка работоспособности формы на регистрацию нового пользователя с неккоректно введенным e-mail";

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
                    name = "Авторизация",
                    action = new Action(() => {
                        WaitAndAction(By.XPath(EntryCite), MouseAction.Click);
                        SendKeys(By.XPath(InputLogin), "burylovartemgmail.com");  
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='E-Mail некорректный']"));  
                    })
                },
                 
               
    };
        }
    }
}

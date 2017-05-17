using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase18 : Base
    {
        public TestCase18()
        {
            name = "Регистрация уже существующего пользователя";
            description = "Проверка работоспособности формы на регистрацию уже зарегестрированного пользователя";

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
                        SendKeys(By.XPath(InputLogin), Login);  
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Пользователь с таким e-mail уже зарегистрирован. ']"));  
                    })
                },
                 
               
    };
        }
    }
}

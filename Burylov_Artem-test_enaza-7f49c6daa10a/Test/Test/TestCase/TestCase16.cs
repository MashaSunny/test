using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase16 : Base
    {
        public TestCase16()
        {
            name = "Регистрация нового пользователя";
            description = "Проверка работоспособности формы авторизации на регистрацию нового пользователя";

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
                        SendKeys(By.XPath(InputLogin), "burylovartem1111@gmail.com");  // новый пользователь
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                    })
                },
                  new Step() {
                    name = "Загрузка авторизованной страницы",
                    action = new Action(() => {
                        WaitForElement(By.XPath(Cabinet));
                    })
                },    
               
    };
        }
    }
}

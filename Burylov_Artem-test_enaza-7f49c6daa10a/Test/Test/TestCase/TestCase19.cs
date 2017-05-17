using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase19 : Base
    {
        public TestCase19()
        {
            name = "Кнопка 'Я не помню пароль'";
            description = "Проверка работоспособности кнопки 'Я не помню пароль' для зарегестированного пользователя";

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
                        WaitAndAction(By.XPath(IDoNotRememberPassword), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Инструкция по восстановлению отправлена']"));  
                    })
                },
                 
               
    };
        }
    }
}

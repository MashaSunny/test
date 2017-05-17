using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase22 : Base
    {
        public TestCase22()
        {
            name = "Регистрация с недостаточным количеством данных";
            description = "Проверка работоспособности формы при отсутсвии Пароля";

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
                        SendKeys(By.XPath(InputLogin), "burylov.artem1@yandex.ru");  
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Придумайте себе пароль']"));  
                    })
                },
                 
               
    };
        }
    }
}

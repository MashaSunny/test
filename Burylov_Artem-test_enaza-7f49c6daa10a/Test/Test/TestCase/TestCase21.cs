using System;
using OpenQA.Selenium;


namespace Test
{
    class TestCase21 : Base
    {
        public TestCase21()
        {
            name = "Регистрация с недостаточным количеством данных";
            description = "Проверка работоспособности формы при отсутсвии E-mail";

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
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Введите E-mail, на который будут приходить покупки']"));  
                    })
                },
                 
               
    };
        }
    }
}

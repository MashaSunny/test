using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase25 : Base
    {
        public TestCase25()
        {
            name = "Регистрация нового пользователя";
            description = "Проверка работоспособности формы авторизации, при вводе английских и русских букв для регистрации (В поле E-mail)";

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
                        SendKeys(By.XPath(InputLogin), "enрус@ya.ru"); 
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='E-Mail некорректный']"));  
                    })
                },
                
               
    };
        }
    }
}

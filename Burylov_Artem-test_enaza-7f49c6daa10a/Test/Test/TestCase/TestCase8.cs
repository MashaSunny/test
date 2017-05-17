using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase8 : Base
    {
        public TestCase8()
        {
            name = "Авторизация с большим количеством русскоязычных символов";
            description = "Проверка работоспособности формы авторизации, при вводе большого количества русскоязычных символов (В поле E-mail)";

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
                        SendKeys(By.XPath(InputLogin), "ОООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООООО");
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Такого пользователя не существует. ']"));   
                    })
                },
               
    };
        }
    }
}

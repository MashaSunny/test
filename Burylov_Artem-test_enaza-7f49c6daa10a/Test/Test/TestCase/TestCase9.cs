using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase9 : Base
    {
        public TestCase9()
        {
            name = "Авторизация с большим количеством англоязычных символов";
            description = "Проверка работоспособности формы авторизации, при вводе большого количества англоязычных символов (В поле E-mail)";

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
                        SendKeys(By.XPath(InputLogin), "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Такого пользователя не существует. ']"));  
                    })
                },
               
    };
        }
    }
}

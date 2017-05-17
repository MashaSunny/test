 using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase15 : Base
    {
        public TestCase15()
        {
            name = "Авторизация с включенным чекбоксом 'Запомнить меня'";  
            description = "Проверка работоспособности кнопки запомнить при авторизации";
            
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
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitAndAction(By.Name("StaySignedIn"), MouseAction.Click); 
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

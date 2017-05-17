using System;
using OpenQA.Selenium;


namespace Test
{
    class TestCase1 : Base
    {
        public TestCase1()
        {
            name = "Авторизация с правильными данными";
            description = "Проверка работоспособности формы авторизации, при правильно вводимых данных";

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

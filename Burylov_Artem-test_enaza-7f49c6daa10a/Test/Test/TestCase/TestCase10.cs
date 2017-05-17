using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase10 : Base
    {
        public TestCase10()
        {
            name = "Авторизация с недопустимыми символами";
            description = "Проверка работоспособности формы авторизации, при вводе недопустимых данных (В поле Пароль)";

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
                        SendKeys(By.XPath(InputPassword), "''&&^^");
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Неправильный пароль. ']"));  
                    })
                },
               
    };
        }
    }
}

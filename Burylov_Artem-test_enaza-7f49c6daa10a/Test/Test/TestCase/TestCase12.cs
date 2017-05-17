using System;
using OpenQA.Selenium;


namespace Test
{
    class TestCase12 : Base
    {
        public TestCase12()
        {
            name = "Авторизация с недопустимыми символами";
            description = "Проверка работоспособности формы авторизации, при вводе недопустимых данных (В поле E-mail и Пароль)";

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
                        SendKeys(By.XPath(InputLogin), "''&&^^");
                        SendKeys(By.XPath(InputPassword), "''&&^^");
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Такого пользователя не существует. ']"));  
                    })
                },
               
    };
        }
    }
}

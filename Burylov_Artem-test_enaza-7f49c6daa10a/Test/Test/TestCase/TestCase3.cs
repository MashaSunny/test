using System;
using OpenQA.Selenium;


namespace Test
{
    class TestCase3 : Base
    {
        public TestCase3()
        {
            name = "Авторизация с неправильными данными";
            description = "Проверка работоспособности формы авторизации, при неправильно вводимых данных (В поле E-mail)";

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
                        SendKeys(By.XPath(InputLogin), "Qwerty");
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Такого пользователя не существует. ']"));   
                    })
                },
               
    };
        }
    }
}

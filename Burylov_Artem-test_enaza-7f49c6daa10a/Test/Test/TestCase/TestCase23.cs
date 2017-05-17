using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase23 : Base
    {
        public TestCase23()
        {
            name = "Авторизация с неправильными данными";
            description = "Проверка работоспособности формы авторизации, при вводе прописных символов (В поле E-mail и Пароль)";

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
                        SendKeys(By.XPath(InputLogin), "QWERTY");
                        SendKeys(By.XPath(InputPassword), "QWERTY");
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Такого пользователя не существует. ']"));   
                    })
                },
               
    };
        }
    }
}

using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase14 : Base
    {
        public TestCase14()
        {
            name = "Авторизация с большим количеством символов";
            description = "Проверка работоспособности формы авторизации, при вводе большого количества символов (В поле E-mail и Пароль)";

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
                        SendKeys(By.XPath(InputLogin), "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                        SendKeys(By.XPath(InputPassword), "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Такого пользователя не существует. ']"));  
                    })
                },
               
    };
        }
    }
}

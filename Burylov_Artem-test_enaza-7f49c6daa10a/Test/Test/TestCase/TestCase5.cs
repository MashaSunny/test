using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase5 : Base
    {
        public TestCase5()
        {
            name = "Авторизация с отсутствием данных";
            description = "Проверка работоспособности формы авторизации, при отсутсвии вводимых данных (В поле E-mail и Пароль)";

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
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Введите E-mail, на который вы регистрировались']"));  
                    })
                },
               
    };
        }
    }
}

using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase0 : Base
    {
        public TestCase0()
        {
            name = "Корректность записей на форме";
            description = "Проверка отображения коректности записей на форме";

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
                    name = "Проверка коректностей записей на форме авторизации",
                    action = new Action(() => {
                        WaitAndAction(By.XPath(EntryCite), MouseAction.Click);
                        WaitForElement(By.XPath("//span[text()='Email:']"));
                        WaitForElement(By.XPath("//span[text()='Пароль:']"));
                        WaitForElement(By.XPath("//button[text()='Войти']"));
                        WaitForElement(By.XPath("//a[text()='Создать аккаунт']"));
                        WaitForElement(By.XPath("//span[text()='запомнить меня']"));
                        WaitForElement(By.XPath("//a[text()='Я не помню пароль']"));
                    })
                },
               
    };
        }
    }
}

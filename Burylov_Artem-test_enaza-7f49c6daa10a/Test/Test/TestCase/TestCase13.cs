using System;
using OpenQA.Selenium;
using System.Threading;

namespace Test
{
    class TestCase13 : Base
    {
        public TestCase13()
        {
            name = "Смена пароля и авторизация с новым и старым паролем";
            description = "Проверка работоспособности формы авторизации, при смене пароля и выходе, а потом авторизации как под старым, так и под новым паролем. Смена пароля на прежний";

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
                new Step() {
                    name = "Вход в личный кабинет и смена пароля",
                    action = new Action(() => {
                        WaitAndAction(By.XPath(Cabinet), MouseAction.Click);
                        WaitAndAction(By.XPath("//a[text()='редактировать']"), MouseAction.Click);
                        
                        driver.ExecuteScript("window.scrollBy(" + 0 + "," + 700 + ");");
                        Thread.Sleep(2000); //Анимация
                        SendKeys(By.Id("oldpwd"), Password);
                        SendKeys(By.Id("newpwd"), "test");
                        WaitAndAction(By.XPath("//button[contains(@class, 'user-profile-password-save')]"), MouseAction.Click); 
                    })
                },


                 new Step() {
                    name = "Выход из личного кабинета",
                    action = new Action(() => {
                        WaitAndAction(By.XPath("//a[text()='Выход']"), MouseAction.Click);
                    })
                },

                new Step() {
                    name = "Авторизация со старым паролем",
                    action = new Action(() => {
                        WaitAndAction(By.XPath(EntryCite), MouseAction.Click);
                        Thread.Sleep(1000);
                        SendKeys(By.XPath(InputLogin), Login);
                        SendKeys(By.XPath(InputPassword), Password);
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Неправильный пароль. ']"));
                    })
                },

                new Step() {
                    name = "Авторизация с новым паролем",
                    action = new Action(() => {
                        driver.FindElementByXPath(InputPassword).Clear();
                        SendKeys(By.XPath(InputPassword), "test");
                        WaitAndAction(By.XPath(EntryForm), MouseAction.Click);
                    })
                },
                  new Step() {
                    name = "Загрузка авторизованной страницы",
                    action = new Action(() => {
                        WaitForElement(By.XPath(Cabinet));  
                    })
                },
               
                  new Step() {
                    name = "Cмена пароля на исходный",
                    action = new Action(() => {
                        WaitAndAction(By.XPath(Cabinet), MouseAction.Click);
                        WaitAndAction(By.XPath("//a[text()='редактировать']"), MouseAction.Click);
                        driver.ExecuteScript("window.scrollBy(" + 0 + "," + 700 + ");"); 
                        Thread.Sleep(2000); //Анимация
                        SendKeys(By.Id("oldpwd"), "test");
                        SendKeys(By.Id("newpwd"), Password);
                        WaitAndAction(By.XPath("//button[contains(@class, 'user-profile-password-save')]"), MouseAction.Click); 
                    })
                },
    };
        }
    }
}

using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase24 : Base
    {
        public TestCase24()
        {
            name = "Регистрация нового пользователя";
            description = "Проверка работоспособности формы авторизации, при вводе прописных символов для регистрации (В поле Пароль)";

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
                        SendKeys(By.XPath(InputLogin), "burylovartem111122@gmail.com");  // новый пользователь
                        SendKeys(By.XPath(InputPassword), "QWERTY");
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
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

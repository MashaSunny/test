using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase01: Base
    {
        public TestCase01()
        {
            name = "Корректность записей на форме";
            description = "Проверка отображения корректности записей на форме";

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
                    name = "Проверка корректностей записей на форме авторизации",
                    action = new Action(() => {
                        WaitForElement(By.XPath("//input[@id='name']"));
                        WaitForElement(By.XPath("//input[@id='email']"));
                        WaitForElement(By.XPath("//input[@id='password']"));
                        WaitForElement(By.XPath("//button[text()='Get started now']"));
                    })
                },

    };
        }
    }
}

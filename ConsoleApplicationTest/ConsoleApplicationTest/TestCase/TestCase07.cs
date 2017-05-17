using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase07: Base

    {
        public TestCase07()
        {
            name = "Проверка пустого ввода";
            description = "Проверка пустого ввода";

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
                    name = "Проверка пустого ввода",
                    action = new Action(() => {                       
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//input[@class='signup__input  signup__input--error']"));
                    })
                },

    };
        }
    }
}

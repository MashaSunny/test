using System;
using OpenQA.Selenium;

namespace Test
{
    class TestCase06: Base

    {
        public TestCase06()
        {
            name = "Ввод большого количества символов";
            description = "Проверка на ввод большого количество символов";

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
                    name = "Проверка на ввод большого количество символов",
                    action = new Action(() => {
                        SendKeys(By.XPath(InputName), "Test_Test_Test_Test_Test_Test_Test_Test_Test_Test_Test_Test_Test_");
                        SendKeys(By.XPath(InputLogin), "test@test.ru");
                        SendKeys(By.XPath(InputPassword), "qwerty1");
                        WaitAndAction(By.XPath(RegistrationForm), MouseAction.Click);
                        WaitForElement(By.XPath("//div[text()='Sorry, your name cannot exceed 60 characters']"));
                    })
                },

    };
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Selenium
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        [SetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            driver = new ChromeDriver(path + @"\drivers\");
        }

        [Test]
        public void CheckFieldsExist()
        {
            driver.Navigate().GoToUrl("https://politrip.com/account/sign-up");

            Assert.IsTrue(driver.FindElement(By.Id("first-name")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("last-name")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("email")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("sign-up-password-input")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("sign-up-confirm-password-input")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("sign-up-heard-input")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id(" qa_loader-button")).Displayed);

        }

        [Test]
        public void SignInEnabledTestCase()
        {
            driver.Navigate().GoToUrl("https://politrip.com/account/sign-up");

            WebElement firstName = (WebElement)driver.FindElement(By.Id("first-name"));
            firstName.SendKeys("Andreea");
            WebElement lastName = (WebElement)driver.FindElement(By.Id("last-name"));
            lastName.SendKeys("Cotan");
            WebElement emailAdress = (WebElement)driver.FindElement(By.Id("email"));
            emailAdress.SendKeys("andreea12345cjjk@yahoo.ro");
            WebElement password = (WebElement)driver.FindElement(By.Id("sign-up-password-input"));
            password.SendKeys("Aa123456");
            WebElement passwordConfirm = (WebElement)driver.FindElement(By.Id("sign-up-confirm-password-input"));
            passwordConfirm.SendKeys("Aa123456");
            IWebElement signUp = driver.FindElement(By.XPath("//a[contains(text(),'Sign up')]"));

            Assert.IsTrue(signUp.Enabled);
        }

        [Test]
        public void ErrorMessagesTestCase()
        {
            driver.Navigate().GoToUrl("https://politrip.com/account/sign-up");
            WebElement firstName = (WebElement)driver.FindElement(By.Id("first-name"));
            firstName.SendKeys("123");
            IWebElement firstNameError = driver.FindElement(By.ClassName("ng-dirty"));
            Assert.IsTrue(firstNameError.Displayed);
        }

        [OneTimeTearDown]
        public void TearDown()

        {
            driver.Quit();
        }
    }
}
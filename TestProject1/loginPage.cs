using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using System.Text;

namespace TestProject1
{
    internal class loginPage
    {

        IWebDriver driver;

        By username = By.Id("signInName");
        By password = By.Id("password");
        By loginButton = By.Id("next");


        public loginPage(IWebDriver driver) {
         this.driver= driver;   
        
        }

        public void typeUserNmae()
        {
            infrastructure.WaitUntilElementClickable(driver, By.Id("signInName"));
            driver.FindElement(username).SendKeys("demo@munters.co.il");
        }

        public void typePassword()
        {
            driver.FindElement(password).SendKeys("Demo123456");
        }

        public void ClicknextButton()
        {
            driver.FindElement(loginButton).Click();
        }
        
            



    }
}

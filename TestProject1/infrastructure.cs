using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    internal  class infrastructure
    {
        IWebDriver driver;

        By username = By.Id("signInName");
        By password = By.Id("password");
        By loginButton = By.Id("next");


        public infrastructure(IWebDriver driver)
        {
            this.driver = driver;

        }

        public static IWebElement WaitUntilElementClickable(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            // return random.NextDouble() * (maximum - minimum) + minimum;
            double value = random.NextDouble() * (maximum - minimum) + minimum;
            value = (double)System.Math.Round(value, 1);
            return value;
        }

        public static void Typing_on_keyboard(String numberToClick, IWebDriver driver, By keypad_body_table, By app_keypad_action_table)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            IWebElement keypad_body = driver.FindElement(keypad_body_table);
            IList<IWebElement> app_keypad_action = keypad_body.FindElements(app_keypad_action_table);
            
            int strin_len = numberToClick.Length;
            String number_str = numberToClick.Substring(0);
            string input = numberToClick;

            char[] ch = new char[input.Length];


            ch = input.ToCharArray(); ;
            char numberToClickOn;

            //Clear field from content
            jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(13));
            app_keypad_action.ElementAt(13).Click();

            for (int i = 0; i < ch.Length; i++)
            {
                numberToClickOn = ch[i];



                switch (numberToClickOn.ToString())
                {
                    case "0":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(11));
                        app_keypad_action.ElementAt(10).Click();
                        break;
                    case "1":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(0));
                        app_keypad_action.ElementAt(0).Click();
                        break;
                    case "2":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(1));
                        app_keypad_action.ElementAt(1).Click();
                        break;
                    case "3":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(2));
                        app_keypad_action.ElementAt(2).Click();
                        break;
                    case "4":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(3));
                        app_keypad_action.ElementAt(3).Click();
                        break;
                    case "5":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(4));
                        app_keypad_action.ElementAt(4).Click();
                        break;
                    case "6":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(5));
                        app_keypad_action.ElementAt(5).Click();
                        break;
                    case "7":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(6));
                        app_keypad_action.ElementAt(6).Click();

                        break;
                    case "8":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(7));
                        app_keypad_action.ElementAt(7).Click();
                        break;
                    case "9":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(8));
                        app_keypad_action.ElementAt(8).Click();
                        break;
                    case ".":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(11));
                        app_keypad_action.ElementAt(11).Click();
                        break;
                    case "-":
                        jsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", app_keypad_action.ElementAt(9));
                        app_keypad_action.ElementAt(9).Click();
                        break;
                    default:
                        // code block
                        break;
                }
            }


        }
    }
}

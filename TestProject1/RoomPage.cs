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
    internal class RoomPage
    {
        IWebDriver driver;

        By munters_treeview = By.ClassName("munters-treeview");
        By e_fullrow = By.ClassName("e-fullrow");
        By loader_label = By.ClassName("loader-label");
        By ng_star_inserted = By.CssSelector("span[class='ng-star-inserted']");
        By loader_container = By.CssSelector("div[class='loader-container full-screen-loader ng-star-inserted']");
        By iframe = By.CssSelector("iframe[src='https://devices.trioair.net/4.0.176/#/cloud/home/zone-id/1/page/dashboard']");
        By button = By.TagName("button");
        By menu_table_name = By.ClassName("menu-table-name");
        By icon_edit  =By.CssSelector("span[class='icon-edit']");
        By icon_plus = By.CssSelector("span[class='icon-plus']");
        By table =By.CssSelector("table[class='e-table']");
        By table_row = By.TagName("tr");
        By table_Columns = By.TagName("td");
        By input_tag = By.TagName("input");
        By range_info = By.CssSelector("span[class='range-info']");
        By keypad_body=By.CssSelector("div[class='keypad-body']");
        By app_keypad_action =By.TagName("app-keypad-action");
        By toast_container = By.CssSelector("div[class='toast-bottom-left toast-container']");
    


        int number_of_lines;
        IList<IWebElement> table_Columns_list=new List<IWebElement>();  

        WebDriverWait wait;

        public IJavaScriptExecutor IjsExecutor { get; }

        private object jsExecutor;

        public RoomPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IjsExecutor = (IJavaScriptExecutor)driver;
        }


        public void Click_on_room_one()
        {
            

            
            // click on room 1
            //WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(munters_treeview));
            wait.Until(ExpectedConditions.ElementIsVisible(e_fullrow));
            IList<IWebElement> displayedOptions = driver.FindElements(e_fullrow);
            displayedOptions.ElementAt(3).Click();

        }


        public void wait_for_loading() {


            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loader_label));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(ng_star_inserted));
            Thread.Sleep(7000);
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("span[class='ng-star-inserted']")));
        }

        public void Change_to_Iframe() {
            // Change to Iframe
            driver.SwitchTo().Frame(driver.FindElement(iframe));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loader_container));

        }

        public void click_on_buttom_menu()
        {
            //click on buttom menu
            wait.Until(ExpectedConditions.ElementExists(button));
            wait.Until(ExpectedConditions.ElementIsVisible(button));
            IList<IWebElement> displayedOptions = driver.FindElements(button);
            displayedOptions.ElementAt(0).Click();

        }

        public void click_Temperature_CURVE()
        {
            //click on Temperature CURVE
            wait.Until(ExpectedConditions.ElementExists(menu_table_name));
            wait.Until(ExpectedConditions.ElementIsVisible(menu_table_name));
            IList<IWebElement> displayedOptions = driver.FindElements(menu_table_name);
            displayedOptions.ElementAt(0).Click();

        }


        public void click_on_edit_button()
        {

            ///click on edit button
            wait.Until(ExpectedConditions.ElementExists(icon_edit));
            wait.Until(ExpectedConditions.ElementIsVisible(icon_edit));
            driver.FindElement(By.CssSelector("span[class='icon-edit']")).Click();

        }



        public void click_on_icon_plus()
        {
            /// click on icon plus
            wait.Until(ExpectedConditions.ElementExists(icon_plus));
            wait.Until(ExpectedConditions.ElementIsVisible(icon_plus));
            driver.FindElement(icon_plus).Click();
            
          

        }

        public IList<IWebElement> get_data_from_table() {

           // IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            IList<IWebElement> my_table_list = driver.FindElements(table);
            
            IWebElement my_table = my_table_list.ElementAt(1);
            IjsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", my_table);
            IList<IWebElement> table_row_list = my_table.FindElements(table_row);
             number_of_lines = table_row_list.Count;
             table_Columns_list = table_row_list.ElementAt(number_of_lines - 1).FindElements(table_Columns);
            return table_Columns_list;

           
        }
      

        public void insert_data_to_day_and_Target()
        {
            this.table_Columns_list=get_data_from_table();
            IjsExecutor.ExecuteScript("arguments[0].style.border='2px solid greenyellow'", table_Columns_list.ElementAt(1));
            table_Columns_list.ElementAt(1).FindElement(input_tag).SendKeys(number_of_lines.ToString());
            int num = (int)infrastructure.GetRandomNumber(15, 30);
            table_Columns_list.ElementAt(2).FindElement(input_tag).SendKeys(num.ToString());

        }


        public void insert_data_to_Low_T_Alarm() {

            table_Columns_list.ElementAt(3).FindElement(input_tag).Click();
            wait.Until(ExpectedConditions.ElementExists(range_info));
            wait.Until(ExpectedConditions.ElementIsVisible(range_info));
            IWebElement data = driver.FindElement(range_info);
            ///  insert data to Low T Alarm
            ////----1
            String range = data.Text;
            Double start_range = Convert.ToDouble(range.Substring(0, 4));
            Double End_range = Convert.ToDouble((range.Substring(9).Trim()));

            double num = infrastructure.GetRandomNumber(start_range, End_range);
            IWebElement start_range_input = table_Columns_list.ElementAt(3).FindElement(input_tag);
            IjsExecutor.ExecuteScript("arguments[0].style.border='2px solid greenyellow'", start_range_input);


            wait.Until(ExpectedConditions.ElementExists(input_tag));
            wait.Until(ExpectedConditions.ElementIsVisible(input_tag));

            infrastructure.Typing_on_keyboard(num.ToString(),driver, keypad_body ,app_keypad_action);

        }

        public void insert_data_to_High_T_Alarm()
        {
            /////  insert data to High T Alarm
            ///////------2

            IWebElement start_range_end = table_Columns_list.ElementAt(4).FindElement(By.TagName("input"));
            table_Columns_list.ElementAt(4).FindElement(input_tag).Click();
            IWebElement data = driver.FindElement(range_info);
            String range = data.Text;
            Double start_range = Convert.ToDouble(range.Substring(0, 4));
            Double End_range = Convert.ToDouble((range.Substring(9).Trim()));
            wait.Until(ExpectedConditions.ElementExists(input_tag));
            wait.Until(ExpectedConditions.ElementIsVisible(input_tag));
            IjsExecutor.ExecuteScript("arguments[0].style.border='2px solid red'", start_range_end);

            double num = infrastructure.GetRandomNumber(start_range, End_range);
            infrastructure.Typing_on_keyboard(num.ToString(), driver, keypad_body, app_keypad_action);

        }
        public void click_on_button_save()
        {
            ///  click on button save
            driver.FindElement(By.CssSelector("div[class='toolbar-button label-button button-save ng-star-inserted']")).Click();
        }
            

        public void Assert_the_Toast()
        {
                // Assert the Toast 
                wait.Until(ExpectedConditions.ElementExists(toast_container));
                wait.Until(ExpectedConditions.ElementIsVisible(toast_container));
            
            String toast_string = driver.FindElement(toast_container).Text;
            if (toast_string != null)
            {
                if (toast_string.Contains("Changes saved"))
                {
                    Assert.IsTrue(toast_string.Contains("Changes saved"));
                }
                else if (toast_string.Contains("Failed to save changes! Please try again"))
                {
                    //   Assert.Fail("not saved");
                    Assert.Fail();


                }

            }
        }

    }
}

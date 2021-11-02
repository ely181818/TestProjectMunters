
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
    class Tests
    {

       
        String test_url = "https://www.trioair.net";
        
        IWebDriver driver;

        [OneTimeSetUp]
        public void start_Browser()
        {
          
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }




        [Test,Order(1)]
        public void LoginPage()
        {
           
            driver.Manage().Window.Maximize();
            driver.Url = test_url;
            loginPage loginPage = new LoginPage(driver);
            loginPage.typeUserNmae();
            loginPage.typePassword();
            Thread.Sleep(2000);
            loginPage.ClicknextButton();
            


        }

        [Test, Order(2)]
        public void connecting_page()
        {
            /// connecting page
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("connecting-message")));
        }
        [Test, Order(3)]
        public void Room_page()
        {
           
           

            RoomPage roomPage = new RoomPage(driver);

            roomPage.Click_on_room_one();
            roomPage.wait_for_loading();
            roomPage.Change_to_Iframe();
            roomPage.click_on_buttom_menu();
            roomPage.click_Temperature_CURVE();
            roomPage.click_on_edit_button();
            roomPage.click_on_icon_plus();
            roomPage.insert_data_to_day_and_Target();
            roomPage.insert_data_to_Low_T_Alarm();
            roomPage.insert_data_to_High_T_Alarm();
            roomPage.click_on_button_save();
            roomPage.Assert_the_Toast();

            
           

        }



        [OneTimeTearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
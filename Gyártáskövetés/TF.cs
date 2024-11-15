using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;
using Modules;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Documents;



namespace TF
{

    public class TF
    {
        private IWebDriver driver = new ChromeDriver();
        string munkatárs = "dmsdba";
        string password = "gum1cukor";
        string partner = "METZGER'97 KFT";
        string bizszam =  DateTime.Today.ToString("yyyy/MM/dd.") +"tf test";
        string brutto = "200000";

        //Log-PrtSC

        string testname = "test1";
        string folderpath = "C:\\WorkSpace\\240707\\";

        public static void Sleep(int seconds)
        {
            System.Threading.Thread.Sleep(seconds);
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); // Vagy bármelyik másik driver, pl. FirefoxDriver, EdgeDriver stb.
            driver.Navigate().GoToUrl("http://ad1/trufinance");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            LogWriterT.LogDirFileCreate(folderpath, testname);
            LogWriterT.WriteLog(folderpath, testname, "gyártáskövetés betöltve");
            WaitTime.Wait(2);
        }

        [Test]
        public void Test()
        {
            // 1. Bejelentkezés         
            // Felhasználó textboxba írás
            SeleniumMethods.EnterText("input[type=\"text\"]", munkatárs, PropertyTypes.CssSelector, driver);
            LogWriterT.WriteLog(folderpath, testname, "felhasználónév beírva");
            SeleniumMethods.TakePrtsc(folderpath, testname,driver);

            // Jelszó beírás
            SeleniumMethods.EnterText("input[type=\"password\"]", password, PropertyTypes.CssSelector, driver);
            LogWriterT.WriteLog(folderpath, testname, "password beírva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            // DB kiválasztás
            SeleniumMethods.Click(".v-input__append-inner", PropertyTypes.CssSelector,driver);;
            SeleniumMethods.Click("/html/body/div/div[2]/div/div[9]/div/div", PropertyTypes.Xpath, driver);
            LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            // Bejelentkezés)
            SeleniumMethods.Click("/html/body/div/div/main/div/div/div/div/div[3]/div/div/div/div[2]/div[4]/div[2]/button/span", PropertyTypes.Xpath,driver);
            LogWriterT.WriteLog(folderpath, testname, "bejelentkezés elindítva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);


            WaitTime.Wait(4);
            // új számla készítése 

            //  Bejövő bizonylatok 
            // //*[@id="app"]/div/div/header/div/div[3]/div/button[12]/span
            // /html/body/div/div/div/header/div/div[3]/div/button[2]

            SeleniumMethods.Click("/html/body/div/div/div/header/div/div[3]/div/button[2]", PropertyTypes.Xpath, driver); ;
            LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            SeleniumMethods.Click("/html/body/div/div[2]/div/div[1]/div", PropertyTypes.Xpath, driver);
            LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            //partner beírása

            SeleniumMethods.Click("/html/body/div/div[1]/main/div/div/div/div/div[3]/div/div[2]/div[2]/button", PropertyTypes.Xpath, driver);
            LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            SeleniumMethods.Click("/html/body/div/div[1]/main/div/div/div/div/div[3]/div/div/div/div[2]/span/span", PropertyTypes.Xpath, driver);
            LogWriterT.WriteLog(folderpath, testname, "p beírva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            //SeleniumMethods.EnterText("/html/body/div/div[1]/main/div/div/div/div/div[3]/div/div/div/div[2]/span/span/span[1]/input", partner, PropertyTypes.Xpath, driver);
            //LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            //SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            //SeleniumMethods.Click("/html/body/div[2]/div/div/div[2]/ul/div[1]", PropertyTypes.Xpath, driver);
            //LogWriterT.WriteLog(folderpath, testname, "p beírva");
            //SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            //SeleniumMethods.EnterText("/html/body/div/div[1]/main/div/div/div/div/div[3]/div/div[2]/div/div[1]/div[2]/div/div/div[2]/form/div[6]/div[2]/div/div/div[1]/div/input", bizszam, PropertyTypes.Xpath, driver);
            //LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            //SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            //SeleniumMethods.EnterText("/html/body/div/div[1]/main/div/div/div/div/div[3]/div/div[2]/div/div[1]/div[2]/div/div/div[2]/form/div[8]/div[5]/div[2]/div/input[1]", brutto, PropertyTypes.Xpath, driver);
            //LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            //SeleniumMethods.TakePrtsc(folderpath, testname, driver);


            //SeleniumMethods.Click("/html/body/div/div[1]/main/div/div/div/div/div[3]/div/div[2]/div/div[1]/div[2]/div/div/div[3]/button[2]", PropertyTypes.Xpath, driver);
            //LogWriterT.WriteLog(folderpath, testname, "p beírva");
            //SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            //SeleniumMethods.Click("/html/body/div/div[1]/main/div/div/div/div/div[3]/div/div[2]/div/div[3]/div/div/div[2]/div/div[2]/div/div/div[2]/div/div/div/div[2]/div/input", PropertyTypes.Xpath, driver);
            //LogWriterT.WriteLog(folderpath, testname, "p beírva");
            //SeleniumMethods.TakePrtsc(folderpath, testname, driver);


            //SeleniumMethods.Click("", PropertyTypes.Xpath, driver);
            //LogWriterT.WriteLog(folderpath, testname, "p beírva");
            //SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            //SeleniumMethods.Click("/html/body/div/div[1]/main/div/div/div/div/div[3]/div/div[2]/div/div[1]/div[2]/div/div/div[3]/button[1]", PropertyTypes.Xpath, driver);
            //LogWriterT.WriteLog(folderpath, testname, "p beírva");
            //SeleniumMethods.TakePrtsc(folderpath, testname, driver);



        }

        [TearDown]
        public void CleanUp()
        {
            //driver.Quit();
        }
    }


}


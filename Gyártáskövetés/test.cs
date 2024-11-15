using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;
using Modules;
using System.Threading;
using Microsoft.VisualBasic.FileIO;



namespace Gyártáskövetés
{

    public class Test1
    {
        private IWebDriver driver = new ChromeDriver();
        string munkatárs = "dmsdba";
        string password = "1234";
        string db = "KRXProxmox eles teszt 3";

        string lejelentés1 = "";
        string lejelentés2 = "";
        string ütem1 = "1";
        string ütem2 = "1";
        string maradék1 = "36";
        string selejt = "2";
        //Gyártási idő 1=1sec, 60=1 perc
        int gyTime1 = 12;
        int gyTime2 = 60;
        //formátum: "yyyy. mm. dd."
        string dátum = "2024. 07. 15.";

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
            SeleniumMethods.EnterText("userName", munkatárs, PropertyTypes.Id, driver);
            LogWriterT.WriteLog(folderpath, testname, "felhasználónév beírva");
            SeleniumMethods.TakePrtsc(folderpath, testname,driver);

            // Jelszó beírás
            SeleniumMethods.EnterText("passwordText", password, PropertyTypes.Id, driver);
            LogWriterT.WriteLog(folderpath, testname, "password beírva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            // DB kiválasztás
            SeleniumMethods.SelectDropDown("connection", db, PropertyTypes.Name,driver);
            LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            // Bejelentkezés)
            SeleniumMethods.Click("button.btn.btn-info.bold.text-uppercase.element-margin-bottom", PropertyTypes.CssSelector,driver);
            LogWriterT.WriteLog(folderpath, testname, "bejelentkezés elindítva");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

            // gyártáskövetés felület kiválasztás
            SeleniumMethods.SelectDropDown("gyártáskövetés", db, PropertyTypes.Name, driver);
            LogWriterT.WriteLog(folderpath, testname, "gyártáskövetés felület kiválasztás");
            SeleniumMethods.TakePrtsc(folderpath, testname, driver);

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }


}


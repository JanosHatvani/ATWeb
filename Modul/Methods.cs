using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Modules
{

    public class SeleniumMethods
    {
    public void TakePrtsc(string FolderPath, string TestName)
    {
        Screenshot prtSc = ((ITakesScreenshot)WebDriver.driver).GetScreenshot();
        string title = TestName;
        string picName = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
        string screenshotfilename = FolderPath + picName + ".png";
        try
        {
            prtSc.SaveAsFile(screenshotfilename, OpenQA.Selenium.ScreenshotImageFormat.Png);
            //WaitTime.Wait(1);
        }
        catch
        {
            throw new ArgumentException("A kép készítése nem teljesült.A kép készítéshez szükséges valamely paraméter nem került megadásra vagy nem áll rendelkezésre.(mappa)");
        }
    }
    public static void Wait(int time)
        {
            WebDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

    //elementbe írás
    public static void EnterText(string element, string value, PropertyTypes elementtype)
        {
            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Valamely paraméter nem került megadásra");
            }
            try
            {
                if (elementtype == PropertyTypes.Id)
                {
                    WebDriver.driver.FindElement(By.Id(element)).SendKeys(value);
                }
                if (elementtype == PropertyTypes.Name)
                {
                    WebDriver.driver.FindElement(By.Name(element)).SendKeys(value);
                }
                if (elementtype == PropertyTypes.LinkText)
                {
                    WebDriver.driver.FindElement(By.LinkText(element)).SendKeys(value);
                }
                if (elementtype == PropertyTypes.ClassName)
                {
                    WebDriver.driver.FindElement(By.ClassName(element)).SendKeys(value);
                }
                if (elementtype == PropertyTypes.TagName)
                {
                    WebDriver.driver.FindElement(By.TagName(element)).SendKeys(value);
                }
                if (elementtype == PropertyTypes.Xpath)
                {
                    WebDriver.driver.FindElement(By.XPath(element)).SendKeys(value);
                }
                if (elementtype == PropertyTypes.CssSelector)
                {
                    WebDriver.driver.FindElement(By.CssSelector(element)).SendKeys(value);
                }
            }
            catch (TimeoutException)
            {
                new WebDriverException("The operation has timed out.");
                
                //System.Windows.Forms.MessageBox.Show("A clickelés nem történt meg határidőn belül");
            }
            catch (NoSuchElementException exp)
            {
                throw exp;
            }

        }
        //Click valamely elementre!
        public static void Click(string element, PropertyTypes elementtype)
        {
            if (elementtype == PropertyTypes.Id)
            {
                WebDriver.driver.FindElement(By.Id(element)).Click();
            }
            if (elementtype == PropertyTypes.Name)
            {
                WebDriver.driver.FindElement(By.Name(element)).Click();
            }
            if (elementtype == PropertyTypes.LinkText)
            {
                WebDriver.driver.FindElement(By.LinkText(element)).Click();
            }
            if (elementtype == PropertyTypes.ClassName)
            {
                WebDriver.driver.FindElement(By.ClassName(element)).Click();
            }
            if (elementtype == PropertyTypes.TagName)
            {
                WebDriver.driver.FindElement(By.TagName(element)).Click();
            }
            if (elementtype == PropertyTypes.Xpath)
            {
                WebDriver.driver.FindElement(By.XPath(element)).Click();
            }
            if (elementtype == PropertyTypes.CssSelector)
            {
                WebDriver.driver.FindElement(By.CssSelector(element)).Click();
            }
          
        }
        //Selecting
        public static void SelectDropDown(string element, string value, PropertyTypes elementtype)
        {
            if (elementtype == PropertyTypes.Id)
            {
                new SelectElement(WebDriver.driver.FindElement(By.Id(element))).SelectByText(value);
            }
            if (elementtype == PropertyTypes.Name)
            {
                new SelectElement(WebDriver.driver.FindElement(By.Name(element))).SelectByText(value);
            }
            if (elementtype == PropertyTypes.LinkText)
            {
                new SelectElement(WebDriver.driver.FindElement(By.LinkText(element))).SelectByText(value);
            }
            if (elementtype == PropertyTypes.ClassName)
            {
                new SelectElement(WebDriver.driver.FindElement(By.ClassName(element))).SelectByText(value);
            }
            if (elementtype == PropertyTypes.TagName)
            {
                new SelectElement(WebDriver.driver.FindElement(By.TagName(element))).SelectByText(value);
            }
            if (elementtype == PropertyTypes.Xpath)
            {
                new SelectElement(WebDriver.driver.FindElement(By.XPath(element))).SelectByText(value);
            }
            if (elementtype == PropertyTypes.CssSelector)
            {
                new SelectElement(WebDriver.driver.FindElement(By.CssSelector(element))).SelectByText(value);
            }
            
            
        }
        public static void Clear(string element, PropertyTypes elementtype)
        {
            if (elementtype == PropertyTypes.Id)
            {
                WebDriver.driver.FindElement(By.Id(element)).Clear();
            }
            if (elementtype == PropertyTypes.Name)
            {
                WebDriver.driver.FindElement(By.Name(element)).Clear();
            }
            if (elementtype == PropertyTypes.LinkText)
            {
                WebDriver.driver.FindElement(By.LinkText(element)).Clear();
            }
            if (elementtype == PropertyTypes.ClassName)
            {
                WebDriver.driver.FindElement(By.ClassName(element)).Clear();
            }
            if (elementtype == PropertyTypes.TagName)
            {
                WebDriver.driver.FindElement(By.TagName(element)).Clear();
            }
            if (elementtype == PropertyTypes.Xpath)
            {
                WebDriver.driver.FindElement(By.XPath(element)).Clear();
            }
            if (elementtype == PropertyTypes.CssSelector)
            {
                WebDriver.driver.FindElement(By.CssSelector(element)).Clear();
            }
            
        }
        
        
    }
}


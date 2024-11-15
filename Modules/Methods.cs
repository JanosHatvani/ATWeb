using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Modules;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Modules
{
    public class SeleniumMethods
    {
        public static int MaxWaitTime { get; private set; } = 20;

        //ez a keresés eredményét adja át egyből.
        private static IWebElement FindElementBy(string element, PropertyTypes elementtype, IWebDriver driver)
        {
            return elementtype switch
            {
                PropertyTypes.Id => driver.FindElement(By.Id(element)),
                PropertyTypes.Name => driver.FindElement(By.Name(element)),
                PropertyTypes.LinkText => driver.FindElement(By.LinkText(element)),
                PropertyTypes.ClassName => driver.FindElement(By.ClassName(element)),
                PropertyTypes.TagName => driver.FindElement(By.TagName(element)),
                PropertyTypes.Xpath => driver.FindElement(By.XPath(element)),
                PropertyTypes.CssSelector => driver.FindElement(By.CssSelector(element)),
                _ => throw new NoSuchElementException($"Az element nem található: {element}")
            };
        }

        // a keresési feltétel átadás szükséges, hogy az wait.untilnak ez is átadásra kerüljön, ne csak a keresés eredménye.
        private static By GetByLocator(string element, PropertyTypes elementType)
        {
            return elementType switch
            {
                PropertyTypes.Id => By.Id(element),
                PropertyTypes.Name => By.Name(element),
                PropertyTypes.LinkText => By.LinkText(element),
                PropertyTypes.ClassName => By.ClassName(element),
                PropertyTypes.TagName => By.TagName(element),
                PropertyTypes.Xpath => By.XPath(element),
                PropertyTypes.CssSelector => By.CssSelector(element),
                _ => throw new NoSuchElementException($"Az element nem található: {element}")
            };
        }

        public static void TakePrtsc(string folderPath, string testName, IWebDriver driver)
        {
            Screenshot prtSc = ((ITakesScreenshot)driver).GetScreenshot();
            string pictureName = $"{testName}_{DateTime.Now:yyyy-MM-dd-HH_mm_ss}.png";
            string screenshotfilename = Path.Combine(folderPath, pictureName);

            try
            {
                prtSc.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Hibára futott a kép készítése.", ex);
            }
        }

        public static void EnterText(string element, string value, PropertyTypes elementType, IWebDriver driver)
        {
            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Nem került megadásra element vagy érték.");
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                var searchelement = FindElementBy(element, elementType, driver);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
                searchelement.SendKeys(value);
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A szöveg beírása időtúllépésre futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
            catch (ElementNotInteractableException ex)
            {
                throw new WebDriverException("Az element nem kattintható.", ex);
            }
        }

        public static void Click(string element, PropertyTypes elementType, IWebDriver driver)
        {
            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Nem került megadásra element.");
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(MaxWaitTime));

            try
            {
                By locator = GetByLocator(element, elementType);
                IWebElement searchelement = driver.FindElement(locator);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
                searchelement.Click();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A kattintás időtúllépésre futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
            catch (ElementNotInteractableException ex)
            {
                throw new WebDriverException("Az element nem kattintható.", ex);
            }
        }


        public static void SelectDropDown(string element, string value, PropertyTypes elementType, IWebDriver driver)
        {
            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Nem került megadásra element vagy érték.");
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                var searchelement = FindElementBy(element, elementType, driver);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
                SelectElement selectElement = new SelectElement(searchelement);
                selectElement.SelectByText(value);
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A legördülő lista kiválasztása időtúllépésre futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
            catch (ElementNotInteractableException ex)
            {
                throw new WebDriverException("Az element nem kattintható.", ex);
            }
        }

        public static void Clear(string element, PropertyTypes elementType, IWebDriver driver)
        {
            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Nem került megadásra element.");
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                var searchelement = FindElementBy(element, elementType, driver);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
                searchelement.Clear();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("Az elem törlése időtúllépésre futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
            catch (ElementNotInteractableException ex)
            {
                throw new WebDriverException("Az element nem kattintható.", ex);
            }
        }

        public static void DoubleClick(string element, PropertyTypes elementType, IWebDriver driver)
        {
            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Nem került megadásra element.");
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                var elementW = FindElementBy(element, elementType, driver);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));

                Actions action = new Actions(driver);
                action.DoubleClick(elementW).Perform();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A dupla kattintás időtúllépésre futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
            catch (ElementNotInteractableException ex)
            {
                throw new WebDriverException("Az element nem kattintható.", ex);
            }
        }

    }
}

//public static void EnterText(string element, string value, PropertyTypes elementtype, IWebDriver driver)
//{
//    if (string.IsNullOrEmpty(element)) throw new ArgumentException("Element is not specified");
//    if (value == null) throw new ArgumentNullException(nameof(value));
//    if (driver == null) throw new WebDriverException("WebDriver nem kerül inicializálásra.");

//    try
//    {
//        IWebElement searchelement = FindElementBy(element, elementtype, driver);
//        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//        searchelement.SendKeys(value);
//    }
//    catch (Exception ex)
//    {
//        throw new WebDriverException("Hibára futott a szöveg beírása.", ex);
//    }
//}

//public static void Click(string element, PropertyTypes elementtype, IWebDriver driver)
//{
//    if (string.IsNullOrEmpty(element)) throw new ArgumentException("Element nincs specializálva.");

//    try
//    {
//        IWebElement searchelement = FindElementBy(element, elementtype, driver);
//        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//        searchelement.Click();
//    }
//    catch (Exception ex)
//    {
//        throw new WebDriverException("Az element click hibára futott.", ex);
//    }
//}

//public static void SelectDropDown(string element, string value, PropertyTypes elementtype, IWebDriver driver)
//{
//    if (string.IsNullOrEmpty(element)) throw new ArgumentException("Element nincs specializálva.");

//    try
//    {
//        IWebElement searchelement = FindElementBy(element, elementtype, driver);
//        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//        SelectElement selectElement = new SelectElement(searchelement);
//        selectElement.SelectByText(value);
//    }
//    catch (Exception ex)
//    {
//        throw new WebDriverException("A selecct dropdown hibára futott.", ex);
//    }
//}

//public static void Clear(string element, PropertyTypes elementtype, IWebDriver driver)
//{
//    if (string.IsNullOrEmpty(element)) throw new ArgumentException("Element nincs specializálva.");

//    try
//    {
//        IWebElement searchelement = FindElementBy(element, elementtype, driver);
//        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//        searchelement.Clear();
//    }
//    catch (Exception ex)
//    {
//        throw new WebDriverException("A megadott element clear hibára futott.", ex);
//    }
//}

//public static void DoubleClick(string element, PropertyTypes elementtype, IWebDriver driver)
//{
//    if (string.IsNullOrEmpty(element)) throw new ArgumentException("Element nincs specializálva.");

//    try
//    {
//        IWebElement elementW = FindElementBy(element, elementtype, driver);
//        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));

//        Actions action = new Actions(driver);
//        action.DoubleClick(elementW).Perform();
//    }
//    catch (Exception ex)
//    {
//        throw new WebDriverException("A double-click hibára futott.", ex);
//    }
//}


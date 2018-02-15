using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRTechTest.extensionMethods
{
    public static class ExtensionMethods
    {
        public static IWebElement GetBody(this IWebDriver driver)
        {
            IWebElement body = driver.FindElement(By.TagName("body"));
            return body;
        }

        public static void XClear(this IWebDriver driver, String xpath)
        {
            driver.FindElement(By.XPath(xpath)).Clear();
        }

        public static void XClick(this IWebDriver driver, String xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }

        public static int XCount(this IWebDriver driver, String xpath)
        {
            return driver.FindElements(By.XPath(xpath)).Count();
        }

        public static void XEnter(this IWebDriver driver, String xpath)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(Keys.Enter);
        }

        public static string XGetValue(this IWebDriver driver, String xpath)
        {
            string outtext = driver.FindElement(By.XPath(xpath)).GetAttribute("value");
            return outtext;
        }

        public static void XHover(this IWebDriver driver, String xpath)
        {
            IWebElement element = driver.FindElement(By.XPath(xpath));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public static void XSet(this IWebDriver driver, String xpath, String text)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(text);
        }
    }
}

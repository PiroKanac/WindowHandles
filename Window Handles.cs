using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentBrowsers
{
    class EntryPoint
    {
        static void Main(string[] args)
        {

            List<string> handles = new List<string>();
            //Change size

           /* Size size = new Size();
            size.Width = 600;
            size.Height = 600; */

            // Change position

           /* Point position = new Point();
            position.X = 0;
            position.Y = 0; */

            //IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new InternetExplorerDriver();
            IWebDriver driver = new ChromeDriver();

            /*  Console.WriteLine(driver.GetType().ToString());
              Console.WriteLine(driver.GetType().ToString());

              if (driver.GetType().ToString().Contains("InternetExplorer"))
              {
                  driver.Navigate().GoToUrl("http://google.com");
              }
              else if (driver.GetType().ToString().Contains("Chrome"))
              {
                  driver.Navigate().GoToUrl("http://gmail.com");
              } */

            /* driver.Manage().Window.Size = size;
             driver.Manage().Window.Position = position;*/

            IWebElement newTab;
            IWebElement newWindow;

            string url = "http://testing.todvachev.com/tabs-and-windows/new-tab/";
            string newTabSelector = "#post-182 > div > p:nth-child(1) > a:nth-child(1)";
            string newWindowSelector = "#post-182 > div > p:nth-child(1) > a:nth-child(3)";


            driver.Navigate().GoToUrl(url);

            newTab = driver.FindElement(By.CssSelector(newTabSelector));
            newWindow = driver.FindElement(By.CssSelector(newWindowSelector));

            newTab.Click();

            handles = driver.WindowHandles.ToList();

            for(int i = 0; i < handles.Count; i++)
            {
                Console.WriteLine(handles[i]);                     //print all the handles
            }

            driver.SwitchTo().Window(handles[1]);                       //change handles
            Console.WriteLine("Switch to second handle" + driver.CurrentWindowHandle);
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium");

            driver.SwitchTo().Window(handles[0]);                   //change back to first handle
            Console.WriteLine("Switch to first handle" + driver.CurrentWindowHandle);

            IWebElement searchBoxtwo = driver.FindElement(By.Name("username"));
           
            searchBoxtwo.SendKeys("Selenium");
        }
    }
}

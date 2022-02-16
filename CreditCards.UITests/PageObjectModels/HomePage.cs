using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlog.UITests.PageObjectModels
{
    public class HomePage
    {
        private readonly IWebDriver Driver;
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public ReadOnlyCollection<IWebElement> QuestionTags 
        {
            get
            {
                return Driver.FindElements(By.ClassName("tags"));
            }
        }
    }
}

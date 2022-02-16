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

        public ReadOnlyCollection<string> QuestionTags
        {
            get
            {
                var tags = new List<string>();
                
                var tagElements = Driver.FindElements(By.ClassName("tags"));

                for(int i = 0; i < tagElements.Count; i++)
                {
                    tags.Add(tagElements[i].Text);
                }

                return tags.AsReadOnly();
            }
        }
    }
}

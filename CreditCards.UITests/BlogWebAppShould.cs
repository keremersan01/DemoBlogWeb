using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace CreditCards.UITests
{
    public class BlogWebAppShould
    {

        private const string HomeUrl = "https://localhost:44303/";
        private const string HomeTitle = "Home Page - DemoBlogWeb";
        private const string AskQuestionUrl = "https://localhost:44303/Home/CreateQuestion";


        [Fact]
        [Trait("Category","Smoke")] // Smoke category is used for basic tests. 
        // smoke name comes from if application breaks, smokes goes out. 
        public void LoadHomePage()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);


                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")] // Smoke category is used for basic tests. 
        // smoke name comes from if application breaks, smokes goes out. 
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                driver.Navigate().Refresh();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")] // Smoke category is used for basic tests. 
        // smoke name comes from if application breaks, smokes goes out. 
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                IWebElement qtagElement = driver.FindElement(By.Id("qtag"));
                string elementName = qtagElement.Text;

                driver.Navigate().GoToUrl(AskQuestionUrl);
                driver.Navigate().Back();

                

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

                string reloadedQTagElement = driver.FindElement(By.Id("qtag")).Text;
                Assert.Equal(elementName, reloadedQTagElement);

                // TODO assert that page was reloaded.
            }
        }

        [Fact]
        [Trait("Category","Smoke")]
        public void ReloadHomePageOnForward()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(AskQuestionUrl);
                driver.Navigate().GoToUrl(HomeUrl);

                driver.Navigate().Back();
                driver.Navigate().Forward();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

                // TODO assert that page was reloaded.
            }
        }
    }
}

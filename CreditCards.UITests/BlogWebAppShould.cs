using DemoBlog.UITests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace CreditCards.UITests
{
    public class BlogWebAppShould
    {

       
        private const string HomeTitle = "Home Page - DemoBlogWeb";
        private const string AskQuestionUrl = "https://localhost:44303/Home/CreateQuestion";
        private const string HomeUrl = "https://localhost:44303/";


        [Fact]
        [Trait("Category","Smoke")] // Smoke category is used for basic tests. 
        // smoke name comes from if application breaks, smokes goes out. 
        public void LoadHomePage()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                driver.Manage().Window.Maximize();
                driver.Manage().Window.Minimize();

                driver.Manage().Window.Size = new System.Drawing.Size(150, 150);

                driver.Manage().Window.Position = new System.Drawing.Point(1, 1);
                driver.Manage().Window.Position = new System.Drawing.Point(50, 50);
                driver.Manage().Window.Position = new System.Drawing.Point(100, 100);

                driver.Manage().Window.FullScreen();

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
        [Fact]
        public void SelectingMultipleElements_FromHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                HomePage homePage = new HomePage(driver);

                homePage.NavigateTo();
     

                Assert.Equal("c++", homePage.QuestionTags[0]);
                Assert.Equal("python", homePage.QuestionTags[1]);
                Assert.Equal("c++", homePage.QuestionTags[2]);

            }
        }
    }
}

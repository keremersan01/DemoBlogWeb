using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace CreditCards.UITests
{
    public class BlogAskQuestionShould
    {
        private const string HomeUrl = "https://localhost:44303/";
        private const string askQuestionUrl = "https://localhost:44303/Home/CreateQuestion";
        private const string FirstQuestionUrl = "https://localhost:44303/Home/Question/1";

        [Fact]
        [Trait("Category","Application")]
        public void BeInitiatedFromHomePageByName_AskQuestion()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement askQuestionButton = driver.FindElement(By.Name("askQuestionButton"));
                askQuestionButton.Click();

                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByLinkText_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement askQuestionButton = driver.FindElement(By.LinkText("Ask Question"));
                askQuestionButton.Click();

                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByClassName_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement questionTitle = driver.FindElement(By.ClassName("questions")); // it returns first matching question element
                questionTitle.Click();

                Assert.Equal("Question - DemoBlogWeb", driver.Title);
                Assert.Equal(FirstQuestionUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByPartialLinkText_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement askQuestionButton = driver.FindElement(By.PartialLinkText("uestion"));
                askQuestionButton.Click();

                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePageByXPath_AskQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                IWebElement askQuestionButton = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/a"));
                askQuestionButton.Click();

                Assert.Equal("CreateQuestion - DemoBlogWeb", driver.Title);
                Assert.Equal(askQuestionUrl, driver.Url);
            }
        }
    }
}

using FluentAssertions;
using TechTalk.SpecFlow;
using WebMagic.Specifications.Infrastructure;

namespace WebMagic.Specifications.Steps
{
    [Binding]
    public class ServeMarkdownFilesSteps : StepsBase
    {
        [Given(@"the website is a '(.*)'")]
        public void GivenTheWebsiteIsA(string websiteType)
        {
            OpenWebsite("Markdown", websiteType);
        }

        [When(@"I visit '(.*)'")]
        public void WhenIVisit(string url)
        {
            Website.GoTo(url);
        }

        [Then(@"the page should include '(.*)'")]
        public void ThenThePageShouldInclude(string expectedInPageSource)
        {
            WebDriver.PageSource.Should().Contain(expectedInPageSource);
        }

        [Then(@"the page is rendered with a layout page")]
        public void ThenThePageIsRenderedWithALayoutPage()
        {
            WebDriver.PageSource.Should().Contain("<html");
        }
    }
}

using FluentAssertions;
using TechTalk.SpecFlow;
using WebMagic.Repository;
using WebMagic.Specifications.Infrastructure;

namespace WebMagic.Specifications.Steps
{
    [Binding]
    public class WebDirectoryRepositorySteps : StepsBase
    {
        private bool ActualResult;
        private WebDirectoryRepository WebDirectoryRepository;

        [Given(@"WebDirectoryRepository\((.*)\)")]
        public void GivenWebDirectoryRepository(string rootDirectory)
        {
            WebDirectoryRepository = new WebDirectoryRepository(rootDirectory);
        }

        [When(@"I call WebDirectoryRepository\.DirectoryExists\((.*)\)")]
        public void WhenICallWebDirectoryRepository(string directory)
        {
            if (directory == "string.Empty")
            {
                directory = string.Empty;
            }

            ActualResult = WebDirectoryRepository.DirectoryExists(directory);
        }

        [Then(@"(.*) boolean should be returned")]
        public void ThenFalseBooleanShouldBeReturned(bool expectedResult)
        {
            expectedResult.Should().Be(ActualResult);
        }
    }
}



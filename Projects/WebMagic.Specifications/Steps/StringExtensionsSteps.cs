using FluentAssertions;
using TechTalk.SpecFlow;
using WebMagic.Specifications.Infrastructure;

namespace WebMagic.Specifications.Steps
{
    [Binding]
    public class StringExtensionsSteps : StepsBase
    {
        private string ActualString;

        [When(@"I call (.*)\.AddLeadingDot\(\)")]
        public void WhenICallAddLeadingDot(string thisString)
        {
            ActualString = thisString.AddLeadingDot();
        }

        [When(@"I call (.*)\.RemoveLeadingDot\(\)")]
        public void WhenICallRemoveLeadingDot(string thisString)
        {
            ActualString = thisString.RemoveLeadingDot();
        }

        [Then(@"(.*) string should be returned")]
        public void ThenStringShouldBeReturned(string expectedString)
        {
            ActualString.Should().Be(expectedString);
        }
    }
}

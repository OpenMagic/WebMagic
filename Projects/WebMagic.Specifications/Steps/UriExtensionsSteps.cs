using System;
using FluentAssertions;
using TechTalk.SpecFlow;
using WebMagic.Specifications.Infrastructure;

namespace WebMagic.Specifications.Steps
{
    [Binding]
    public class UriExtensionsSteps : StepsBase
    {
        private Uri ActualUri;

        [When(@"I call Uri\.Combine\((.*), (.*)\)")]
        public void WhenICallUri_Combine(string thisUri, string url)
        {
            ActualUri = new Uri(thisUri).Combine(url);
        }

        [Then(@"(.*) Uri should be returned")]
        public void ThenUriShouldBeReturned(string expectedUri)
        {
            ActualUri.Should().Be(new Uri(expectedUri));
        }
    }
}

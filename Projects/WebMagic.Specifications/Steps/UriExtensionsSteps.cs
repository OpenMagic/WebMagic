﻿using System;
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
        public void WhenICallUri_Combine(string uriString, string url)
        {
            ActualUri = new Uri(uriString).Combine(url);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedUri)
        {
            ActualUri.Should().Be(new Uri(expectedUri));
        }
    }
}

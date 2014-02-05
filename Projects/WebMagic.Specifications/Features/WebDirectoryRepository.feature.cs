﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34003
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace WebMagic.Specifications.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class WebDirectoryRepositoryFeature : Xunit.IUseFixture<WebDirectoryRepositoryFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WebDirectoryRepository.feature"
#line hidden
        
        public WebDirectoryRepositoryFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WebDirectoryRepository", "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(WebDirectoryRepositoryFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.Extensions.TheoryAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "WebDirectoryRepository")]
        [Xunit.TraitAttribute("Description", "DirectoryExists(directory) always returns false")]
        [Xunit.Extensions.InlineDataAttribute(".\\", "abc", "false", new string[0])]
        [Xunit.Extensions.InlineDataAttribute(".\\", "string.Empty", "false", new string[0])]
        public virtual void DirectoryExistsDirectoryAlwaysReturnsFalse(string rootDirectory, string directory, string expected, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DirectoryExists(directory) always returns false", exampleTags);
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
 testRunner.Given(string.Format("WebDirectoryRepository({0})", rootDirectory), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
 testRunner.When(string.Format("I call WebDirectoryRepository.DirectoryExists({0})", directory), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 6
 testRunner.Then(string.Format("{0} boolean should be returned", expected), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                WebDirectoryRepositoryFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                WebDirectoryRepositoryFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion

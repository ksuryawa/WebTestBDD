using System;
using BoDi;
using TechTalk.SpecFlow;
using WebTestBDD.Drivers;

namespace WebTestBDD.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            //Initialize a shared BrowserDriver in the global container
            testThreadContainer.BaseContainer.Resolve<BrowserDriver>();
        }
    }
}
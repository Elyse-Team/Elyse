using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elyse.Languagetool;

namespace Languagetool.Tests
{
    [TestClass]
    public class Languagetool
    {
        [TestMethod]
        public void GetErrors_withErrorMatches_returnErrors()
        {
            Elyse.Languagetool.Languagetool ltool = new Elyse.Languagetool.Languagetool("http://localhost:8081/");

        }
    }
}

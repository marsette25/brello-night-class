using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;

namespace Brello.Tests.Models
{
    [TestClass]
    public class BrelloListTests
    {
        [TestMethod]
        public void BrelloListEnsureICanCreateInstance() //could have been an interface or something else rather than an instance
        {
            BrelloList brello_list = new BrelloList();
            Assert.IsNotNull(brello_list);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;
using Moq;

namespace Brello.Tests.Models
{
    [TestClass]
    public class BoardServiceTests
    {
        [TestMethod]
        public void BoardServiceEnsureICAnCreateInstance()
        {
            var some_context = new Mock<BoardContext>();
            BoardService board = new BoardService(some_context.Object);
            Assert.IsNotNull(board);
        }
    }
}

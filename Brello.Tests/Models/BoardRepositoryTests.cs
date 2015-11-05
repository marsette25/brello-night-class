﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Brello.Tests.Models
{
    [TestClass]
    public class BoardRepositoryTests
    {
        [TestMethod]
        public void BoardRepositoryEnsureICanCreateInstance()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board = new BoardRepository(some_context.Object);
            Assert.IsNotNull(board);
        }
        
        [TestMethod]
        public void BoardRepositoryEnsureICanAddAList()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(some_context.Object);
            BrelloList list = new BrelloList();
            Board board = new Board();

            bool actual = board_repo.AddList(board, list);

            Assert.AreEqual(1, board_repo.GetAllLists().Count);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void BoardRepositoryEnsureThereAreZeroLists()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(some_context.Object);
            
            int expected = 0;
            int actual = board_repo.GetAllLists().Count;
            Assert.AreEqual(expected, actual);
            
        }

        // These tests are telling us to start looking at
        // How to define CRUD operations for Boards
        // Why? Because a List cannot exists without a Board
        [TestMethod]
        public void BoardRepositoryEnsureABoardHasZeroLists()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(some_context.Object);
            Board board = new Board();
            int expected = 0;
            Assert.AreEqual(expected, board_repo.GetAllLists(board).Count);
        }

        [TestMethod]
        public void BoardRepositoryCanGetABoard()
        {

        }

        [TestMethod]
        public void BoardRepositoryCanCreateBoard()
        {
            var mock_context = new Mock<BoardContext>();
            var mock_boards = new Mock<DbSet<Board>>();
            // One way to call an object underneath a mock.
            //mock_context.Object.Boards

            mock_context.Setup(m => m.Boards).Returns(mock_boards.Object);

            BoardRepository board_repo = new BoardRepository(mock_context.Object);
            string title = "My Awesome Board";
            ApplicationUser owner = new ApplicationUser();
            Board added_board = board_repo.CreateBoard(title, owner);
            Assert.IsNotNull(added_board);

            mock_boards.Verify(m => m.Add(It.IsAny<Board>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Once());
            Assert.AreEqual(1, mock_context.Object.Boards.CountAsync());
        }

        [TestMethod]
        public void BoardRepositoryEnsureICanGetAllBoards()
        {
            var mock_context = new Mock<BoardContext>();
            var mock_boards = new Mock<DbSet<Board>>();

            ApplicationUser owner = new ApplicationUser();
            //Board my_board = new Board { Title = "My Board", Owner = owner };
            //List<Board> data = new List<Board>();
            //1. Your data must be queryable
            //2. Mocks can only cast to an interface(e.g. IQueryable, IDbSEt, etc.)
            //3. You must ensure Provider, GetEnumerator(), ElemetnType, and Expression are defined
            //   with your collection class (the container class that holds your data).
            

            //

            // a var called data is a new list that contains two instances of a board
            var data = new List<Board>{
                new Board { Title = "My Awesome Board", Owner = owner },
                new Board { Title = "My Other Awesome Board", Owner = owner }
            }.AsQueryable(); //asqueryable casts the list type to something that can be queried as if it were in a DB

            //we took the db set boards to what it inherited from (ienuamerable and iqueryable
            // we cast boards and using iqueryable, we took the list
            //expressed as something queryable and defined its provider, etc... because these are availabe in the queryable class

            mock_boards.As<IQueryable<Board>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_boards.As<IQueryable<Board>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_context.Setup(m => m.Boards).Returns(mock_boards.Object);

            BoardRepository board_repo = new BoardRepository(mock_context.Object);
           
            /*
            board_repo.CreateBoard("My Awesome Board", owner);
            board_repo.CreateBoard("My Other Awesome Board", owner);
            */
            List<Board> boards = board_repo.GetAllBoards();
            Assert.AreEqual(2, boards.Count);


        }
    }
}

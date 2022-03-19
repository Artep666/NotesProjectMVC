using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ProjectNotes.Controllers;
using ProjectNotes.Data;
using ProjectNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNotes
{
    class Test01
    {
        //проверка на метода без мок и добавя в базата не се използва
        [TestCase]
        public void AddShouldNote()
        {
            var note = new Note("note", "This is very important;)!", 02_03_22);
            var context = new NoteContext();
            var controller = new NoteController(context);

            //controller.Add(note);

        }
        //if it adds a note
        //проверка за съвпадение по име
        [TestCase]
        public void GetAllNotes_orders_by_name()
        {
            //Arrange
            var data = new List<Note>
            {
                new Note ("BBB","kon",020321),
                new Note ("ZZZ","Kone",030222),
                new Note ("AAA","Konche",010120),
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Note>>();
            mockSet.As<IQueryable<Note>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Note>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Note>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Note>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NoteContext>();
            mockContext.Setup(c => c.Note).Returns(mockSet.Object);
            //Act
            var service = new NoteController(mockContext.Object);
            var note = service.Get(1);
            //Assert 
         
            Assert.AreEqual("k", note.Name);
           
        }
        //проверка на броя бележки
       
        [TestCase]
        public void GetAllNotesCount()
        {
            //Arrange
            var data = new List<Note>
            {
                new Note ("BBB","kon",020321),
                new Note ("ZZZ","Kone",030222),
                new Note ("AAA","Konche",010120),
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Note>>();
            mockSet.As<IQueryable<Note>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Note>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Note>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Note>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NoteContext>();
            mockContext.Setup(c => c.Note).Returns(mockSet.Object);
            //Act
            var service = new NoteController(mockContext.Object);
            var note = service.GetAll();
            //Assert 

            Assert.AreEqual(3, note.Count);

        }
    }
}

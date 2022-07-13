using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Experian;
using Experian.Controllers;
using Experian.Models;

namespace Experian.Tests.Controllers
{
    [TestClass]
    public class DateControllerTest
    {
        //[TestMethod]
        //public void Index()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}


        [TestMethod]
        public void yearTest()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("12/07/2022", 1);

            //Act
            var Result = customDateTest.GetYear();

            //Assert
            Assert.AreEqual(Result, 2022);


        }

        [TestMethod]
        public void MonthTest()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("12/07/2022", 1);

            //Act
            var Result = customDateTest.GetMonth();

            //Assert
            Assert.AreEqual(Result, 07);


        }

        [TestMethod]
        public void dayTest()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("12/07/2022", 1);

            //Act
            var Result = customDateTest.GetDay();

            //Assert
            Assert.AreEqual(Result, 12);


        }

        [TestMethod]
        public void leapYearTestTrue()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("12/07/2000", 1);

            //Act
            var Result = customDateTest.IsItLeapYear();

            //Assert
            Assert.AreEqual(Result, true);



        }

        [TestMethod]
        public void leapYearTestfalse()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("12/07/2007", 1);

            //Act
            var Result = customDateTest.IsItLeapYear();

            //Assert
            Assert.AreEqual(Result, false);


        }

        [TestMethod]
        public void AddDays()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("14/12/2016",10000);

            //Act
            var Result = customDateTest.AddDays();

            //Assert
            Assert.AreEqual(Result, "01/05/2044");


        }

        [TestMethod]
        public void AddDaysJan()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("01/01/2016", 60);

            //Act
            var Result = customDateTest.AddDays();

            //Assert
            Assert.AreEqual(Result, "01/03/2016");


        }

        [TestMethod]
        public void leadingZeroDay()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("01/01/2016",60);

            //Act
            var Result = customDateTest.addLeadingZeroToDay(12);

            //Assert
            Assert.AreEqual(Result, "12");


        }

        [TestMethod]
        public void leadingZeroMonth()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("14/12/2016", 10);

            //Act
            var Result = customDateTest.addLeadingZeroToMonth(8);

            //Assert
            Assert.AreEqual(Result, "08");


        }

        [TestMethod]
        public void AddDays_LastDayDEC()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("31/12/2001", 1);

            //Act
            var Result = customDateTest.AddDays();

            //Assert
            Assert.AreEqual(Result, "01/01/2002");


        }

        [TestMethod]
        public void  inavlidinput()
        {
            //Arrange 
            CustomDate customDateTest = new CustomDate("31/12/20", 1);

            //Act
            var Result = customDateTest.invalidInput();

            //Assert
            Assert.AreEqual(Result, "Inavlid year");


        }
    }
}

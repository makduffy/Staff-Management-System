using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing1
{
    [TestClass]
    public class tstStaff
    {
        String StaffEmail = "aaa@.a";
        String StaffName = "staff name";
        String DateCreated = DateTime.Now.Date.ToString();
        String Salary = "20000";

        [TestMethod]
        public void InstanceOK()
        {
            clsStaff AStaff = new clsStaff();
            Assert.IsNotNull(AStaff);
        }
        [TestMethod]
        public void StaffIDOK()
        {
            clsStaff AStaff = new clsStaff();
            int TestData = 1;
            AStaff.StaffID = TestData;
            Assert.AreEqual(AStaff.StaffID, TestData);
        }
        [TestMethod]
        public void StaffNameOK()
        {
            clsStaff AStaff = new clsStaff();
            String TestData = "Johnny Hill";
            AStaff.StaffName = TestData;
            Assert.AreEqual(AStaff.StaffName, TestData);

        }
        [TestMethod]
        public void IsAdminOK()
        {
            clsStaff AStaff = new clsStaff();
            Boolean TestData = true;
            AStaff.IsAdmin = TestData;
            Assert.AreEqual(AStaff.IsAdmin, TestData);
        }
        [TestMethod]
        public void DateCreatedOK()
        {
            clsStaff AStaff = new clsStaff();
            DateTime TestData = DateTime.Now.Date;
            AStaff.DateCreated = TestData;
            Assert.AreEqual(AStaff.DateCreated, TestData);
        }
        [TestMethod]
        public void SalaryOK()
        {
            clsStaff AStaff = new clsStaff();
            Int32 TestData = 35000;
            AStaff.Salary = TestData;
            Assert.AreEqual(AStaff.Salary, TestData);
        }

        [TestMethod]
        public void FindMethodOK()
        {
            clsStaff AStaff = new clsStaff();
            bool Found = false;
            Int32 StaffID = 1;
            Found = AStaff.Find(StaffID);
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestStaffIDFound()
        {
            clsStaff AStaff = new clsStaff();
            bool Found = false;
            bool OK = true;
            int StaffID = 1;
            Found = AStaff.Find(StaffID);
            if (AStaff.StaffID != 1)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestStaffEmailFound()
        {
            clsStaff AStaff = new clsStaff();
            bool Found = false;
            int StaffID = 1;
            Found = AStaff.Find(StaffID);

            Assert.AreEqual(AStaff.StaffEmail, "JohnnyHilly@Outlook.com");
        }

        [TestMethod]
        public void TestStaffNameFound()
        {
            clsStaff AStaff = new clsStaff();
            bool Found = false;
            int StaffID = 1;
            Found = AStaff.Find(StaffID);

            Assert.AreEqual(AStaff.StaffName, "Johnny Hill");
        }

        [TestMethod]
        public void TestIsAdminFound()
        {
            clsStaff AStaff = new clsStaff();
            bool Found = false;
            bool OK = true;
            int StaffID = 1;
            Found = AStaff.Find(StaffID);
            if (AStaff.IsAdmin != true)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestDateCreatedFound()
        {
            clsStaff AStaff = new clsStaff();
            bool Found = false;
            int StaffID = 1;
            Found = AStaff.Find(StaffID);

            DateTime expectedDate = new DateTime(2022, 12, 4);
            Assert.AreNotEqual(AStaff.DateCreated, expectedDate);
        }

        [TestMethod]
        public void TestSalaryFound()
        {
            clsStaff AStaff = new clsStaff();
            bool Found = false;
            int StaffID = 1;
            Found = AStaff.Find(StaffID);

            decimal expectedSalary = 50000.00M;
            Assert.AreEqual(AStaff.Salary, expectedSalary);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            clsStaff AStaff = new clsStaff();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffEmailMinLessOne()
        {
            clsStaff AStaff = new clsStaff();
            String StaffEmail = "";
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StaffEmailMin()
        {
            clsStaff AStaff = new clsStaff();
            String StaffEmail = "a";
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }


        [TestMethod]
        public void StaffEmailMinPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            String StaffEmail = "aa";
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffEmailMid()
        {
            clsStaff AStaff = new clsStaff();
            String StaffEmail = new String('a', 15);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffEmailMaxLessOne()
        {
            clsStaff AStaff = new clsStaff();
            String StaffEmail = new String('a', 29);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffEmailMax()
        {
            clsStaff AStaff = new clsStaff();
            String StaffEmail = new String('a', 30);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffEmailMaxPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            String StaffEmail = new String('a', 31);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StaffEmailExtremeMax()
        {
            clsStaff AStaff = new clsStaff();
            String StaffEmail = new string('a', 500);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void DateCreatedExtremeMin()
        {
            clsStaff AStaff = new clsStaff();
            DateTime TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddYears(-100);
            String DateCreated = TestDate.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateCreatedMinLessOne()
        {
            clsStaff AStaff = new clsStaff();
            DateTime TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddDays(-1);
            string DateCreated = TestDate.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateCreatedMin()
        {
            clsStaff AStaff = new clsStaff();
            DateTime TestDate = DateTime.Now.Date;
            String DateCreated = TestDate.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void DateCreatedMinPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            DateTime TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddDays(1);
            String DateCreated = TestDate.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateCreatedExtremeMax()
        {
            clsStaff AStaff = new clsStaff();
            DateTime TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddYears(100);
            String DateCreated = TestDate.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StaffNameMinLessOne()
        {
            clsStaff AStaff = new clsStaff();
            String StaffName = "";
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StaffNameMin()
        {
            clsStaff AStaff = new clsStaff();
            String StaffName = "a";
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }


        [TestMethod]
        public void StaffNameMinPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            String StaffName = "aa";
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffNameMid()
        {
            clsStaff AStaff = new clsStaff();
            String StaffName = new String('a', 25);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffNameMaxLessOne()
        {
            clsStaff AStaff = new clsStaff();
            String StaffName = new String('a', 49);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffNameMax()
        {
            clsStaff AStaff = new clsStaff();
            String StaffName = new String('a', 50);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffNameMaxPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            String StaffName = new String('a', 51);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StaffNameExtremeMax()
        {
            clsStaff AStaff = new clsStaff();
            String StaffName = new string('a', 500);
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void SalaryExtremeMinimum()
        {
            clsStaff AStaff = new clsStaff();
            Decimal ExtremeMinValue = -0.001m;
            String Salary = ExtremeMinValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual("", Error);
        }

        [TestMethod]
        public void SalaryMinimumLessOne()
        {
            clsStaff AStaff = new clsStaff();
            Decimal MinLessOneValue = -1m;
            String Salary = MinLessOneValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual("", Error);
        }

        [TestMethod]
        public void SalaryMinimum()
        {
            clsStaff AStaff = new clsStaff();
            Decimal MinValue = 0m;
            String Salary = MinValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual("", Error);
        }

        [TestMethod]
        public void SalaryMinimumPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            Decimal MinPlusOneValue = 1m;
            String Salary = MinPlusOneValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual("", Error);
        }

        [TestMethod]
        public void SalaryMiddle()
        {
            clsStaff AStaff = new clsStaff();
            Decimal MidValue = 5000000;
            String Salary = MidValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual("", Error);
        }

        [TestMethod]
        public void SalaryMaxLessOne()
        {
            clsStaff AStaff = new clsStaff();
            Decimal MaxLessOneValue = 9999999;
            String Salary = MaxLessOneValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual("", Error);
        }

        [TestMethod]
        public void SalaryMax()
        {
            clsStaff AStaff = new clsStaff();
            Decimal MaxValue = 10000000;
            String Salary = MaxValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreEqual("", Error);
        }

        [TestMethod]
        public void SalaryMaxPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            Decimal MaxPlusOneValue = 10000001;
            String Salary = MaxPlusOneValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual("", Error);
        }

        [TestMethod]
        public void SalaryExtremeMax()
        {
            clsStaff AStaff = new clsStaff();
            Decimal ExtremeValue = 99999999999;
            String Salary = ExtremeValue.ToString();
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual("", Error);
        }

        [TestMethod]
        public void DateCreatedInvalidData()
        {
            clsStaff AStaff = new clsStaff();
            String DateCreated = "A date was not inputted, please enter a valid date";
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void SalaryInvalidData()
        {
            clsStaff AStaff = new clsStaff();
            String Salary = "The Salary must only contain a decimal number";
            String Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
            Assert.AreNotEqual(Error, "");
        }




    }


}


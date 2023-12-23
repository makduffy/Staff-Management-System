using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Text;

namespace Testing1
{
    
    [TestClass]
    public class tstStaffCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            Assert.IsNotNull(AllStaff);
        }

        [TestMethod]
        public void StaffListOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            List<clsStaff> TestList = new List<clsStaff>();
            clsStaff TestItem = new clsStaff();
            TestItem.StaffID = 1;
            TestItem.IsAdmin = true;
            TestItem.StaffEmail = "aaaa@a.a";
            TestItem.StaffName = "John Jones";
            TestItem.Salary = 40000m;
            TestItem.DateCreated = DateTime.Now.Date;
            TestList.Add(TestItem);
            AllStaff.StaffList = TestList;
            Assert.AreEqual(AllStaff.StaffList, TestList);


        }

        [TestMethod]
        public void ThisPropertyOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestStaff = new clsStaff();
            TestStaff.StaffID = 1;
            TestStaff.IsAdmin = true;
            TestStaff.StaffEmail = "aaaa@a.a";
            TestStaff.StaffName = "John Jones";
            TestStaff.Salary = 40000m;
            TestStaff.DateCreated = DateTime.Now.Date;
            AllStaff.ThisStaff = TestStaff;
            Assert.AreEqual(AllStaff.ThisStaff, TestStaff);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            List<clsStaff> TestList = new List<clsStaff>();
            clsStaff TestItem = new clsStaff();
            TestItem.StaffID = 1;
            TestItem.IsAdmin = true;
            TestItem.StaffEmail = "aaaa@a.a";
            TestItem.StaffName = "John Jones";
            TestItem.Salary = 40000m;
            TestItem.DateCreated = DateTime.Now.Date;
            TestList.Add(TestItem);
            AllStaff.StaffList = TestList;
            Assert.AreEqual(AllStaff.StaffList, TestList);

        }
        
        [TestMethod]
        public void AddMethodOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestItem = new clsStaff();
            Int32 PrimaryKey = 0;
            TestItem.IsAdmin = true;
            TestItem.StaffEmail = "aaja@a.a";
            TestItem.StaffName = "John Jones";
            TestItem.Salary = 40000m;
            TestItem.DateCreated = DateTime.Now.Date;
            AllStaff.ThisStaff = TestItem;
            PrimaryKey = AllStaff.Add();
            TestItem.StaffID = PrimaryKey;
            AllStaff.ThisStaff.Find(PrimaryKey);
            Assert.AreEqual(AllStaff.ThisStaff, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {

            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestItem = new clsStaff();
            Int32 PrimaryKey = 0;
            TestItem.IsAdmin = true;
            TestItem.StaffEmail = "aaaa@a.a";
            TestItem.StaffName = "John Jones";
            TestItem.Salary = 40000m;
            TestItem.DateCreated = DateTime.Now.Date;
            AllStaff.ThisStaff = TestItem;
            PrimaryKey = AllStaff.Add();
            TestItem.StaffID = PrimaryKey;
            TestItem.IsAdmin = false;
            TestItem.StaffEmail = "aaba@a.a";
            TestItem.StaffName = "Bill Jones";
            TestItem.Salary = 50000m;
            TestItem.DateCreated = DateTime.Now.Date;
            AllStaff.ThisStaff = TestItem;
            AllStaff.Update();
            AllStaff.ThisStaff.Find(PrimaryKey);
            Assert.AreEqual(AllStaff.ThisStaff, TestItem);


        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestItem = new clsStaff();
            Int32 PrimaryKey = 0;
            TestItem.StaffID = 1;
            TestItem.IsAdmin = true;
            TestItem.StaffEmail = "aaaaa@a.a";
            TestItem.StaffName = "Jack Hill";
            TestItem.Salary = 500000m;
            TestItem.DateCreated = DateTime.Now.Date;
            AllStaff.ThisStaff = TestItem;
            PrimaryKey = AllStaff.Add();
            TestItem.StaffID = PrimaryKey;
            AllStaff.ThisStaff.Find(PrimaryKey);
            AllStaff.Delete();
            Boolean Found = AllStaff.ThisStaff.Find(PrimaryKey);
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByStaffNameMethodOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaffCollection FilteredStaff = new clsStaffCollection();
            FilteredStaff.ReportByStaffName("");
            Assert.AreEqual(AllStaff.Count, FilteredStaff.Count);
        }

        [TestMethod]
        public void ReportByStaffNameNoneFound()
        {
            clsStaffCollection FilteredStaff = new clsStaffCollection();
            FilteredStaff.ReportByStaffName("John");
            Assert.AreNotEqual(0, FilteredStaff.Count);
        }

        [TestMethod]
        public void ReportByStaffNameTestDataFound()
        {
            clsStaffCollection FilteredStaff = new clsStaffCollection();
            Boolean OK = true;
            FilteredStaff.ReportByStaffName("jack");
            if (FilteredStaff.Count == 2)
            {
                if (FilteredStaff.StaffList[0].StaffID != 10)
                {
                    OK = false;
                }
                if (FilteredStaff.StaffList[1].StaffID != 11)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }






    }
}

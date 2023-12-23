using System.Collections.Generic;
using ClassLibrary;
using System;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class clsStaffCollection
    {
        List<clsStaff> mStaffList = new List<clsStaff>();
        clsStaff mThisStaff = new clsStaff();
        public List<clsStaff> StaffList
        {
            get
            {
                return mStaffList;
            }
            set
            {
                mStaffList = value;
            }
        }
        public int Count
        {
            get
            {
                return mStaffList.Count;
            }
            set
            {
                //fill in later
            }
        }

        public clsStaff ThisStaff
        {
            get
            {
                return mThisStaff;
            }
            set
            {
                mThisStaff = value;
            }
        }

        public clsStaffCollection()
        {
            Int32 Index = 0;
            Int32 RecordCount = 0;
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblStaff_SelectAll");
            RecordCount = DB.Count;
            while (Index < RecordCount)
            {
                clsStaff AStaff = new clsStaff();
                AStaff.StaffID = Convert.ToInt32(DB.DataTable.Rows[Index]["StaffID"]);
                AStaff.Salary = Convert.ToDecimal(DB.DataTable.Rows[Index]["Salary"]);
                AStaff.StaffEmail = Convert.ToString(DB.DataTable.Rows[Index]["StaffEmail"]);
                AStaff.StaffName = Convert.ToString(DB.DataTable.Rows[Index]["StaffName"]);
                AStaff.IsAdmin = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsAdmin"]);
                AStaff.DateCreated = Convert.ToDateTime(DB.DataTable.Rows[Index]["DateCreated"]);
                mStaffList.Add(AStaff);
                Index++;
            }
        }
        public void ReportByStaffName(String StaffName)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffName", StaffName);
            DB.Execute("sproc_tblStaff_FilterByStaffName");
            PopulateArray(DB);
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffEmail", mThisStaff.StaffEmail);
            DB.AddParameter("@StaffName", mThisStaff.StaffName);
            DB.AddParameter("@Salary", mThisStaff.Salary);
            DB.AddParameter("@IsAdmin", mThisStaff.IsAdmin);
            DB.AddParameter("@DateCreated", mThisStaff.DateCreated);
            return DB.Execute("sproc_tblStaff_Insert");

        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffID", mThisStaff.StaffID);
            DB.AddParameter("@StaffEmail", mThisStaff.StaffEmail);
            DB.AddParameter("@StaffName", mThisStaff.StaffName);
            DB.AddParameter("@Salary", mThisStaff.Salary);
            DB.AddParameter("@IsAdmin", mThisStaff.IsAdmin);
            DB.AddParameter("@DateCreated", mThisStaff.DateCreated);
            DB.Execute("sproc_tblStaff_Update");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffID", mThisStaff.StaffID);
            DB.Execute("sproc_tblStaff_Delete");
        }

        void PopulateArray(clsDataConnection DB)
        {
            Int32 Index = 0;
            Int32 RecordCount;
            RecordCount = DB.Count;
            mStaffList = new List<clsStaff>();
            while (Index < RecordCount)
            {
                clsStaff aStaff = new clsStaff();
                aStaff.StaffID = Convert.ToInt32(DB.DataTable.Rows[Index]["StaffID"]);
                aStaff.StaffEmail = Convert.ToString(DB.DataTable.Rows[Index]["StaffEmail"]);
                aStaff.StaffName = Convert.ToString(DB.DataTable.Rows[Index]["StaffName"]);
                aStaff.Salary = Convert.ToDecimal(DB.DataTable.Rows[Index]["Salary"]);
                aStaff.DateCreated = Convert.ToDateTime(DB.DataTable.Rows[Index]["DateCreated"]);
                aStaff.IsAdmin = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsAdmin"]);
                mStaffList.Add(aStaff);
                Index++;
            }
        }
    }
}
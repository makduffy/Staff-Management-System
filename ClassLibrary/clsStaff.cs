using System;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class clsStaff


    {
        private int mStaffId;
        public int StaffID
        {
            get
            {
                return mStaffId;
            }
            set
            {
                mStaffId = value;
            }
        }

        private String mStaffName;
        public String StaffName
        {
            get
            {
                return mStaffName;
            }
            set
            {
                mStaffName = value;
            }
        }

        private bool mIsAdmin;
        public bool IsAdmin
        {
            get
            {
                return mIsAdmin;
            }
            set
            {
                mIsAdmin = value;
            }
        }
        private decimal mSalary;
        public decimal Salary
        {
            get
            {
                return mSalary;
            }
            set
            {
                mSalary = value;
            }
        }
        private DateTime mDateCreated;
        public DateTime DateCreated
        {
            get
            {
                return mDateCreated;
            }
            set
            {
                mDateCreated = value;
            }
        }
        private String mStaffEmail;
        public String StaffEmail
        {
            get
            {
                return mStaffEmail;
            }
            set
            {
                mStaffEmail = value;
            }
        }



        public bool Find(int Staffid)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffID", Staffid);
            DB.Execute("sproc_tblStaff_FilterByStaffID");
            if (DB.Count == 1)
            {
                mStaffId = Convert.ToInt32(DB.DataTable.Rows[0]["StaffID"]);
                mSalary = Convert.ToDecimal(DB.DataTable.Rows[0]["Salary"]);
                mStaffEmail = Convert.ToString(DB.DataTable.Rows[0]["StaffEmail"]);
                mStaffName = Convert.ToString(DB.DataTable.Rows[0]["StaffName"]);
                mIsAdmin = Convert.ToBoolean(DB.DataTable.Rows[0]["IsAdmin"]);
                mDateCreated = Convert.ToDateTime(DB.DataTable.Rows[0]["DateCreated"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public String Valid(String staffEmail, String staffName, String dateCreated, String salary)
        {
            DateTime DateTemp;
            Decimal Salary;
            String Error = "";
            if (staffEmail.Length == 0)
            {
                Error = Error + "The staff email may not be blank: ";
            }

            if (staffEmail.Length > 30)
            {
                Error = Error + "The staff email must be less than 30 characters: ";
            }
            try
            {
                DateTemp = Convert.ToDateTime(dateCreated);
                if (DateTemp < DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be in the past";
                }

                if (DateTemp > DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be in the future : ";
                }
            }

            catch
            {
                Error = Error + "The date was not a valid date: ";
            }

            if (staffName.Length == 0)
            {
                Error = Error + "The staff name may not be blank: ";
            }

            if (staffName.Length > 50)
            {
                Error = Error + "The staff name must be less than 50 characters: ";
            }

            try
            {
                Salary = Decimal.Parse(salary);
                if (Salary < 0)
                {
                    Error = "The salary must not be negative";
                }

                if(Salary > 10000000)
                {
                    Error = "The salary must not exceed 50000000";
                }
            }
            catch (FormatException)
            {
                Error += "The salary must be a valid decimal number.";
            }

            return Error;
        }
    }
}
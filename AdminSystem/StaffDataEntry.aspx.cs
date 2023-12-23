using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Text.RegularExpressions;

public partial class _1_DataEntry : System.Web.UI.Page
{
    Int32 StaffID;
    protected void Page_Load(object sender, EventArgs e)

    {
        StaffID = Convert.ToInt32(Session["StaffID"]);

        if (IsPostBack == false)
        {
            if (StaffID != -1)
            {
                DisplayStaff();
            }
        }

    }

    void DisplayStaff()
    {
        clsStaffCollection Staff = new clsStaffCollection();
        Staff.ThisStaff.Find(StaffID);
        txtStaffID.Text = Staff.ThisStaff.StaffID.ToString();
        txtStaffEmail.Text = Staff.ThisStaff.StaffEmail;
        txtStaffName.Text = Staff.ThisStaff.StaffName;
        txtSalary.Text = Staff.ThisStaff.Salary.ToString();
        txtDateCreated.Text = Staff.ThisStaff.DateCreated.ToString();
        chkIsAdmin.Checked = Staff.ThisStaff.IsAdmin;
    }
    protected void BtnOK_Click(object sender, EventArgs e)
    {

        clsStaff AStaff = new clsStaff();
        String StaffName = txtStaffName.Text;
        String StaffEmail = txtStaffEmail.Text;
        String Salary = txtSalary.Text;
        String DateCreated = txtDateCreated.Text;
        String Error = "";
        Error = AStaff.Valid(StaffEmail, StaffName, DateCreated, Salary);
        if (Error == "")
        {
            AStaff.StaffID = StaffID;
            AStaff.StaffEmail = StaffEmail;
            AStaff.StaffName = StaffName;
            AStaff.Salary = Convert.ToDecimal(Salary);
            AStaff.DateCreated = Convert.ToDateTime(DateCreated);
            AStaff.IsAdmin = chkIsAdmin.Checked;
            clsStaffCollection StaffList = new clsStaffCollection();

            if (StaffID == -1)
            {
                StaffList.ThisStaff = AStaff;
                StaffList.Add();
            }
            else
            {
                StaffList.ThisStaff.Find(StaffID);
                StaffList.ThisStaff = AStaff;
                StaffList.Update();
            }
            Response.Redirect("StaffList.aspx");

        }
        else
        {
            lblError.Text = Error;
        }

    }


    protected void btnFind_Click(object sender, EventArgs e)
    {
        clsStaff AStaff = new clsStaff();
        Int32 StaffID;
        bool Found = false;

        lblError.Text = "";
        if (Int32.TryParse(txtStaffID.Text, out StaffID))
        {
            Found = AStaff.Find(StaffID);
            if (Found == true)
            {
                txtStaffEmail.Text = AStaff.StaffEmail;
                txtStaffName.Text = AStaff.StaffName;
                txtDateCreated.Text = AStaff.DateCreated.ToString("dd/MM/yyyy");
                txtSalary.Text = AStaff.Salary.ToString();
                chkIsAdmin.Checked = AStaff.IsAdmin;
            }
            else
            {
                lblError.Text = "No Staff found with given StaffID";
            }
        }
        else
        {
            lblError.Text = "Please enter a valid Staff ID";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
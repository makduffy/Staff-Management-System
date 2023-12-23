<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblStaffID" runat="server" Text="Staff ID "></asp:Label>
        <asp:TextBox ID="txtStaffID" runat="server"></asp:TextBox>
        <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnFind_Click" />
        <p>
            <asp:Label ID="lblStaffEmail" runat="server" Text="Staff Email " width="52px"></asp:Label>
            <asp:TextBox ID="txtStaffEmail" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblStaffName" runat="server" Text="Staff Name " width="52px"></asp:Label>
        <asp:TextBox ID="txtStaffName" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lblDateCreated" runat="server" Text="Date Created " width="52px"></asp:Label>
            <asp:TextBox ID="txtDateCreated" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblSalary" runat="server" Text="Salary " width="52px"></asp:Label>
            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
        </p>
        <asp:CheckBox ID="chkIsAdmin" runat="server" Text="Admin" width="52px" />
        <p>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
        <asp:Button ID="BtnOK" runat="server" OnClick="BtnOK_Click" Text="OK" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </form>
</body>
</html>

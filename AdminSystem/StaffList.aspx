<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 525px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ListBox ID="lstStaffList" runat="server" Height="322px" Width="443px"></asp:ListBox>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click1" Text="Add" />
            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click1" Text="Delete" />
        </p>
        <asp:Button ID="btnApply" runat="server" OnClick="btnApply_Click1" Text="Apply" />
        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click1" Text="Clear" />
        <asp:Label ID="lblFilter" runat="server" height="22px" Text="Search for Staff Members"></asp:Label>
        <asp:TextBox ID="txtFilter" runat="server"></asp:TextBox>
        <asp:Label ID="lblError" runat="server" Text="lblError"></asp:Label>
    </form>
</body>
</html>

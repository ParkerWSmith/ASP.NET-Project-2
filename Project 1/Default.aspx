<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project_1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            z-index: 1;
            left: 358px;
            top: 140px;
            position: absolute;
            width: 194px;
        }
        .auto-style2 {
            z-index: 1;
            left: 357px;
            top: 80px;
            position: absolute;
            width: 194px;
        }
        .auto-style3 {
            z-index: 1;
            left: 357px;
            top: 272px;
            position: absolute;
            width: 194px;
        }
        .auto-style4 {
            z-index: 1;
            left: 357px;
            top: 207px;
            position: absolute;
            width: 194px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="XX-Large" 
            style="z-index: 1; left: 373px; top: 15px; position: absolute; width: 180px; height: 37px;" 
            Text="Main Menu"></asp:Label>
        </div>
        <asp:Button ID="ServiceBtn" runat="server" OnClick="ServiceBtn_Click" Text="Service" CssClass="auto-style2"/>
        <asp:Button ID="ProblemBtn" runat="server" OnClick="ProblemBtn_Click" Text="Problem" CssClass="auto-style1" Enabled="True"/>
        <asp:Button ID="ReportsBtn" runat="server" OnClick="ReportsBtn_Click" Text="Reports" CssClass="auto-style4" Enabled="False"/>
        <asp:Button ID="TechniciansBtn" runat="server" OnClick="TechniciansBtn_Click" Text="Technicians" CssClass="auto-style3"/>
    </form>
    </body>
</html>

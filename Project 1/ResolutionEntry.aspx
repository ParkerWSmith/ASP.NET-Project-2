<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResolutionEntry.aspx.cs" Inherits="Project_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resolution Entry</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="XX-Large" 
            style="z-index: 1; left: 373px; top: 15px; position: absolute; width: 267px; height: 37px;" 
            Text="Resolution Entry"></asp:Label>
        </div>
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" style="z-index: 1; left: 27px; top: 69px; position: absolute; height: 22px; width: 183px" Text="Return to Problems" />
        <asp:Label ID="lblTicket" runat="server" style="z-index: 1; left: 58px; top: 111px; position: absolute; width: 69px" Text="Ticket No:"></asp:Label>
        <asp:Label ID="lblProbNum" runat="server" style="z-index: 1; left: 45px; top: 139px; position: absolute" Text="Problem No:"></asp:Label>
        <asp:Label ID="lblResNum" runat="server" style="z-index: 1; left: 33px; top: 165px; position: absolute" Text="Resolution No:"></asp:Label>
        <asp:Label ID="lblResolution" runat="server" style="z-index: 1; left: 47px; top: 191px; position: absolute" Text="*Resolution:"></asp:Label>
        <asp:Label ID="lblTech" runat="server" style="z-index: 1; left: 49px; top: 314px; position: absolute" Text="*Technician:"></asp:Label>
        <asp:TextBox ID="txtFixed" runat="server" style="z-index: 1; left: 142px; top: 439px; position: absolute; width: 163px; right: 1459px;" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="tbResolution" runat="server" style="z-index: 1; left: 136px; top: 190px; position: absolute; height: 100px; width: 396px" TextMode="MultiLine"></asp:TextBox>
        <asp:DropDownList ID="drpTech" runat="server" style="z-index: 1; left: 140px; top: 312px; position: absolute; width: 221px">
            <asp:ListItem Text="--Technician--" Value="0" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblHours" runat="server" style="z-index: 1; left: 81px; top: 373px; position: absolute; right: 1189px" Text="*Hours:"></asp:Label>
        <asp:Label ID="lblSupplies" runat="server" style="z-index: 1; left: 76px; top: 408px; position: absolute" Text="Supplies:"></asp:Label>
        <asp:Label ID="lblDate" runat="server" style="z-index: 1; left: 61px; top: 442px; position: absolute" Text="Date Fixed:"></asp:Label>
        <asp:Label ID="lblMileage" runat="server" style="z-index: 1; left: 244px; top: 374px; position: absolute; bottom: 667px" Text="Mileage:"></asp:Label>
        <asp:Label ID="lblMisc" runat="server" style="z-index: 1; left: 262px; top: 409px; position: absolute" Text="Misc:"></asp:Label>
        <asp:Label ID="lblCostMile" runat="server" style="z-index: 1; left: 445px; top: 376px; position: absolute" Text="Cost Miles:"></asp:Label>
        <asp:Label ID="lblOnsite" runat="server" style="z-index: 1; left: 438px; top: 440px; position: absolute" Text="Date Onsite:"></asp:Label>
        <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 20px; top: 516px; position: absolute; width: 86px; margin-bottom: 0px;" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 191px; top: 519px; position: absolute; width: 83px" Text="Clear" OnClick="btnClear_Click" />
        <asp:Label ID="lblRequired" runat="server" ForeColor="Red" style="z-index: 1; left: 41px; top: 479px; position: absolute; height: 25px;" Text="*indicates required information"></asp:Label>
        <asp:TextBox ID="txtHours" runat="server" style="z-index: 1; left: 137px; top: 373px; position: absolute; width: 41px" TextMode="Number"></asp:TextBox>
        <asp:TextBox ID="txtSupplies" runat="server" style="z-index: 1; left: 141px; top: 405px; position: absolute; width: 62px" TextMode="Number"></asp:TextBox>
        <asp:TextBox ID="txtMisc" runat="server" style="z-index: 1; left: 312px; top: 407px; position: absolute; width: 54px; margin-bottom: 0px" TextMode="Number"></asp:TextBox>
        <asp:TextBox ID="txtCostMile" runat="server" style="z-index: 1; left: 522px; top: 376px; position: absolute; width: 56px" TextMode="Number"></asp:TextBox>
        <asp:TextBox ID="txtOnsite" runat="server" style="z-index: 1; left: 522px; top: 438px; position: absolute; width: 181px" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="txtMileage" runat="server" style="z-index: 1; left: 311px; top: 373px; position: absolute; width: 54px" TextMode="Number"></asp:TextBox>
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 28px; top: 558px; position: absolute" Text="(Error)"></asp:Label>
        <asp:Label ID="lblTicNum" runat="server" style="z-index: 1; left: 138px; top: 110px; position: absolute" Text="Ticket #"></asp:Label>
        <asp:Label ID="lblProblem" runat="server" style="z-index: 1; top: 139px; position: absolute; left: 138px" Text="Problem #"></asp:Label>
        <asp:Label ID="lblResNo" runat="server" style="z-index: 1; left: 139px; top: 164px; position: absolute" Text="Resolution #"></asp:Label>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemEntry.aspx.cs" Inherits="Project_1.ProblemEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Entry</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="XX-Large" 
            style="z-index: 1; left: 373px; top: 15px; position: absolute; width: 246px; height: 37px;" 
            Text="Problem Entry"></asp:Label>
        <asp:Label ID="lblTicket" runat="server" style="z-index: 1; left: 43px; top: 90px; position: absolute" Text="Ticket No:"></asp:Label>
        <asp:Label ID="lblProbNum" runat="server" style="z-index: 1; left: 28px; top: 126px; position: absolute" Text="Problem No:"></asp:Label>
        <asp:Label ID="lblProduct" runat="server" style="z-index: 1; left: 21px; top: 162px; position: absolute; right: 1172px" Text="*Product No:"></asp:Label>
        <asp:Label ID="lblProblem" runat="server" style="z-index: 1; left: 44px; top: 203px; position: absolute; height: 19px" Text="*Problem"></asp:Label>
        <asp:DropDownList ID="drpProduct" runat="server" style="z-index: 1; left: 119px; top: 160px; position: absolute; width: 170px; height: 22px">
            <asp:ListItem Text="--PRODUCT--" Value="0" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="drpTech" runat="server" style="z-index: 1; left: 117px; top: 364px; position: absolute; width: 154px">
            <asp:ListItem Text="--Technician--" Value="0" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 28px; top: 440px; position: absolute; width: 73px;" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblRequired" runat="server" style="z-index: 1; left: 29px; top: 402px; position: absolute" Text="*indicates required information" ForeColor="Red"></asp:Label>
        <asp:TextBox ID="tbProblem" runat="server" style="z-index: 1; left: 116px; top: 203px; position: absolute; height: 132px; width: 380px" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="lblTech" runat="server" style="z-index: 1; left: 28px; top: 365px; position: absolute" Text="*Technician"></asp:Label>
        <asp:Button ID="btnInfo" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" style="z-index: 1; left: 40px; top: 51px; position: absolute; width: 200px" 
            TabIndex="1" Text="Return to Maintenance Menu" 
            ToolTip="Return to Main Menu" Width="250px" OnClick="btnInfo_Click" Enabled="False"></asp:Button>
        <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 181px; top: 442px; position: absolute; width: 70px;" Text="Clear" OnClick="btnClear_Click" />
        <asp:Label ID="lblTicNum" runat="server" style="z-index: 1; left: 117px; top: 90px; position: absolute" Text="TicketNum"></asp:Label>
        <asp:Label ID="lblProblemNumb" runat="server" style="z-index: 1; left: 117px; top: 127px; position: absolute" Text="ProblemNum"></asp:Label>
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 32px; top: 485px; position: absolute" Text="(Error)"></asp:Label>
    </form>
</body>
</html>

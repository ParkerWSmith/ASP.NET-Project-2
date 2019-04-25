<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Problem.aspx.cs" Inherits="Project_1.Problem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblProb" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="XX-Large" 
            style="z-index: 1; left: 373px; top: 15px; position: absolute; width: 305px; height: 37px;" 
            Text="Open Problem List"></asp:Label>
        <asp:Button ID="btnInfo" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Small" 
            style="z-index: 1; left: 63px; top: 67px; position: absolute; width: 200px" 
            TabIndex="1" Text="Return to Maintenance Menu" 
            ToolTip="Return to Main Menu" Width="250px" OnClick="btnInfo_Click" />
        <asp:GridView ID="gvProblems" runat="server" 
             style="z-index: 1; left: 73px; top: 131px; position: absolute; height: 150px; width: 750px" 
             AutoGenerateColumns="True" OnRowCommand="gvProblems_RowCommand">
            <Columns>
                <asp:ButtonField CommandName="SELECT" Text="SELECT" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 65px; top: 437px; position: absolute" Text="(error)"></asp:Label>
    </form>
</body>
</html>

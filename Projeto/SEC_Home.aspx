<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEC_Home.aspx.cs" Inherits="SEC_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Calculator</title>
</head>
<body>
    <h1><center><asp:Label ID="Label1" runat="server" Text="SEC"></asp:Label></center></h1>
    <form id="form1" runat="server">
    <center><div>
        <asp:Label ID="Label2" runat="server" Text="a = "></asp:Label><asp:TextBox ID="txtA" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="b = "></asp:Label><asp:TextBox ID="txtB" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="c = "></asp:Label><asp:TextBox ID="txtC" runat="server"></asp:TextBox>
    </div></center>
        <center>
            <div>
                <br /><br /><asp:Button ID="btnCalcular" runat="server" Text="Calcular"></asp:Button>
            </div>
        </center>
    </form>
</body>
</html>

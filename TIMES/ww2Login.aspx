<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ww2Login.aspx.cs" Inherits="TIMES.ww2Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="Literal1" runat="server" Text="Login"></asp:Literal>
            <br />
            <br />
            <asp:Literal ID="Literal2" runat="server" Text="Id"></asp:Literal>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="Literal3" runat="server" Text="Password"></asp:Literal>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server">会員登録へ</asp:LinkButton>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="LOGIN" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>

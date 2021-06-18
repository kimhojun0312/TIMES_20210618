<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ww2Entry.aspx.cs" Inherits="TIMES.ww2Entry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="Literal1" runat="server" Text="会員登録"></asp:Literal>
            <br />
            <br />
            <asp:Literal ID="Literal2" runat="server" Text="名前："></asp:Literal>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Literal ID="Literal3" runat="server" Text="ID："></asp:Literal>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Literal ID="Literal4" runat="server" Text="パスワード："></asp:Literal>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="確認する" />
&nbsp;
            <asp:Button ID="Button2" runat="server" Text="戻る" />
        </div>
    </form>
</body>
</html>

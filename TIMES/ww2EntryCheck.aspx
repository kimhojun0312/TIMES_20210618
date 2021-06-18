<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ww2EntryCheck.aspx.cs" Inherits="TIMES.ww2EntryCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="Literal1" runat="server" Text="会員登録確認"></asp:Literal>
            <br />
            <br />
            <asp:Literal ID="Literal2" runat="server" Text="名前：キム"></asp:Literal>
            <br />
            <br />
            <asp:Literal ID="Literal3" runat="server" Text="ID：ID１２３"></asp:Literal>
            <br />
            <br />
            <asp:Literal ID="Literal4" runat="server" Text="PWD:pwdencrypt"></asp:Literal>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="登録" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="戻る" />
        </div>
    </form>
</body>
</html>

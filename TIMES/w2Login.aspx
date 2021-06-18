<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="w2Login.aspx.cs" Inherits="TIMES.w2Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            メール<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            タイトル<asp:TextBox ID="TextBox2" runat="server" Height="133px" Width="402px"></asp:TextBox>
            <br />
            内容<asp:TextBox ID="TextBox3" runat="server" Height="115px" Width="398px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="送信" />
        </div>
    </form>
</body>
</html>

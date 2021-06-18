<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="TIMES.HomeAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>管理ホーム</h2><br />
        <br />
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="社員登録" Width="210px" />
        <br />
        <br />
        <asp:Button ID="btnUser" runat="server" OnClick="btnUser_Click" Text="社員一覧" Width="210px" />
        <br />
        <br />
        <asp:Button ID="btnReport" runat="server" Text="申請書管理" OnClick="btnReport_Click" Width="210px" />
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="ログアウト" Width="210px" />
        <br />
        <br />
        <br />
    </form>
</body>
</html>

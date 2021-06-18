<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeListDetail.aspx.cs" Inherits="TIMES.ChangeListDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>時間変更申請明細</h2><br />
        <br />

        <asp:Label ID="Label3" runat="server" Text="社員番号 :"></asp:Label>
        <asp:Label ID="lblUserNo" runat="server"></asp:Label>

        <br />
        <br />

        <asp:Label ID="Label5" runat="server" Text="社員名 :"></asp:Label>
        <asp:Label ID="lblUserName" runat="server"></asp:Label>
 
        <br />
        <br />
 
        <asp:Label ID="Label7" runat="server" Text="変更理由 :"></asp:Label>
        <asp:Label ID="lblTitle" runat="server"></asp:Label>

        <br />
        <br />

        <asp:Label ID="Label9" runat="server" Text="内容 :"></asp:Label>
        <asp:Label ID="lblComment" runat="server"></asp:Label>

        <br />
        <br />

        <asp:Label ID="Label17" runat="server" Text="処理状況 :"></asp:Label>
        <asp:Label ID="lblStatus" runat="server" ForeColor="#FF0066"></asp:Label>

        <br />
        <br />

        管理者からのメッセージ :<br />
        <asp:TextBox ID="txtComment" runat="server" Height="95px" ReadOnly="True" Width="434px"></asp:TextBox>

        <br />
        <br />

        <asp:Button ID="btnReturn" runat="server" class="btn btn-outline-dark" OnClick="btnReturn_Click" Text="戻る" />
    </form>
</body>
</html>

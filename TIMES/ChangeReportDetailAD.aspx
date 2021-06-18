<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeReportDetailAD.aspx.cs" Inherits="TIMES.ChangeReportDetailAD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>出勤・退勤時間変更管理</h2><br />
            <br />
            &nbsp;<asp:Label ID="lblReportNo" runat="server"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblUserNo" runat="server"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblTitle" runat="server"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblComment" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            &nbsp;<asp:Label ID="lblIntime" runat="server"></asp:Label>
            <br />
            &nbsp;<asp:Label ID="lblNewIntime" runat="server"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblOutTime" runat="server"></asp:Label>
            <br />
            &nbsp;<asp:Label ID="lblNewOutTime" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            コメント:<br />
            <br />
            <asp:TextBox ID="txtComment" runat="server" Height="193px" Width="682px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="承認" />
            &nbsp;
            <asp:Button ID="btnNo" runat="server" Text="拒否" OnClick="btnNo_Click" />
            &nbsp;
            <asp:Button ID="btnReturn" runat="server" Text="戻る" OnClick="btnReturn_Click" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

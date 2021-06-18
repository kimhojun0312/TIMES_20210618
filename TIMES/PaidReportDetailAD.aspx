<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaidReportDetailAD.aspx.cs" Inherits="TIMES.PaidReportDetailAD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>有給申請詳細</h2>
            <asp:Label ID="lblName" runat="server"></asp:Label>
&nbsp;<br />
            <br />
            <asp:Label ID="lblWantDay" runat="server"></asp:Label>
            &nbsp;<br />
            <br />
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblComment" runat="server" Text="申請内容"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtComment" runat="server" Height="127px" ReadOnly="True" Width="426px"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lblAdminComment" runat="server" Text="管理者からのメッセージ"></asp:Label>
            <br />
            <asp:TextBox ID="txtAdminComment" runat="server" Height="127px" Width="412px"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="承認" />
&nbsp;
            <asp:Button ID="btnNG" runat="server" OnClick="btnNG_Click" Text="拒否" />
&nbsp;
            <asp:Button ID="btnReturn" runat="server" Text="戻る" OnClick="btnReturn_Click" />
&nbsp;</div>
    </form>
</body>
</html>

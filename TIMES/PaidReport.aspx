<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaidReport.aspx.cs" Inherits="TIMES.PaidReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>有給申請一覧</h2><br />
            <br />
            申請履歴<br />
            <asp:GridView ID="gvTimes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTimes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="PaidReportNo" HeaderText="No." />
                    <asp:ButtonField CommandName="Detail" DataTextField="Title" HeaderText="タイトル" Text="ボタン" />
                    <asp:BoundField DataField="WantDay" HeaderText="希望日付" />
                    <asp:BoundField DataField="Status" HeaderText="処理状況" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnPaid" runat="server" OnClick="btnPaid_Click" Text="新規有給申請" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="戻る" />
            <br />
        </div>
    </form>
</body>
</html>

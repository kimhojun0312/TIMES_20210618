<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportAdmin.aspx.cs" Inherits="TIMES.ReportAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>申請書一覧</h2><br />
            <br />
            有給申請一覧<br />
            <asp:GridView ID="gvPaid" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPaid_RowCommand">
                <Columns>
                    <asp:BoundField DataField="PaidReportNo" HeaderText="No." />
                    <asp:BoundField DataField="UserName" HeaderText="ユーザー名" />
                    <asp:BoundField DataField="UserPosition" HeaderText="役職" />
                    <asp:ButtonField CommandName="Detail" DataTextField="Title" HeaderText="タイトル" Text="ボタン" />
                    <asp:BoundField DataField="Status" HeaderText="処理状況" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            出勤・退勤時間変更一覧<br />
            <asp:GridView ID="gvChange" runat="server" AutoGenerateColumns="False" OnRowCommand="gvChange_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ChangeReportNo" HeaderText="No." />
                    <asp:BoundField DataField="UserName" HeaderText="ユーザー名" />
                    <asp:BoundField DataField="UserPosition" HeaderText="役職" />
                    <asp:ButtonField CommandName="Detail" DataTextField="Title" HeaderText="タイトル" Text="ボタン" />
                    <asp:BoundField DataField="Status" HeaderText="処理状況" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" Text="戻る" OnClick="btnReturn_Click" />
        </div>
    </form>
</body>
</html>

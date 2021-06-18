<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeList.aspx.cs" Inherits="TIMES.ChangeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>出勤・退勤時間の変更申請一覧</h2><br />
            <br />
            <asp:GridView ID="gvTimes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTimes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ChangeReportNo" HeaderText="No." />
                    <asp:ButtonField CommandName="Detail" DataTextField="Title" HeaderText="タイトル" Text="ボタン"  />
                    <asp:BoundField DataField="Status" HeaderText="処理状況" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="戻る" />
        </div>
    </form>
</body>
</html>

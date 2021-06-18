<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkAdmin.aspx.cs" Inherits="TIMES.WorkAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>社員一覧</h2><br />
            <br />
            <asp:Button ID="btnAll" runat="server" OnClick="btnAll_Click" Text="すべての社員を表示" />
            &nbsp;<br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="社員名"></asp:Label>
            &nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnSearchName" runat="server" Text="検索" OnClick="btnSearchName_Click" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="役職"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlPosition" runat="server">
                <asp:ListItem>社員</asp:ListItem>
                <asp:ListItem>主任</asp:ListItem>
                <asp:ListItem>課長</asp:ListItem>
                <asp:ListItem>次長</asp:ListItem>
                <asp:ListItem>部長</asp:ListItem>
                <asp:ListItem>代表取締役社長</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Button ID="btnSearchLevel" runat="server" Text="検索" OnClick="btnSearchLevel_Click" />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="gvTimes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTimes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserNo" HeaderText="社員番号" />
                    <asp:ButtonField DataTextField="UserName" HeaderText="社員名" CommandName="Detail" />
                    <asp:BoundField DataField="UserPosition" HeaderText="役職" />
                    <asp:BoundField DataField="StartDate" HeaderText="入社日" />
                    <asp:BoundField DataField="UserType" HeaderText="勤務形態" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="戻る" />
        </div>
    </form>
</body>
</html>

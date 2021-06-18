<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="TIMES.UserDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>社員詳細</h2>
            <asp:Label ID="lblUserNo" runat="server" Text="ユーザー番号"></asp:Label>
&nbsp;<br />
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="ユーザー名"></asp:Label>
&nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblUserType" runat="server" Text="勤務形態："></asp:Label>
&nbsp;<asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem>正社員</asp:ListItem>
                <asp:ListItem>パートタイム</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblStartDay" runat="server" Text="入社日："></asp:Label>
&nbsp;<asp:DropDownList ID="ddlYear" runat="server">
                <asp:ListItem>2021</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblYear" runat="server" Text="年"></asp:Label>
            <asp:DropDownList ID="ddlMonth" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblMonth" runat="server" Text="月"></asp:Label>
            <asp:DropDownList ID="ddlDay" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblDay" runat="server" Text="日"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblUserPosition" runat="server" Text="役職："></asp:Label>
&nbsp;<asp:DropDownList ID="ddlPosition" runat="server">
                <asp:ListItem>社員</asp:ListItem>
                <asp:ListItem>主任</asp:ListItem>
                <asp:ListItem>課長</asp:ListItem>
                <asp:ListItem>次長</asp:ListItem>
                <asp:ListItem>部長</asp:ListItem>
                <asp:ListItem>代表取締役社長</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="btnHistory" runat="server" OnClick="btnHistory_Click" Text="勤務履歴確認" />
            <br />
            <br />
            &nbsp;<asp:Button ID="btnResetOk" runat="server" OnClick="btnResetOk_Click" Text="修正完了" />
            　<asp:Button ID="btnReturn" runat="server" Text="戻る" OnClick="btnReturn_Click" />
            <br />
        </div>
    </form>
</body>
</html>

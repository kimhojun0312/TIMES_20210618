<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="TIMES.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>社員登録</h2><br />
            <br />
            <asp:Label ID="lblId" runat="server" Text="ID"></asp:Label>
            &nbsp;<asp:TextBox ID="txtUserId" runat="server"　placeholder="ID" class="form-control"></asp:TextBox>
            &nbsp;<asp:Button ID="btnCheck" runat="server" CausesValidation="False" OnClick="btnCheck_Click" Text="重複チェック" />
            &nbsp;<asp:RequiredFieldValidator ID="rfvId" runat="server" ControlToValidate="txtUserId" Display="None" ErrorMessage="IDを入力してください。"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revIdLength" runat="server" BorderStyle="None" ControlToValidate="txtUserId" Display="None" ErrorMessage="IDは3文字から20文字以内です。" ValidateRequestMode="Disabled" ValidationExpression="^[a-zA-Z0-9]{3,20}$"></asp:RegularExpressionValidator>
            
            <br />
            <asp:Label ID="lblIdCheck" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblIdOk" runat="server" ForeColor="Black"></asp:Label>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="パスワード"></asp:Label>
            &nbsp;<asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="パスワード" type="password"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="パスワードを入力してください。"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revPwdLength" runat="server" BorderStyle="None" ControlToValidate="txtPassword" Display="None" ErrorMessage="パスワードは3文字から20文字以内です。" ValidateRequestMode="Disabled" ValidationExpression="^[a-zA-Z0-9]{3,20}$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="revPwdtype" runat="server" BorderStyle="None" ControlToValidate="txtPassword" Display="None" ErrorMessage="パスワードは英語または数字のみ入力してください。" ValidateRequestMode="Disabled" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblStartDay" runat="server" Text="入社日"></asp:Label>
            　<asp:DropDownList ID="ddlYear" runat="server">
                <asp:ListItem>2021</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblYears" runat="server" Text="年"></asp:Label>
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
            <asp:Label ID="lblMonths" runat="server" Text="月"></asp:Label>
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
            <asp:Label ID="lblDays" runat="server" Text="日"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="社員名"></asp:Label>
            &nbsp;<asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="社員名"> </asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="None" ErrorMessage="名前を入力してください。"></asp:RequiredFieldValidator>
            &nbsp;
            <br />
            <br />
            <asp:Label ID="lblLevel" runat="server" Text="役職"></asp:Label>
            　<asp:DropDownList ID="ddlLevel" runat="server">
                <asp:ListItem>社員</asp:ListItem>
                <asp:ListItem>主任</asp:ListItem>
                <asp:ListItem>課長</asp:ListItem>
                <asp:ListItem>次長</asp:ListItem>
                <asp:ListItem>部長</asp:ListItem>
                <asp:ListItem>代表取締役社長</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblType" runat="server" Text="勤務形態"></asp:Label>
            　<asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem>正社員</asp:ListItem>
                <asp:ListItem>パートタイム</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:ValidationSummary ID="vsSearch" runat="server" DisplayMode="List" ForeColor="Red" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnEntry" runat="server" OnClick="btnEntry_Click" Text="登録" />
            　　<asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="戻る" CausesValidation="False" />
        </div>
    </form>
</body>
</html>

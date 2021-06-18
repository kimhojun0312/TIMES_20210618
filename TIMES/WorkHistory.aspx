<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkHistory.aspx.cs" Inherits="TIMES.WorkHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

            <h2>勤務履歴</h2><br />
            <br />

            <asp:Label ID="lblUserNo" runat="server"></asp:Label>

            <br />

            <br />

            <asp:Label ID="lblId" runat="server"></asp:Label>

            <br />

            <br />

            <asp:Button ID="btnAll" runat="server" CausesValidation="False" Text="すべて" OnClick="btnAll_Click" />
    &nbsp;&nbsp;
            <asp:Button ID="btnDay" runat="server" CausesValidation="False" Text="日付で検索" OnClick="btnDay_Click" />
    &nbsp;&nbsp;
            <asp:Button ID="btnCal" runat="server" CausesValidation="False" Text="カレンダーから検索" OnClick="btnCal_Click" />

            <br />
            <br />

            <asp:Label ID="lblStart" runat="server" Text="検索範囲"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="ddlSYear" runat="server">
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
                <asp:ListItem>2021</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblYears" runat="server" Text="年"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlSMonth" runat="server">
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
            &nbsp;<asp:DropDownList ID="ddlSDay" runat="server">
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
            <asp:Label ID="lblDays" runat="server" Text="日から"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="ddlYear" runat="server">
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
                <asp:ListItem>2021</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblYear" runat="server" Text="年"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlMonth" runat="server">
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
            &nbsp;<asp:DropDownList ID="ddlDay" runat="server">
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
            <asp:Label ID="lblDay" runat="server" Text="日まで"></asp:Label>
    &nbsp;<asp:Button ID="btnSearch" runat="server" class="btn btn-outline-dark" Text="検索" OnClick="btnSearch_Click" />

    &nbsp;<br />
            <br />
            <asp:Label ID="lblDateCheck" runat="server" ForeColor="#FF0066"></asp:Label>
            <br />
            <br />
    <asp:Calendar ID="Calendar" runat="server" Height="178px" OnSelectionChanged="Calendar_SelectionChanged" Width="431px"></asp:Calendar>
    <br />
    <asp:Label ID="lblClickDay" runat="server"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvTimes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTimes_RowCommand">
        <Columns>
            <asp:ButtonField DataTextField="WorkNo" CommandName="Detail" HeaderText="No." Text="ボタン" />
            <asp:BoundField DataField="InTime" HeaderText="出勤時間" />
            <asp:BoundField DataField="OutTime" HeaderText="退勤時間" />
            <asp:BoundField DataField="WorkTime" HeaderText="勤務時間" />
            <asp:BoundField DataField="WorkStatus" HeaderText="勤務状況" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnReturn" runat="server" CausesValidation="False" class="btn btn-outline-dark" Text="戻る" OnClick="btnReturn_Click" />
 
    </form>
</body>
</html>

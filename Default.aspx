<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Memeber Mannagement</title>
    <style type="text/css">
        .btn_style {
            font-size: 14px;
            font: Tahoma;
            width: 120px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: white;
            background-color: #3BD9FF;
            border-radius: 6px;
            border: 0;
        }

        .auto-style1 {
            height: 26px;
        }

        .abov {
            font-size: 14px;
            font: Tahoma;
            width: 120px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: white;
            background-color: #3BD9FF;
            border-radius: 6px;
            border: 0;
        }
    </style>
</head>
<body style="background-color: #e5eecc; font-family: Arial, Helvetica, sans-serif; font-size: small; text-align: center">
    <form id="form1" runat="server" align="left">
        <h3 style="font-size: medium; text-align: center">Member Mannagement</h3>
        <hr />
        <br />
        <div>
            <asp:Panel runat="server">
                Team:
                <asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged"></asp:DropDownList>
                &nbsp; 
                 Members:
                <asp:DropDownList ID="ddlMember" runat="server" OnSelectedIndexChanged="ddlMember_SelectedIndexChanged">
                </asp:DropDownList>

            </asp:Panel>

            <br />
            <asp:Button ID="btnSel" runat="server" OnClick="btnSel_Click" Text="Select" Style="margin-left: 60px;" CssClass="btn_style" />
            &nbsp;
               <asp:Button ID="Button5" runat="server" Text="Add Or Update" OnClick="btnAdd_Click" Style="margin-left: 60px" CssClass="btn_style" />
            &nbsp;
               <asp:Button ID="Button6" runat="server" Text="Delete" OnClick="btnDel_Click" Style="margin-left: 60px" CssClass="btn_style" />
            <p>
                <asp:Label ID="Results" runat="server" EnableViewState="False"
                    Visible="False">
                    
                </asp:Label>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                        <Columns>
                            <asp:BoundField DataField="UserTeam" HeaderText="No." />
                            <asp:BoundField DataField="TeamName" HeaderText="Team" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="UserGrade" HeaderText="UserGrade" />
                            <asp:TemplateField Visible="false">
                                <HeaderTemplate>
                                    Select  
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckItem" runat="server" />
                                    <asp:HiddenField ID="HidID" runat="server" Value='<%# Eval("UserID") %> ' />
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            </p>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Modify password" />
                    <br />
                    <br />
                    <input type="button" onclick="window.location = 'Register.aspx'" value="Register new user" />
                </asp:Panel>

        </div>
    </form>

</body>
</html>


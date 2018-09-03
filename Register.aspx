<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #btn_return {
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
<body>
    <form id="form1" runat="server">
        <div align="center">

            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F6F3"
                BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" Height="267px"
                OnCreatedUser="CreateUserWizard1_CreatedUser" Width="318px">
                <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em"
                    VerticalAlign="Top" />
                <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
                <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                    ForeColor="#284775" />
                <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                    ForeColor="#284775" />
                <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True"
                    Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
                <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                    ForeColor="#284775" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <StepStyle BorderWidth="0px" />
                <WizardSteps>
                    <asp:CreateUserWizardStep runat="server">
                        <ContentTemplate>
                            <table border="0"
                                style="font-family: Verdana; font-size: 100%; height: 267px; width: 318px;">
                                <tr>
                                    <td align="center" colspan="2"
                                        style="color: White; background-color: #5D7B9D; font-weight: bold;" mce_style="color:White;background-color:#5D7B9D;font-weight:bold;">Sign up for a new account</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">UserName:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                            ControlToValidate="UserName" ErrorMessage="UserName must be filled in." ToolTip="'UserName must be filled in.' must be filled in."
                                            ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                            ControlToValidate="Password" ErrorMessage="Password must be filled in." ToolTip="Password must be filled in."
                                            ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server"
                                            AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmPassword" runat="server"
                                            OnTextChanged="ConfirmPassword_TextChanged" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server"
                                            ControlToValidate="ConfirmPassword" ErrorMessage="Confirm password must be filled in."
                                            ToolTip="Confirm password must be filled in." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server"
                                            ControlToValidate="Email" ErrorMessage="Email must be filled in." ToolTip="Email must be filled in."
                                            ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Safety hint question:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server"
                                            ControlToValidate="Question" ErrorMessage="You must fill out the Safety hint question."
                                            ToolTip="You must fill out the Safety hint question." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Safety hint question:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server"
                                            ControlToValidate="Answer" ErrorMessage="Safety answer must be filled in." ToolTip="Safety answer must be filled in."
                                            ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server"
                                            ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                            Display="Dynamic" ErrorMessage="Password and Confirm password must match."
                                            ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;" mce_style="color:Red;">
                                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep runat="server" />
                </WizardSteps>
            </asp:CreateUserWizard>
            <p>
            <asp:Button ID="btn_return" runat="server" Text="return" align="center" OnClick="btn_return_Click"/>
        </p>
        </div>
        
    </form>
</body>
</html>

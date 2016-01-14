<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EyeMDB.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div style="margin: 0 310px">
                <h2>Registeration</h2>
                    
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

                Please confirm your details:
                    
                <p>
                    <label>User Name: </label>
                    <asp:TextBox ID="tbxUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_UserName" ControlToValidate="tbxUserName" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <label>First Name: </label>
                    <asp:TextBox ID="tbxFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_FirstName" ControlToValidate="tbxFirstName" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Surname: </label>
                    <asp:TextBox ID="tbxSurname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_Surname" ControlToValidate="tbxSurname" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Email: </label>
                    <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexval_Email" runat="server" ControlToValidate="tbxEmail" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                </p>

                <p>
                    <label>Password: </label>
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_Password" ControlToValidate="tbxPassword" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>

                <p>
                    <asp:Button ID="btnReg" runat="server" OnClick="btnReg_OnClick" Text="Register" class="btn btn-default"/></p>
            </div>
</asp:Content>

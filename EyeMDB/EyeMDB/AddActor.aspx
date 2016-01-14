<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddActor.aspx.cs" Inherits="EyeMDB.AddActor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 310px">
                <h2>Add Actor</h2>
                    
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    
                <p>
                    <label>Actor Name: </label>
                    <asp:TextBox ID="tbxActorName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_UserName" ControlToValidate="tbxActorName" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <label>Nationality: </label>
                    <asp:TextBox ID="tbxNationality" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_FirstName" ControlToValidate="tbxNationality" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>DOB: </label>
                    <asp:TextBox ID="tbxDOB" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_Surname" ControlToValidate="tbxDOB" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Image URL: </label>
                    <asp:TextBox ID="TbxImage" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_OnClick" Text="Add Actor" class="btn btn-default"/>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_OnClick" Text="Cancel" class="btn btn-default" CausesValidation="False"/>

                </p>
            </div>
</asp:Content>

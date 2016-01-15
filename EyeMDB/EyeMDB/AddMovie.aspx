<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddMovie.aspx.cs" Inherits="EyeMDB.AddMovie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 310px">
                <h2>Add Movie</h2>
                    
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    
                <p>
                    <label>Title: </label>
                    <asp:TextBox ID="tbxTitle" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_Title" ControlToValidate="tbxTitle" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <label>Release Date: </label>
                    <asp:TextBox ID="tbxReleaseDate" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_ReleaseDate" ControlToValidate="tbxReleaseDate" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Director: </label>
                    <asp:TextBox ID="tbxDirector" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_Director" ControlToValidate="tbxDirector" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <label>Studio: </label>
                    <asp:TextBox ID="tbxStudio" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_Studio" ControlToValidate="tbxStudio" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>

                <p>
                    <label>Movie Artwork: </label>
                    <asp:TextBox ID="tbxMovieImage" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfval_MovieImage" ControlToValidate="tbxMovieImage" runat="server"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>

                <p>
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_OnClick" Text="Add Movie" class="btn btn-default"/>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_OnClick" Text="Cancel" class="btn btn-default" CausesValidation="False"/>

                </p>
            </div>
</asp:Content>

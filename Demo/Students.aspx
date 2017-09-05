<%@ Page 
    Title="Students" 
    Language="C#" 
    AutoEventWireup="true" 
    MasterPageFile="~/Site.Master" 
    CodeBehind="Students.aspx.cs" 
    Inherits="Demo.Demo" 
%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>
        <asp:GridView ID="StudentsGridView" runat="server" DataSourceID="StudentsDS">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="StudentsDS" runat="server" DeleteMethod="RemoveStudent" SelectMethod="GetStudents" TypeName="DemoData.Students">
            <DeleteParameters>
                <asp:Parameter Name="StudentID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </h2>
    </asp:Content>

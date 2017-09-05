<%@ Page 
    Title="Demo"
    Language="C#"
    AutoEventWireup="true" 
    MasterPageFile="~/Site.Master" 
    CodeBehind="Demo.aspx.cs" 
    Inherits="Demo.Demo" 
    EnableEventValidation="false"
%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <h3>Select Category</h3>

    <asp:ListBox runat="server" ID="categoryListBox" DataTextField="Name" DataValueField="Id">
    </asp:ListBox>

    <asp:Repeater runat="server" ID="categoriesRepeater">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr id="category_<%# Eval("Id") %>">
                <td><%# Eval("Name") %></td>
                <td>
                    <%--<button runat="server" data-id='<%# Eval("Id") %>' onserverclick="OnDeleteButton_Click">Delete</button>--%>
                    <asp:Button runat="server" data-id='<%# Eval("Id") %>' OnClick="OnDeleteButton_Click" Text="Delete"/>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <%--<table>
        <tbody>
            <% foreach (var item in CategoryItems)
            { %>
                <tr id="<%= item.Id %>">
                    <td><%= item.Name%></td>
                    <td><button>View</button></td>
                    <td><a href="?deleteId=<%=item.Id %>">Delete</a></td>
                    <td><button data-id="<%= item.Id %>" runat="server" onserverclick="OnDeleteButton_Click">Another Delete</button></td>
                </tr>
            <% } %>
        </tbody>
     </table>--%>

    <hr />

    <div>
        <h3>Create category form</h3>
        <table>
        <tbody>
            <tr>
                <td><label for="CategoryName">Name</label></td>
                <td><asp:TextBox runat="server" ID="CategoryName"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="CategoryDescription">Description</label></td>
                <td><asp:TextBox runat="server" ID="CategoryDescription"></asp:TextBox></td>

            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="SubmitFormBtn" Text="Submit Form" runat="server" onclick="SubmitFormBtn_Click"/></td>
            </tr>
        </tbody>
    </table>
    </div>
    
    <div id="InfoBox" runat="server"></div>
    
</asp:Content>
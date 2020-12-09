<%@ Control 
    Language="C#"
    AutoEventWireup="true"
    CodeFile="ContactForm.ascx.cs"
    Inherits="WordEngineering.UC_Contacts_ContactForm"
%>

<asp:Table
    id="ContactTable"
    Runat="server"
>
    <asp:TableHeaderRow>
        <asp:TableHeaderCell ColumnSpan="2">Contact Details</asp:TableHeaderCell>        
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">First name</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="FirstName"/></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Last name</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="LastName"/></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Nickname</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="NickName"/></asp:TableCell>
    </asp:TableRow>
    
    <asp:TableHeaderRow>
        <asp:TableHeaderCell ColumnSpan="2">Personal Information</asp:TableHeaderCell>        
    </asp:TableHeaderRow>
    
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Personal e-mail</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="PersonalEmail"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Home phone</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="HomePhone"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Mobile phone</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="MobilePhone"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Home address</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="HomeAddress"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">City</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="PersonalCity"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">State/Province</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="PersonalStateProvince"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">ZIP/Postal code</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="PersonalZipPostalCode"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Country</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="PersonalCountry"/></asp:TableCell>
    </asp:TableRow>
    
    <asp:TableHeaderRow>
        <asp:TableHeaderCell ColumnSpan="2">Business Information</asp:TableHeaderCell>        
    </asp:TableHeaderRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Company</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="Company"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Work e-mail</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="WorkEmail"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Work phone</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="WorkPhone"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Pager</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="Pager"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Fax</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="Fax"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Work address</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="WorkAddress"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">City</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="BusinessCity"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">State/Province</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="BusinessStateProvince"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">ZIP/Postal code</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="BusinessZipPostalCode"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Country</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="BusinessCountry"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableHeaderRow>
        <asp:TableHeaderCell ColumnSpan="2">Other Information</asp:TableHeaderCell>        
    </asp:TableHeaderRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Other e-mail</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="OtherEmail"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Preferred e-mail</asp:TableCell>
        <asp:TableCell><asp:DropDownList runat="server" ID="PreferredEmail"></asp:DropDownList></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Other phone</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="OtherPhone"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Website</asp:TableCell>
        <asp:TableCell><asp:TextBox runat="server" ID="Website"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Birthday</asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="BirthdayMonth" runat="server" />
            <asp:DropDownList ID="BirthdayDay" runat="server" />
            <asp:DropDownList ID="BirthdayYear" runat="server" />
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">Note</asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="Note" runat="server" TextMode="MultiLine" Rows="4" Columns="33" />
        </asp:TableCell>
    </asp:TableRow>    
</asp:Table>
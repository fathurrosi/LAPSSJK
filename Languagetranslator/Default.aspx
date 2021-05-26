<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 253px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <table style="width: 100%;">
        <tr>
            <td class="style1" colspan="2">
                &nbsp;
            <strong>Language Translator</strong></td>
        </tr>
        <tr>
            <td class="style2" valign="top">
                &nbsp;
                Enter Text</td>
            <td>
                &nbsp;
                <asp:TextBox ID="txtValue" runat="server" Height="69px" TextMode="MultiLine" 
                    Width="508px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
                Select language</td>
            <td>
                &nbsp;
                <asp:DropDownList ID="ddlanguage" runat="server">
                <asp:ListItem Text="Polish" Value="pl" Selected="True" />
                <asp:ListItem Text="German" Value="de" />
	                <asp:ListItem Text="French" Value="fr" />
                    <asp:ListItem Text="Swedish" Value="sv" />
                    <asp:ListItem Text="English" Value="en" />
                    <asp:ListItem Text="Chinese Simplified" Value="zh-cn" />
                    
                </asp:DropDownList>
                <asp:Button ID="btnTranslate" runat="server" onclick="btnTranslate_Click" 
                    Text="Translate" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
                Translated language</td>
            <td>
                &nbsp;
                <asp:Literal ID="ltTranslatetxt" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>

</asp:Content>

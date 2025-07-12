<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMP.Master" AutoEventWireup="true" CodeBehind="_Comments.aspx.cs" Inherits="diseasePrediction._Comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="Panel1" runat="server">

 <div class="container">

        <div class="section-title">
           <h2><span>VIEW TOPIC</span> COMMENTS !</h2>
        </div>
        <hr class="colorgraph">
        <div class="row">

   

    
     

      <br />
       

        <table align="center" style="width: 96%;">
            <tr style="font-size: small">
                <td>
                    <asp:Table ID="Table1" runat="server">
                    </asp:Table>
                </td>
            </tr>
        </table>
         <br />
       </div>

       </div>

       <br />

       <br />
    </asp:Panel>
</asp:Content>

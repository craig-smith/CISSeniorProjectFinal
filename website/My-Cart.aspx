<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="My-Cart.aspx.cs" Inherits="My_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(window).ready(function () {
            var name = "";
            $("#btnOrderNow").click(function () {
                $('input:checked').each(function () {                  
                        name += $(this).attr('name') + ",";        
                                         
                });
                $("#checkBoxValues").val(name);
            });
        });
        $(window).ready(function () {
            var name = "";
            $("#btnRemoveItend").click(function () {
                $('input:checked').each(function () {
                    name += $(this).attr('name') + ",";

                });
                $("#checkBoxValues").val(name);
            });
        });
      
        
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:HiddenField ID="checkBoxValues" runat="server" ClientIDMode="Static"/>
    <h1>My Cart</h1>
    <asp:PlaceHolder ID="cartItemsPlaceholder" runat="server"></asp:PlaceHolder>
    <div id="cart-order-now">
        <asp:Button ID="btnOrderNow" Text="Order Now" runat="server" ClientIDMode="Static" OnClick="btnOrderNow_Click" />
    </div>
    <div id="cart-remove-item">
        <asp:Button ID="btnRemoveItend" Text="Remove Items" runat="server" ClientIDMode="Static" OnClick="btnRemoveItend_Click" />
    </div>
</asp:Content>


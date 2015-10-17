<%@ Page Title="" Language="C#" MasterPageFile="~/CISSeniorProjectMasterPage.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function addToCart(itemId){
            try {
                serializedParams = JSON.stringify(itemId);
                $.ajax(
                {
                    type: "POST",
                    async: true,
                    url: "AddToCart.asmx/addItem",
                    host: "localhost",
                    data: "{itemId:'" + itemId + "'}",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: OnSuccessHandler,
                    error: OnFailureHandler
                });
            }
        catch(e){
            window.alert(e);
        }

        return;

        }

        function OnSuccessHandler(result, response){
            var result = result.d;
            if (result == true) {
                window.alert('Item added to cart');
                $('#lblCartItems').text("Item Added to Cart");
            }
            else {
                window.alert('Sorry there was an error. Please try again.');
            }
           
        }
       function OnFailureHandler(result, response){
            window.alert('Sorry there was an error. Please try again. ' + result.d + ' ' + response.d);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:PlaceHolder ID="productsPlaceHolder" runat="server"></asp:PlaceHolder>

    <asp:PlaceHolder ID="productsLinksPlaceHolder" runat="server"></asp:PlaceHolder>
</asp:Content>


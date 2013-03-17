

function AddProductToShoppingCart(productID)
{
    $('#hdnProductID').val(productID);
    $('#hdnQuantity').val($('#quantity_' + productID).val());
    
    $('#mainShoppingForm').submit();
} 
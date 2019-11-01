var cart = {
    init: function () {
        cart.registerEvents();
    },

    registerEvents: function () {

        $('#btn-update').off('click').on("click", function (e) {
            var listProduct = $('.quantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    quantity: $(item).val(),
                    product: {
                        id_product: $(item).data('id')
                    }
                });

            });

            $.ajax({
                url: "/Cart/Update",
                data: { cartModel: JSON.stringify(cartList) },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        //window.location.href="/Cart"
                        
                    }
                }
            });
        });
        $('#btn-delete').off('click').on("click", function (e) {
            e.preventDefault(); 
            $.ajax({
                url: "/Cart/Delete",
                data: { id: $(this).data('id') },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        window.location.href = "/Cart"
                    }
                }
            });
        });
    }
}
cart.init();
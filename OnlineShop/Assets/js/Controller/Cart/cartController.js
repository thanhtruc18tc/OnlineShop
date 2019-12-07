        function tempAlert(msg, duration) {
            var el = document.createElement("div");
            el.setAttribute("style", "position:absolute;top:55%;width:100%;background-color:white;text-align:center;line-height:90px;font-size:20px");
            el.innerHTML = msg;
            setTimeout(function () {
                el.parentNode.removeChild(el);
            }, duration);
            document.body.appendChild(el);
        }
        
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
                    sizeId: $(item).val(),
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
                    } else {
                        tempAlert(response.message,2000)
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
var cart = {
    init: function () {
        cart.releaseEvents();
    },
    releaseEvents: function () {
        $('#btnContinue').off("click").on("click", function () {
            window.location.href = "/";
        }) // trở lại mua tiếp


        $('#btnPayment').off("click").on("click", function () {
            window.location.href = "/thanh-toan";
        }) // trở lại mua tiếp


      






        $('.btn-update').off("click").on("click", function (e) {
            e.preventDefault();
            var productID = $(this).data('id');
            var quantity = $('.amount-cart[data-cart="' + productID + '"]').val();
            var cartList = [];
            cartList.push(
                {
                    Quantity: quantity,
                    sach: {
                        ID: productID
                    }
                }
        
            );

            $.ajax({
                url: "/Cart/Update",
                dataType: "json",
                data: { cartList: JSON.stringify(cartList) },
                type: "POST",
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }

            });// truyền lên sever
           

        })// update giỏ hàng



        $('#btnDeleteAll').off("click").on("click", function () {
            if (confirm("Bạn có chắc chắn muốn xóa giỏ hàng này !")) {
                $.ajax({
                    url: "/Cart/DeleteAll",
                    dataType: "json",
                    type: "POST",
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/gio-hang";
                        }
                    }

                });
            }

        }); //delete all Cart


        $('.btn-delete').off("click").on("click", function (e) {
            e.preventDefault();
            if (confirm("Bạn có muốn xóa bản ghi này không!")) {
                $.ajax({
                    url: "/Cart/Delete",
                    data: { id: $(this).data('id') },
                    dataType: "json",
                    type: "POST",
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/gio-hang";
                        }
                    }
                })
            }

        })// xóa từng bản ghỉ




        // input trong giỏ hàng










        $('.amount-cart').on("change", function () {
            var cartValue = $(this).attr("value");
            var maxCart = $(this).attr('max-cart');
            var amountValue = $(this).val();// giá trị input

            if (isNaN(amountValue) || amountValue == 0) {
                $(this).val(cartValue);


            }
            else if (parseInt(amountValue) > parseInt(maxCart)) {
                alert("Số lượng vượt quá " + maxCart);
                $(this).val(cartValue);
            }
        });// sự kiện khi nhập giá trị vào input nhấp chuột ra




        $('.plus-cart').on("click", function () {
            var productId = $(this).data('cart'); // data-cart của nút +
            var itemCart = $('.amount-cart[data-cart="' + productId + '"]'); // Tìm phẩn tử input có data-cart
            var maxCart = itemCart.attr('max-cart');
            // lấy giá trị input
            var amountValue = parseInt(itemCart.val());// giá trị input
            if (parseInt(amountValue) < parseInt(maxCart) ) {
                amountValue++;
                itemCart.val(amountValue);// val(1): hiện 1 chứ không phải nó tăng

            }
            else {
                alert("Số lượng vượt quá " + maxCart);
            }


        }) // sk click tăng 

        $('.minus-cart').on("click", function () {
            var productId = $(this).data('cart');
            var itemCart = $('.amount-cart[data-cart="' + productId + '"]'); // Tìm phẩn tử input có data-cart

            var amountValue = parseInt(itemCart.val())// giá trị input
            var maxCart = itemCart.attr('max-cart');

           
            if (parseInt(amountValue)> 1 &&  parseInt(amountValue) < parseInt(maxCart)) {

                amountValue--;
                itemCart.val(amountValue);
            }

        })// sk giảm



























        //end releaseEvents
    }
}
cart.init();
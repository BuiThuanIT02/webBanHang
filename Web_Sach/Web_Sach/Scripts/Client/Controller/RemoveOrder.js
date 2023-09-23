var order = {
    init: function () {
        order.releaseEvents();
    },
    releaseEvents: function () {

       
        $('.moveOrder').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('order-id');
   
            if (confirm("Bạn có muốn hủy đơn hàng này không!!")) {
                $.ajax({
                    url: "Order/RemoveOrder",
                    data: { id: id },
                    type: "POST",
                    dataType: "json",
                    success: function (res) {
                        if (res.status) {

                            $('#orderRow_' + id).remove();
                            alert("Hủy đơn hàng thành công");
                        }
                        else {
                            alert("Hủy đơn hàng thất bại");
                        }
                    }
                })
            }

        }) // end

        //nhận hàng thành công
        $('.getOrer').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('order-id');
            $.ajax({
                url: "Order/GetOrder",
                data: { id: id },
                type: "POST",
                dataType: "json",
                success: function (res) {
                    if (res.status) {
                        alert("Đơn hàng giao thành công!!");
                        $('#orderRow_' + id).remove();
                    }
                   

                }
            })

            //end
        })











    }
}
order.init();
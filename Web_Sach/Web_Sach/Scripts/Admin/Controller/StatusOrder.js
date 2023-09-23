var orderStatus = {
    init: function () {
        orderStatus.releaseEvents();
    },
    releaseEvents: function () {
        $(".orderChange").off("click").on("click", function () {
            var id = $(this).data("order-id");
            $.ajax({
                url: "Order/ChangeStatus",
                data: { id: id },
                type: "POST",
                dataType: "json",
                success: function (res) {
                    if (res.status) {

                    }
                }
            })
        })



        //end
    }
}
orderStatus.init();
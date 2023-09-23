


var user =  {
    init: function() {
        user.registerEvents();

    },
    registerEvents: function() {
        // sk trangj thai
        $('.btn-active').off('click').on("click", function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: '/Admin/User/ChangeStatus',
                data: { id: id },
                dataType: 'json',
                type: 'POST',
                success: function (res) {

                    if (res.status==true) {
                        btn.text("Kích hoạt");
                        btn.addClass('btn-start-text text-success');
                        btn.removeClass('btn-block-text text-danger')
                    }

                    else {
                        btn.text("Khóa");
                        btn.addClass('btn-block-text text-danger');
                        btn.removeClass('btn-start-text text-success');
                    }
                }
            });


        });


        //end su kien trang thai



















        

































    }
}
user.init();
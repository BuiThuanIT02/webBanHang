var sort = {
    init: function () {
        sort.releaseEvents();
    },

    releaseEvents: function () {

        $("#select_Sort").on("change", function () {


            var selectedValue = $(this).val();
            if (selectedValue) {
                $.ajax({
                    url: selectedValue,
                  
                    type:"POST",
                    success: function (data) {
                        // Cập nhật phần tử trang web mục tiêu với nội dung trả về từ action
                        $("#product-category").contents(data);
                    }
                });
            }





        })

  








        // chưa sử dụng









      //end
    }





























}



      











  
    



sort.init();








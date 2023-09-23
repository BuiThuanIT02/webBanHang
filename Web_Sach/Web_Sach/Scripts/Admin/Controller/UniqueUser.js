




var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {

       //tên tài khoản không được trùng

        $('#idUser').blur(function () {
            var userName = $(this).val();
            $.ajax({
                url: '/Admin/User/IsUsernameUnique',
                data: { TaiKhoan1: userName },
                dataType: 'json',
                type: 'POST',

                success: function (res) {
                    if (res.status == false) {
                        $('#userName-error').text("Tên tài khoản đã tồn tại.");
                    }
                    else {
                        $('#userName-error').text("");
                    }
                }


            });

        });

        // end tên tài khoản trùng

        //kiểm tra mật khẩu đúng 

        $("#password").on("input", function () {
            var password = $(this).val();

            // Kiểm tra độ dài mật khẩu
            if (password.length < 8) {
                // Hiển thị thông báo lỗi
                $(this).next(".text-danger").text("Mật khẩu phải có ít nhất 8 ký tự.");
            } else {
                // Kiểm tra xem mật khẩu có ít nhất một chữ cái viết hoa và một số
                if (/[A-Z]/.test(password) && /\d/.test(password)) {
                    $(this).next(".text-danger").text(""); // Mật khẩu hợp lệ
                } else {
                    $(this).next(".text-danger").text("Mật khẩu phải chứa ít nhất một chữ cái viết hoa và một số.");
                }
            }
        });

        // end kiểm tra mật khẩu










       
         
    }
}
user.init();

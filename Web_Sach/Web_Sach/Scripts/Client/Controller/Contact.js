var contact = {
    init: function () {
        contact.releaseEvents();
    },
    
    releaseEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val();
            var mobile = $('#txtMobile').val();
            var address = $('#txtAddress').val();
            var email = $('#txtEmail').val();

          
            $.ajax({
                url: "/Contact/Send",
                data: {
                    name: name,
                    mobile: mobile,
                    address: address,
                    email: email,
                    content: content,
                },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.alert("Gửi thành công!!!");
                        contact.resetform();
                    }

                }


            });
            
          


        });
    },


    resetform: function () {
        $('#txtName').val('');
        $('#txtMobile').val('');
         $('#txtAddress').val('');
        $('#txtEmail').val('');

    }
}
contact.init();
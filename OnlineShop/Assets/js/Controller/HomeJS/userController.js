var user = {
    init: function () {
        user.registerEvents();
    },

    registerEvents: function () {
       
        $('.btn-change').off('click').on("click", function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            
            $.ajax({
                url: "/Admin/Account/Change",
                data: {id: id},
                dataType: "json",
                type: "POST",
                success: function (response) {
                    $('#table').load('Account.cshtml #table', function(){
                        
                    });
                }
            });
        });
    }
}
user.init();
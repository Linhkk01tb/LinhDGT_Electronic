
    try {
        
        //Đóng form chỉnh sửa
        $("#menu-category").click(function () {
            $("#category-items").toggle();
        })
        $("#menu-trademark").click(function () {
            $("#trademark-items").toggle();
        })
        $(".user").click(function () {
            $(".user-control-arrow").toggle();
            $(".user-control-item").toggle();
        })
        $("#button-themdanhmuc").click(function () {
            $("#pop-up-themdanhmuc").show();
        })
        $(".exit-pop-up").click(function () {
            $("#pop-up-themdanhmuc-thongbaohuy").show();
        })
        $(".exit-pop-up-cancel-add-note").click(function () {
            $("#pop-up-themdanhmuc-thongbaohuy").hide();
        })
    } catch (error) {
        console.log(error);
    }
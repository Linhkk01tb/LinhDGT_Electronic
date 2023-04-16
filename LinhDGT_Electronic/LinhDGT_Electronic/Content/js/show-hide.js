
    try {
        
        //Đóng form chỉnh sửa
        $("#menu-category").click(function () {
            $("#category-items").toggle();
        })
        $("#menu-trademark").click(function () {
            $("#trademark-items").toggle();
        })
        $(".user").click(function () {
            $(".user-control").toggle();
        })
    } catch (error) {
        console.log(error);
    }
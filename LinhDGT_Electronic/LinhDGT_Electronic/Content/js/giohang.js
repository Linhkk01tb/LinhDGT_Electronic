$(document).ready(function () {
    HienThiSoLuongTrongGioHang();
    $('body').on('click', '.btnAddShoppingCart', function (e) {

        e.preventDefault();
        var id = $(this).data('id');
        var soluongmua = 1;
        var soluongdf = 1;
        var txtSoluongmua = $('#soluongmua').val();
        if (txtSoluongmua != null) {
            soluongmua = parseInt(txtSoluongmua);
        }
        else soluongmua = parseInt(soluongdf);

        $.ajax({
            url: '/giohang/themvaogiohang',
            type: 'POST',
            data: { id: id, soluongmua: soluongmua },
            success: function (rs) {
                if (rs.success) {

                    $('#category_item').html(rs.count);

                    alert(rs.msg);
                }
            }
        });

    });
    $('body').on('click', '.button-delete-sanpham-by-id', function () {
        var id = $(this).data("id");
        var conf = confirm('Xoá sản phẩm khỏi giỏ hàng?');
        if (conf === true) {
            $.ajax({
                url: '/giohang/xoasanpham',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.success) {
                        $('#row_sanpham_' + id).remove();
                        location.reload();
                        $('#category_item').html(rs.count);

                        alert(rs.msg);
                    }

                }
            });
        }
    });

});

function HienThiSoLuongTrongGioHang() {
    $.ajax({
        url: '/giohang/hienthisoluongtronggiohang',
        type: 'GET',
        success: function (rs) {

            $('#category_item').html(rs.count);
        }
    });
}
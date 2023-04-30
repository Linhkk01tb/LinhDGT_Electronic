using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhDGT_Electronic.Models
{
    public class GioHang
    {
        public List<GioHangItem> Items { get; set; }

        public GioHang()
        {

            this.Items = new List<GioHangItem>();
        }

        public void ThemVaoGioHang(GioHangItem item, int soluongmua)
        {
            var checkExist = Items.FirstOrDefault(x => x.SanPhamID == item.SanPhamID);
            if (checkExist != null)
            {
                checkExist.SanPhamBuyQuantity += soluongmua;
                checkExist.Total = checkExist.SanPhamUnitPrice * soluongmua;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void XoaKhoiGioHang(int id)
        {
            var checkExist = Items.SingleOrDefault(x=>x.SanPhamID ==id);
            if(checkExist != null)
            {
                Items.Remove(checkExist);
            }
        }

        public void CapNhatSoluong(int id, int soluongmua)
        {
            var checkExist = Items.SingleOrDefault(x => x.SanPhamID == id);
            if (checkExist != null)
            {
                checkExist.SanPhamBuyQuantity = soluongmua;
                checkExist.Total = checkExist.SanPhamUnitPrice * soluongmua;
            }
        }

        public double TinhTongTien()
        {
            return Items.Sum(x => x.Total);
        }
        public double TinhTongSoLuong()
        {
            return Items.Sum(x => x.SanPhamBuyQuantity);
        }

        public void DonSachGioHang()
        {
            Items.Clear();
        }
    }
    public class GioHangItem
    {
        public int SanPhamID { get; set; }
        public string SanPhamName { get; set; }

        public string SanPhameImage { get; set; }

        public int SanPhamBuyQuantity { get; set; }

        public double SanPhamUnitPrice { get; set; }

        public double Total { get; set; }
    }
}
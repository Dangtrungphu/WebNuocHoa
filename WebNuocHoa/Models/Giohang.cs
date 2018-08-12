using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebNuocHoa.Models;

namespace WebNuocHoa.Models
{
    public class Giohang
    {
        //Tao doi tuong data chua dữ liệu từ model  đã tạo. 
        DbQLNuochoaDataContext data = new DbQLNuochoaDataContext();
        public int iMaNH { set; get; }
        public string sTenNH { set; get; }
        public string sAnhbia { set; get; }
        public Double dGiaBan { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dGiaBan; }

        }
        //Khoi tao gio hàng theo MaLT duoc truyen vao voi Soluong mac dinh la 1
        public Giohang(int MaLT)
        {
            iMaNH = MaLT;
            SANPHAM nh = data.SANPHAMs.Single(n => n.MaNH == iMaNH);
            sTenNH = nh.TenNH;
            sAnhbia = nh.Anhbia;
            dGiaBan = double.Parse(nh.Giaban.ToString());
            iSoluong = 1;
        }
    }
}
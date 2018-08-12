using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNuocHoa.Models;

namespace WebNuocHoa.Controllers
{
    public class TrangchuController : Controller
    {
        DbQLNuochoaDataContext data = new DbQLNuochoaDataContext();

        private List<SANPHAM> LayHetSP()
        {
            return data.SANPHAMs.OrderByDescending(a => a.Ngaycapnhat).ToList();
        }
        // GET: Trangchu
        public ActionResult Trangchu(FormCollection fc)
        {
            string tk = fc["Search"];

            //int pageNum = (page ?? 1);
            if (Session["Taikhoan"] != null)
            {
                KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
                ViewBag.TenKH = "Chào  " + kh.HoTen;
                ViewBag.MaKH = kh.MaKH;
            }
            if (tk != null && tk != "")
            {
                var fullnh = (from n in data.SANPHAMs where n.TenNH.ToUpper().Contains(tk.ToUpper()) select n).ToList();
                return View(fullnh);
            }
            else
            {
                var fullnh = (from n in data.SANPHAMs select n).ToList();
            return View(fullnh);
            }
        }
        public ActionResult Search()
        {
            return PartialView();
        }
        public ActionResult HangSX()
        {
            var hang = from hsx in data.HANGSXes select hsx;
            return PartialView(hang);
        }
        public ActionResult SPTheoHang(int id)
        {
            //int pageSize = 5;
            // int pageNum = (page ?? 1);
            if (Session["Taikhoan"] != null)
            {
                KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
                ViewBag.TenKH = "Chào  " + kh.HoTen;
                ViewBag.MaKH = kh.MaKH;
            }
            var nuochoa = from lt in data.SANPHAMs where lt.MaHang == id select lt;
            return View(nuochoa);
        }
        public ActionResult Details(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
                ViewBag.TenKH = "Chào  " + kh.HoTen;
                ViewBag.MaKH = kh.MaKH;
            }
            var nh = from s in data.SANPHAMs
                     where s.MaNH == id
                     select s;
            return View(nh.Single());
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {

            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendn = collection["Taikhoan"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (kh)
                KHACHHANG kh = data.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Trangchu", "Trangchu");
        }
        public ActionResult Dangxuat()
        {
            Session["Taikhoan"] = null;
            return RedirectToAction("Trangchu");
        }
       
        public ActionResult ThongtinKH(FormCollection fc)
        {
            if (Session["Taikhoan"] != null)
            {
                KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
                ViewBag.TenKH = "Chào  " + kh.HoTen;
                ViewBag.MaKH = kh.MaKH;
                ViewBag.ht = kh.HoTen;
                ViewBag.dt = kh.DienthoaiKH;
                ViewBag.dc = kh.DiachiKH;
                ViewBag.email = kh.Email;
                ViewBag.ns = kh.Ngaysinh;

                int tk = kh.MaKH;
                var fullnh = (from n in data.thongtinKHs where n.MaKH == tk select n).ToList();

                return View(fullnh);
            }
            else
            {
                ViewBag.thongbao = "Đăng nhập trước khi xem nhé";
                return View() ;
            }
            //var thongtin = (from kh in data.KHACHHANGs
            //                join dh in data.DONDATHANGs on kh.MaKH equals dh.MaKH
            //                from ct in data.CHITIETDONTHANGs
            //                join dh1 in data.DONDATHANGs on ct.MaDonHang equals dh1.MaDonHang
            //                from sp in data.SANPHAMs
            //                join ct1 in data.CHITIETDONTHANGs on sp.MaNH equals ct1.MaNH
            //               select new
            //               {
            //                   sp.TenNH,
            //                   sp.Giaban,
            //                   ct.Soluong,
            //                   dh.Ngaygiao
            //               }).ToList();
          //  return View();
        }
        public ActionResult Lienhe()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDiemSinhVien.Models;

namespace QuanLyDiemSinhVien.Controllers
{
    [Authorize(Roles = "sinhvien02")]
    public class DiemsController : Controller
    {
        private QLDSVDbContext db = new QLDSVDbContext();

        // GET: Diems
        [AllowAnonymous]
        public ActionResult Index()
        {
            var diems = db.Diems.Include(d => d.MonHocs).Include(d => d.SinhViens);
            return View(diems.ToList());
        }

        // GET: Diems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diems/Create
        public ActionResult Create()
        {
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH");
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV");
            return View();
        }

        // POST: Diems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HocKy,MaSV,MaMH,DiemLan1,DiemLan2,DiemTrungBinh,XepLoai")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(diem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", diem.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diem.MaSV);
            return View(diem);
        }

        // GET: Diems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", diem.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diem.MaSV);
            return View(diem);
        }

        // POST: Diems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HocKy,MaSV,MaMH,DiemLan1,DiemLan2,DiemTrungBinh,XepLoai")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", diem.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diem.MaSV);
            return View(diem);
        }

        // GET: Diems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diem diem = db.Diems.Find(id);
            db.Diems.Remove(diem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            ////try
            {
                //upload file thanh cong va file co du lieu
                if (file.ContentLength > 0)
                {
                    //Your code
                    string _FileName = "Diems.xls";
                    //duong dan luu file
                    string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
                    //luu file len server
                    file.SaveAs(_path);
                    DataTable dt = ReadDataFromExcelFile(_path);

                    CopyDataByBulk(dt);
                }
            }
            // catch (Exception)

            //neu upload file that bai
            //  }
            return RedirectToAction("Index");
        }

        //doc file excel tra ve du lieu dang datatable
        public DataTable ReadDataFromExcelFile(string filepath)
        {
            string connectionString = "";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf("xlsx") == 0)
            {
                connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            else if (fileExtention.IndexOf(".xls") == 0)
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
            }

            // Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                // Mở kết nối
                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();

                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(ds);

                data = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Đóng chuỗi kết nối
                oledbConn.Close();
            }
            return data;
        }
        //copy large data from datatable to sqlserver
        private void CopyDataByBulk(DataTable dt)
        {
            //lay ket noi voi database luu trong file webconfig
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDSVDbContext"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            con.Open();
            bulkcopy.DestinationTableName = "Diems"; //ten table
            bulkcopy.ColumnMappings.Add(0, "HocKy"); //cot dau tien
            bulkcopy.ColumnMappings.Add(1, "MaSV");
            bulkcopy.ColumnMappings.Add(2, "MaMH");
            bulkcopy.ColumnMappings.Add(3, "DiemLan1");
            bulkcopy.ColumnMappings.Add(4, "DiemLan2");
            bulkcopy.ColumnMappings.Add(5, "DiemTrungBinh");
            bulkcopy.ColumnMappings.Add(6, "XepLoai");
            //bulkcopy.WriteToServer(dt);
            con.Close();
        }
        public ActionResult DownloadFile()
        {
            //duong dan chua file muon download
            string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Excels/";
            //chuyen file sang dang byte
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "SinhViens.xlsx");
            //ten file khi download ve
            string fileName = "SinhViens.xlsx";
            //tra ve file
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}

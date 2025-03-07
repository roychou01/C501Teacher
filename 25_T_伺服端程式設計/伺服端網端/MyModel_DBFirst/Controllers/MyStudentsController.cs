using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_DBFirst.Models;
using MyModel_DBFirst.ViewModels;

namespace MyModel_DBFirst.Controllers
{
    public class MyStudentsController : Controller
    {
        //4.1.4 撰寫建立DbContext物件的程式
        //dbStudentsContext db = new dbStudentsContext();


        private readonly dbStudentsContext db;

        public MyStudentsController(dbStudentsContext context)
        {
            db = context;
        }


        //4.2   建立同步執行的Index Action
        public IActionResult Index(string deptid="01")
        {
            //4.2.1 撰寫Index Action程式碼
            //把資料庫tStudent資料表的資料取出,回傳給View

            //select * from tStudent (把資料庫tStudent資料表的資料取出)

            //Linq
            //select * from tStudent 

            //5.5.1 修改 Index Action
            //var student = db.tStudent.Include(s=>s.Department).ToList();
            //return View(student);  //回傳給View


            //5.8.4 修改MyStudnetsController裡的Index Action

            VMtStudent students = new VMtStudent() 
            {
                Students= db.tStudent.Where(s=>s.DeptID== deptid).ToList(),
                Departments=db.Department.ToList()
            };

            ViewData["DeptName"] = db.Department.Find(deptid).DeptName;
            ViewData["DeptID"] = deptid;

            return View(students);

        }

        //4.3   建立同步執行的Create Action
        //4.3.1 撰寫Create Action程式碼(需有兩個Create Action)
        //5.9.2 修改Get Create Action進行參數傳遞
        public IActionResult Create(string deptid)
        {

            //db.Department
            //5.5.3 修改 Create Action
            ViewData["Department"] = new SelectList(db.Department, "DeptID", "DeptName");
            
            ViewData["DeptID"] = deptid;//5.9.2 修改Get Create Action進行參數傳遞

            return View();
        }

        //4.3.6 加入Token驗證標籤
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(tStudent tStudent)
        {

            //將tStudent表單資料寫入資料庫
            //新增資料-Insert

            //4.3.7 加入檢查主鍵是否重覆的程式
            //select * from tStudent where fStuId='113004'
            var stu = db.tStudent.Find(tStudent.fStuId);

            if (stu != null) 
            {
                ViewData["ErrorMsg"] = "該學號已經有人使用";
                return View(tStudent);
            }


            if (ModelState.IsValid)
            {
                db.Add(tStudent);
                db.SaveChanges(); //它會轉譯成 insert into tStudent values('113004','John','abc@abc.com',88)

                                            //5.9.3 修改Post Create Action進行參數傳遞
                return RedirectToAction("Index", new { deptid=tStudent.DeptID });
            }

            return View(tStudent);

        }


        //4.4.1 撰寫Edit Action程式碼(需有兩個Edit Action)
        //5.9.4 修改Get Edit Action進行參數傳遞
        public IActionResult Edit(string id,string deptid)
        {

            //select * from tStudent where fStuId=@id

            //Linq
            //var result = from s in db.tStudent
            //             where s.fStuId==id
            //             select s;

            var result = db.tStudent.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            //5.5.5 修改 Edit Action
            ViewData["Department"] = new SelectList(db.Department, "DeptID", "DeptName");

            ViewData["DeptID"] = deptid;//5.9.4 修改Get Edit Action進行參數傳遞
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(tStudent tStudent,string fStuId)
        {

            if (fStuId != tStudent.fStuId)
            {
                return View(tStudent);
            }


            if (ModelState.IsValid)
            {
                db.Update(tStudent);
                db.SaveChanges();  //轉成SQL的Update語法

                            //5.9.5 修改Post Edit Action進行參數傳遞
                return RedirectToAction("Index", new { deptid=tStudent.DeptID});
            }

            return View(tStudent);
        }

        //4.5.1 撰寫Delete Action程式碼
        //4.5.2 將Index的Delete改為Form，以Post方式送出

        [HttpPost]
        [ValidateAntiForgeryToken]
        //5.9.6 修改Post Delete Action進行參數傳遞
        public IActionResult Delete(string id)
        {
            //delete from tStudent where fStuId=@id

            var tStudent = db.tStudent.Find(id);

            if (tStudent!=null)
            {
                db.tStudent.Remove(tStudent);
                db.SaveChanges();  //轉成SQL的Delete語法

            }
                            //5.9.6 修改Post Delete Action進行參數傳遞
            return RedirectToAction("Index",new { deptid= tStudent.DeptID });

        }

    }
}

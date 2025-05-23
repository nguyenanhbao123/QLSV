using Microsoft.AspNetCore.Mvc;
using QLSV.Models;

namespace QLSV.Controllers
{
	public class StudentController : Controller
	{
		[Route("HomeStudent")] // định danh Action ListAll bằng homestudent
		[Route("Student")]
		[Route("Student/ListAll")]
		[Route("Liet-ke-danh-sach-sinh-vien")]

        public IActionResult ListAll()
        {
            List<Student> ListStudents = new List<Student>()
			{           
                new Student { Id = 1, Name = "Anh Bảo", Age = 19, Gender = true, ImgUrl = "\"https://c8.alamy.com/comp/2PWFXDF/student-avatar-illustration-simple-cartoon-user-portrait-user-profile-icon-youth-avatar-vector-illustration-2PWFXDF.jpg", Des = "Mô tả thông tin sinh viên" },

                new Student { Id = 2, Name = "Gia Bảo", Age = 19, Gender = false, ImgUrl = "https://c8.alamy.com/comp/2PWFXDF/student-avatar-illustration-simple-cartoon-user-portrait-user-profile-icon-youth-avatar-vector-illustration-2PWFXDF.jpg", Des = "Mô tả thông tin sinh viên" },
                new Student { Id = 3, Name = "Hồng Bảo", Age = 22, Gender = true, ImgUrl = "https://c8.alamy.com/comp/2PWFXDF/student-avatar-illustration-simple-cartoon-user-portrait-user-profile-icon-youth-avatar-vector-illustration-2PWFXDF.jpg", Des = "Mô tả thông tin sinh viên" },
                new Student { Id = 4, Name = "Đỏ Bảo", Age = 19, Gender = false, ImgUrl = "	https://c8.alamy.com/comp/2PWFXDF/student-avatar-illustration-simple-cartoon-user-portrait-user-profile-icon-youth-avatar-vector-illustration-2PWFXDF.jpg", Des = "Mô tả thông tin sinh viên" },
                new Student { Id = 5, Name = "Đỏ Bảo", Age = 11, Gender = true, ImgUrl = "https://c8.alamy.com/comp/2PWFXDF/student-avatar-illustration-simple-cartoon-user-portrait-user-profile-icon-youth-avatar-vector-illustration-2PWFXDF.jpg", Des = "Mô tả thông tin sinh viên" },
                new Student { Id = 6, Name = "Tím Bảo", Age = 19, Gender = true, ImgUrl = "https://c8.alamy.com/comp/2PWFXDF/student-avatar-illustration-simple-cartoon-user-portrait-user-profile-icon-youth-avatar-vector-illustration-2PWFXDF.jpgg", Des = "Mô tả thông tin sinh viên" },
            };
            return View(ListStudents);
        }

        //ContentResult
        [Route("Student/Index")]
		public ContentResult Index() 
		{
			return new ContentResult
			{
				Content = "Welcome to Student page",
				ContentType = "text/plain"
			};
		}
		//link tới 1 file trong sever
		[Route("File/Download-file")]
		
		
		public FileResult File() 
		{
			return File("/linq.pdf", "application/pdf");
		}
		[Route("Student/List")]

		public IActionResult ListOnlyStudent()
		{
			if (!Request.Query.ContainsKey("id"))
			{
				return BadRequest("Student ID is not provided");
			}
			int id = Convert.ToInt32(Request.Query["id"]);
			if (id<1 || id > 1000)
			{
				return NotFound("Student Id not match");
			}
			return Content("Thong tin sinh vien:" + id, "text/html");
				
		}
		[Route("Edit-student")]
		public IActionResult EditStudent()
		{
			return LocalRedirect("~/Home/Index");
		}

		public string ListOnlyOne()
		{
			return "liệt kê 1 sinh viên  có id cụ thể";
		}
		public IActionResult ListOnlyStudent([FromQuery]int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Student ID is not provided");
			}
			return Content($"Thong tin sinh vien {id}");
		}
		public string AddStudent()
		{
			return " Thêm thông tin sinh viên";
		}
		public string DelStudent()
		{
			return "Xóa thông tin 1 sinh viên";
		}
	}
}

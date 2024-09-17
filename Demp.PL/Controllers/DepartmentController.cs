using Demo.DAL.Models;
using Demo.PLL.Interfaces;
using Demo.PLL.Repositroies;
using Microsoft.AspNetCore.Mvc;

namespace Demp.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _DepartmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository )
        {
            _DepartmentRepository = departmentRepository;
            //_DepartmentRepository = new DepartmentRepository();
        }

        public IActionResult Index()
        {
           var department =  _DepartmentRepository.GetAll();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        { 

            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                int affectedRows = _DepartmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? departmentID , string ViewName = "Details")
        {
            if (departmentID is null) return BadRequest();
           
            var department = _DepartmentRepository.GetByID(departmentID.Value);
            if (department is null)
                return NotFound();
            
            return View(ViewName, department);
        }

        public IActionResult Edit(int? departmentID)
        {
            return Details(departmentID , "Edit");
        }


        [HttpPost]
        public IActionResult Edit(Department department ,[FromRoute] int departmentID)
        {
            if (ModelState.IsValid)
            {
                if (departmentID != department.ID)
                {
                    return BadRequest();
                }
                try
                {
                _DepartmentRepository.Update(department);
                return RedirectToAction(nameof(Index));

                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }
    }
}

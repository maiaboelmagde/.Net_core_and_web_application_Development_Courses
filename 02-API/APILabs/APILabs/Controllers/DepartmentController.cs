using APILabs.Context;
using APILabs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        StudentContext Context;
        public DepartmentController()
        {
            Context = new StudentContext();
        }
        [HttpGet]
        public IActionResult getAllDepartments()
        {
            var Depts = Context.Departments.ToList();

            if (Depts == null) return NotFound();
            return Ok(Depts);
        }

        [HttpGet("{id:int}")]
        public IActionResult getDepartmentById(int id)
        {
            var dept = Context.Departments.FirstOrDefault(s => s.Id == id);

            if (dept is null) return NotFound();
            return Ok(dept);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult getStudentByName(string name)
        {
            var stud = Context.Students.FirstOrDefault(s => s.Name == name);

            if (stud is null) return NotFound($" {name}");
            return Ok(stud);
        }


        [HttpPost]
        public IActionResult addDepartment(Department dept)
        {
            if (dept.Name == null) return BadRequest();

            Context.Departments.Add(dept);
            Context.SaveChanges();

            return CreatedAtAction(nameof(getDepartmentById), new { id = dept.Id }, new { message = "Student added successfully" });
        }

        [HttpPut]
        public IActionResult Edit(Department dept)
        {
            var checkDept = Context.Departments.FirstOrDefault(s => s.Id == dept.Id);

            if (checkDept is null) return NotFound();

            Context.Departments.Update(dept);
            Context.SaveChanges();

            return Ok(new { message = "Updated Successfully...." });
        }

        [HttpDelete("{id:int}")]
        public IActionResult deleteStudent(int id)
        {
            var dept = Context.Departments.FirstOrDefault(s => s.Id == id);

            if (dept is null) return NotFound();


            Context.Departments.Remove(dept);
            Context.SaveChanges();
            return Ok(dept);
        }
    }
}

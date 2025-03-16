using APILabs.Context;
using APILabs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentContext StdsContext;
        public StudentsController()
        {
            StdsContext = new StudentContext();
        }
        [HttpGet]
        public IActionResult getAllStudents()
        {
            var studs = StdsContext.Students.ToList();

            if(studs == null) return NotFound();
            return Ok(studs);
        }

        [HttpGet("{id:int}")]
        public IActionResult getStudentById(int id)
        {
            var stud = StdsContext.Students.FirstOrDefault(s=>s.Id == id);

            if (stud is null) return NotFound();
            return Ok(stud);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult getStudentByName(string name)
        {
            var stud = StdsContext.Students.FirstOrDefault(s => s.Name == name);

            if (stud is null) return NotFound($" {name}");
            return Ok(stud);
        }


        [HttpPost]
        public IActionResult addStudent(Student std)
        {
            if (std.Name == null) return BadRequest();

            StdsContext.Students.Add(std);
            StdsContext.SaveChanges();

            return CreatedAtAction(nameof(getStudentById), new {id=std.Id}, new {message = "Student added successfully"});
        }

        [HttpPut]
        public IActionResult Edit(Student std)
        {
            var checkStd = StdsContext.Students.FirstOrDefault(s => s.Id == std.Id);

            if (checkStd is null) return NotFound();

            StdsContext.Students.Update(std);
            StdsContext.SaveChanges();

            return Ok(new { message = "Updated Successfully...." });
        }

        [HttpDelete("{id:int}")]
        public IActionResult deleteStudent(int id)
        {
            var std = StdsContext.Students.FirstOrDefault(s => s.Id == id);

            if (std is null) return NotFound();


            StdsContext.Students.Remove(std);
            StdsContext.SaveChanges();
            return Ok(std);
        }

    }


}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentService.Model;
using StudentService.Service;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentRepository.Get(id);
            if(student is null) 
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            _studentRepository.Create(student);
            return Ok(_studentRepository.GetAll());
        }

        [HttpPut]
        public IActionResult Put(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();

            _studentRepository.Update(id, student);
            return Ok(_studentRepository.GetAll());

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _studentRepository.Delete(id);
            return Ok(_studentRepository.GetAll());
        }
    }
}

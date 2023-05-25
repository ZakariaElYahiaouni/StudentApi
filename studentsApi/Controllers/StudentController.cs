
using studentsApi.Dtos.Students;

namespace studentsApi.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentResponseDto>>> GetSingleStudent(int id)
        {
            return Ok(await _studentService.GetSingleStudent(id));
        }
        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<GetStudentResponseDto>>>> InsertStudent(AddStudentRequestDto _student)
        {

            return Ok(await _studentService.InsertStudent(_student));
        }
        
        [HttpPut()]
        public async Task<ActionResult<ServiceResponse<List<GetStudentResponseDto>>>> UpdateStudent(UpdateStudentRequestDto studentUpdated)
        {
           var response = (await _studentService.UpdateSingleStudent(studentUpdated)); 
           if(response.Data is null){
                return NotFound(); 
           }
            return response; 
        }
 
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentResponseDto>>>> RemoveSingleStudent(int id){
            
            var response = (await _studentService.RemoveSingleStudent(id));
            if(response.Data is null){
                return NotFound(); 
            }
            return Ok(response);
            
        }
        
    }
}
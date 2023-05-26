


namespace studentsApi.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService studentService)
        {
            _toDoService = studentService;
        }

        [HttpGet("")]
        public async Task<ActionResult<ServiceResponse<ToDoDTO>>> GetAllToDos()
        {
            return Ok(await _toDoService.GetAllToDos());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<List<ToDoDTO>>>> GetSingleToDo(int id)
        {
            return Ok(await _toDoService.GetToDoById(id));
        }




        [HttpPut()]
        public async Task<ActionResult<ServiceResponse<List<ToDoDTO>>>> UpdateTodo(ToDoDTO todoUpdated)
        {
            return Ok(await _toDoService.UpdateSingleToDo(todoUpdated));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResponse<List<ToDoDTO>>>> DeleteSingleTodo(int id)
        {
            return Ok(await _toDoService.DeleteSingleTodo(id));
        }

        [HttpPost]
              public async Task<ActionResult<ServiceResponse<List<ToDoDTO>>>> CreateToDo(ToDoCreateDTO newToDo)
        {
            return Ok(await _toDoService.CreateNewTodo(newToDo));
        }

        /*



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
        */

    }
}
using System.ComponentModel.Design;

public class ToDoService : IToDoService
{
    private static List<ToDoDTO> todos;
    private readonly IMapper _mapper;
    private ClassConnection cc = new ClassConnection();

    private string connectionString = @"Data Source=srvsql2022\onboarding;Initial Catalog=ziko;Integrated Security=True;Encrypt=False";
    public ToDoService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<ServiceResponse<List<ToDoDTO>>> GetAllToDos()
    {
        todos = new List<ToDoDTO>();
        var serviceResponse = new ServiceResponse<List<ToDoDTO>>();
        todos = cc.GetAllToDo(connectionString);
        serviceResponse.Data = todos;


        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ToDoDTO>>> GetToDoById(int id)
    {
        todos = new List<ToDoDTO>();
        var serviceResponse = new ServiceResponse<List<ToDoDTO>>();
        todos.Add(cc.GetToDoById(connectionString, id));
        serviceResponse.Data = todos;


        return serviceResponse;
    }



    public async Task<ServiceResponse<List<ToDoDTO>>> UpdateSingleToDo(ToDoDTO todoUpdated)
    {
        todos = new List<ToDoDTO>();
        var serviceResponse = new ServiceResponse<List<ToDoDTO>>();
        todos = cc.EditRow(connectionString, todoUpdated);
        serviceResponse.Data = todos;


        return serviceResponse;

    }
    public async Task<ServiceResponse<List<ToDoDTO>>> DeleteSingleTodo(int id)
    {
        todos = new List<ToDoDTO>();
        var serviceResponse = new ServiceResponse<List<ToDoDTO>>();
        todos = cc.DeleteRow(connectionString, id);
        serviceResponse.Data = todos;


        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ToDoDTO>>> CreateNewTodo(ToDoCreateDTO newToDo)
    {
        todos = new List<ToDoDTO>();
        var serviceResponse = new ServiceResponse<List<ToDoDTO>>();
        todos = cc.NewRow(connectionString, newToDo);
        serviceResponse.Data = todos;


        return serviceResponse;

    }
}


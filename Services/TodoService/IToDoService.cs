




public interface IToDoService
{


    Task<ServiceResponse<List<ToDoDTO>>> GetAllToDos();

    Task<ServiceResponse<List<ToDoDTO>>> GetToDoById(int id);
    Task<ServiceResponse<List<ToDoDTO>>> UpdateSingleToDo(ToDoDTO todoUpdated);
    Task<ServiceResponse<List<ToDoDTO>>> DeleteSingleTodo(int id);

    Task<ServiceResponse<List<ToDoDTO>>> CreateNewTodo(ToDoCreateDTO newToDo);



}


public class StudentService : IStudentService
{
    private static List<Student> students = new List<Student>(){
        new Student{IdStudent = 1, NameStudent = "Zakaria", SurnameStudent = "Noubhani", NationalNumberStudent = "2342", Residence = "Piacenza"},
        new Student{IdStudent = 2, NameStudent = "Matteo", SurnameStudent = "Peveri", NationalNumberStudent = "2322", Residence = "Piacenza"},
        new Student{IdStudent = 3, NameStudent = "Ziko", SurnameStudent = "El Yahiaouni", NationalNumberStudent = "1232", Residence = "Piacenza"},
    };

    private readonly IMapper _mapper;
    public StudentService(IMapper mapper)
    {
        _mapper = mapper; 
    }
    public async Task<ServiceResponse<List<GetStudentResponseDto>>> GetAllStudents()
   {
        var serviceResponse = new ServiceResponse<List<GetStudentResponseDto>>();
        serviceResponse.Data = students.Select(s => _mapper.Map<GetStudentResponseDto>(s)).ToList();
        return serviceResponse; 
    }

    public async Task<ServiceResponse<GetStudentResponseDto>> GetSingleStudent(int id)
    {
        var serviceResponse = new ServiceResponse<GetStudentResponseDto>(); 
        var singleStudent = students.FirstOrDefault(s => s.IdStudent == id);
        serviceResponse.Data =  _mapper.Map<GetStudentResponseDto>(singleStudent);
        return serviceResponse;

    }

    public async Task<ServiceResponse<List<GetStudentResponseDto>>> InsertStudent(AddStudentRequestDto student)
    {
        var serviceResponse = new ServiceResponse<List<GetStudentResponseDto>>(); 
        students.Add(_mapper.Map<Student>(student)); 
        serviceResponse.Data = students.Select(s => _mapper.Map<GetStudentResponseDto>(s)).ToList();
        return serviceResponse; 

    }


}


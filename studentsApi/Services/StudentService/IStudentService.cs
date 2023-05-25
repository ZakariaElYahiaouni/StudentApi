


    using studentsApi.Dtos.Students;

    public interface IStudentService
    {
        //Task<ServiceResponse<List<GetStudentResponseDto>>>GetAllStudents();
        Task<ServiceResponse<List<GetStudentResponseDto>>> InsertStudent(AddStudentRequestDto student);
        Task<ServiceResponse<GetStudentResponseDto>> GetSingleStudent(int id);
      Task<ServiceResponse<List<GetStudentResponseDto>>> UpdateSingleStudent(UpdateStudentRequestDto studentUpdated);

    }


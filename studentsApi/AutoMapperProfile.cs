using studentsApi.Dtos.Students;

public class AutoMapperProfile : Profile{
    public AutoMapperProfile(){
        CreateMap<Student, GetStudentResponseDto>(); 
        CreateMap<AddStudentRequestDto, Student>(); 
      
    }
}
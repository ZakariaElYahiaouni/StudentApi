namespace studentsApi.Dtos.Students;

public class UpdateStudentRequestDto
{
    public int IdStudent { get; set; }
    public string NameStudent { get; set; } = string.Empty;
    public string SurnameStudent { get; set; } = string.Empty;
    public string NationalNumberStudent { get; set; } = string.Empty;
    public string Residence { get; set; } = string.Empty;
    public Gender Gender { get; set; }
}
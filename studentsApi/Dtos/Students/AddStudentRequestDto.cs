public class AddStudentRequestDto
{
    //properties
    public string NameStudent { get; set; } = string.Empty;
    public string SurnameStudent { get; set; } = string.Empty;
    public string NationalNumberStudent { get; set; } = string.Empty;
    public string Residence { get; set; } = string.Empty;
    public Gender Gender { get; set; }
}
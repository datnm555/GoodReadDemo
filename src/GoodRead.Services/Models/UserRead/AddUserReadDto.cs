namespace GoodRead.Services.Models.UserRead;

public class AddUserReadDto
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public  byte Status { get; set; }
}
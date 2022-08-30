namespace GoodRead.Services.Models.UserRead;

public class UserReadCompleteDto
{
    public int UserId { get; set; }

    public List<UserReadBookDto> UserReadBookDtos { get; set; }
}

public class UserReadBookDto
{
    public int Id { get; set; }
    public BookDto BookDto { get; set; }
}
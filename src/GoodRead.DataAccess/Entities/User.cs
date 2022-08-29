namespace GoodRead.DataAccess.Entities;
public class User
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
}

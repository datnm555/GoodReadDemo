namespace GoodRead.DataAccess.Entities;
public class User
{
    public User()
    {
        Books = new HashSet<Book>();
    }

    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public ICollection<Book> Books { get; set; }

}

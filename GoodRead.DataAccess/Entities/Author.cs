namespace GoodRead.DataAccess.Entities;

public class Author : AuditableEntity
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    //public ICollection<Book> Books { get; set; }
}
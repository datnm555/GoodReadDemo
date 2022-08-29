namespace GoodRead.DataAccess.Entities;

public class Book : AuditableEntity
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Name { get; set; }

    [MaxLength(5000)]
    public string Description { get; set; }

}
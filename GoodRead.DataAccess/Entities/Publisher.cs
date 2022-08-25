namespace GoodRead.DataAccess.Entities;

public class Publisher : AuditableEntity
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

}
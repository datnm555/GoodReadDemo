namespace GoodRead.DataAccess.Entities
{
    public class Book : AuditableEntity
    {
        public Book()
        {
            Users = new HashSet<User>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

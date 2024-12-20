using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.Auth
{
    [Table("roleclaim")]
    public class RoleClaim : BaseEntity
    {
        [Column("role_name")]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("about_me")]
    public class AboutMe : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("profession")]
        public string Profession { get; set; }

        //Profession hissesi daha sonra mutiple option ucun ayri bir table kimi yaradila biler ve dropwodn listden goturuler.
    }
}

using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{

    [Table("experience")]
    public class Experience : BaseEntity
    {
        [Column("position")]
        public string Position { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("company_name")]
        public string CompanyName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("entered_time")]
        public string EnteredTime { get; set; }
    }
}

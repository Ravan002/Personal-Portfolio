using Entities.Abstract;

namespace Entities.Dtos.AboutMeDtos
{
    public class AboutMeDto : IDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Profession { get; set; }
    }
}

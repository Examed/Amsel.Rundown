using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownElementDTO
    {
        public string Parameters { get; set; }

        public ERundownFlags RequiredFlags { get; set; }

        public ERundownSequence Sequence { get; set; }
    }
}
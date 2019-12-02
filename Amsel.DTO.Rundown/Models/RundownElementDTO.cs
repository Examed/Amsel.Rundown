using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownElementDTO
    {
        public Dictionary<string, string> Values { get; set; }
        public ERundownSequence Sequence { get; set; }
        public virtual int Delay { get; set; }
        public virtual string Description { get; set; }
        public virtual string Title { get; set; }
    }
}
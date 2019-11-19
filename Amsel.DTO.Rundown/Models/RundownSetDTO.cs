using System;
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
        public Guid RundownSet { get; set; }
    }


    public class RundownSetDTO
    {
        public virtual string Description { get;  set; }
        public List<RundownElementDTO> Elements { get; set; }
        public virtual string Name { get;  set; }
        public virtual float Priority { get;  set; }
    }
}
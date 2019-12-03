using System;
using System.Collections.Generic;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSetDTO
    {
        public virtual Guid Id { get; set; }
        public virtual string Description { get; set; }
        public List<RundownElementDTO> Elements { get; set; }
        public List<RundownWidgetDTO> Widgets { get; set; }
        public virtual string Name { get; set; }
        public virtual float Priority { get; set; }
        public virtual RundownQueueDTO Queue { get; set; }
        public virtual ERundownStatus Status { get; set; }
    }

    public enum ERundownStatus
    {
        NONE,
        QUEUED,
        ACTIVE,
        COMPLETED,
        CANCELED
    }

    public class RundownQueueDTO
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool StopOnNew { get; set; }
    }

    public class RundownWidgetDTO
    {
    }
}
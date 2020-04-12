using Amsel.Models.Rundown.Persistence;
using System;

namespace Amsel.Models.Rundown.Factories
{
    public static class RundownQueueFactory
    {
        public static RundownQueue Alerts => new RundownQueue("Alerts", false, true);

        public static RundownQueue Scene => new RundownQueue("Scene", true, true);
    }
}

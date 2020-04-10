using Amsel.Framework.Utilities.Extensions.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Amsel.Enums.Rundown.Enums
{
    public enum ERundownMode
    {
        [EnumName("Trigger")]
        [Description("Trigger that can start the RundownSet")]
        TRIGGER = 0,

        [EnumName("Load")]
        [Description("Load Resources of the RundownSet")]
        LOAD = 10,

        [EnumName("Show Transition")]
        [Description("Transition to make the RundownSet visible")]
        TRANSITION_SHOW = 25,

        [EnumName("Active")]
        [Description("Activities that should be happen during the RundownSet is visible")]
        ACTIVE = 50,

        [EnumName("Wait")]
        WAIT = 65,

        [EnumName("Hide Transition")]
        [Description("Transition to hide the RundownSet")]
        TRANSITION_HIDE = 75,

        [EnumName("Stop")]
        STOP = 90,

        [EnumName("Cleanup")]
        [Description("Revert actions that should only be active while the RundownSet is active")]
        CLEANUP = 100
    }
}
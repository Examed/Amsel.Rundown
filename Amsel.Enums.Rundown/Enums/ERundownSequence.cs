using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Amsel.Enums.Rundown.Enums
{

    public static class RundownSequenceType
    {
        public static readonly IEnumerable<EType> EnumList = Enum.GetValues(typeof(EType)).OfType<EType>();
  
        public static string GetName(this EType type)
        {
            switch (type)
            {
                case EType.TRIGGER:
                    return "Trigger";
                case EType.STRUCTURE:
                    return "Structure";
                case EType.LOAD:
                    return "Load";
                case EType.TRANSITION_SHOW:
                    return "Show Transition";
                case EType.ACTIVE:
                    return "Active";
                case EType.WAIT:
                    return "Wait";
                case EType.TRANSITION_HIDE:
                    return "Hide Transition";
                case EType.STOP:
                    return "Stop";
                case EType.CLEANUP:
                    return "Cleanup";
                default:
                    return "";
            }
        }
        public static string GetDesription(this EType type)
        {
            switch (type)
            {
                case EType.TRIGGER:
                    return "Trigger that can start the RundownSet";
                case EType.STRUCTURE:
                    return "Structure of the RundownSet";
                case EType.LOAD:
                    return "Load Resources of the RundownSet";
                case EType.TRANSITION_SHOW:
                    return "Transition to make the RundownSet visible";
                case EType.ACTIVE:
                    return "Activities that should be happen during the RundownSet is visible";
                case EType.WAIT:
                    return "";
                case EType.TRANSITION_HIDE:
                    return "Transition to hide the RundownSet";
                case EType.STOP:
                    return "";
                case EType.CLEANUP:
                    return "Revert actions that should only be active while the RundownSet is active";
                default:
                    return "";
            }
        }

        public enum EType
        {
            TRIGGER = 0,
            STRUCTURE = 10,
            LOAD = 15,

            TRANSITION_SHOW = 25,

            ACTIVE = 50,

            WAIT = 65,
            TRANSITION_HIDE = 75,

            STOP = 90,
            CLEANUP = 100
        }
    }

}
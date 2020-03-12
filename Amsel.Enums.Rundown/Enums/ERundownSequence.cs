using System;
using System.Collections.Generic;
using System.Linq;

namespace Amsel.Enums.Rundown.Enums
{
    public static class RundownSequenceType
    {
        public static readonly IEnumerable<EType> EnumList = Enum.GetValues(typeof(EType)).OfType<EType>();

        #region PUBLIC METHODES
        public static string GetDesription(this EType type)
        {
            switch(type)
            {
                case EType.TRIGGER:
                    return "Trigger that can start the RundownSet";
                case EType.LOAD:
                    return "Load Resources of the RundownSet";
                case EType.TRANSITION_SHOW:
                    return "Transition to make the RundownSet visible";
                case EType.ACTIVE:
                    return "Activities that should be happen during the RundownSet is visible";
                case EType.WAIT:
                    return string.Empty;
                case EType.TRANSITION_HIDE:
                    return "Transition to hide the RundownSet";
                case EType.STOP:
                    return string.Empty;
                case EType.CLEANUP:
                    return "Revert actions that should only be active while the RundownSet is active";
                default:
                    return string.Empty;
            }
        }

        public static string GetName(this EType type)
        {
            switch(type)
            {
                case EType.TRIGGER:
                    return "Trigger";
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
                    return string.Empty;
            }
        }
        #endregion

        public enum EType
        {
            TRIGGER = 0,
            LOAD = 10,

            TRANSITION_SHOW = 25,

            ACTIVE = 50,

            WAIT = 65,
            TRANSITION_HIDE = 75,

            STOP = 90,
            CLEANUP = 100
        }
    }
}
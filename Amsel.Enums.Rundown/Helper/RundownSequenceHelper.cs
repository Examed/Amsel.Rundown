using Amsel.Enums.Rundown.Enums;
using System.Threading;

namespace Amsel.Enums.Rundown.Helper
{
    public static class RundownSequenceHelper
    {
        #region PUBLIC METHODES
        public static bool IsAfterTransitionHide(this RundownModeType.EType sequence) => sequence.CompareTo(RundownModeType.EType.TRANSITION_HIDE) >
            0;

        public static bool IsAfterTransitionShow(this RundownModeType.EType sequence) => sequence.CompareTo(RundownModeType.EType.TRANSITION_SHOW) >
            0;

        public static bool IsBeforeTransitionHide(this RundownModeType.EType sequence) => sequence.CompareTo(RundownModeType.EType.TRANSITION_HIDE) <
            0;

        public static bool IsBeforeTransitionShow(this RundownModeType.EType sequence) => sequence.CompareTo(RundownModeType.EType.TRANSITION_SHOW) <
            0;

        public static bool IsBetweenTransitions(this RundownModeType.EType sequence) => sequence.IsAfterTransitionShow() &&
            sequence.IsBeforeTransitionHide();

        public static bool IsModeExecutable(this RundownModeType.EType sequence, CancellationToken cancellationToken, bool rundownSetIsVisible = true)
        {
            if(cancellationToken.IsCancellationRequested && !sequence.IsAfterTransitionHide())
            {
                if(sequence.IsBeforeTransitionShow())
                    return false;

                if(sequence.IsTransitionShow())
                    return false;

                if(sequence.IsBetweenTransitions())
                    return false;

                if(sequence.IsTransitionHide() && !rundownSetIsVisible)
                    return false;
            }
            return true;
        }

        public static bool IsTransitionHide(this RundownModeType.EType sequence) => sequence ==
            RundownModeType.EType.TRANSITION_HIDE;

        public static bool IsTransitionShow(this RundownModeType.EType sequence) => sequence ==
            RundownModeType.EType.TRANSITION_SHOW;
        #endregion
    }
}
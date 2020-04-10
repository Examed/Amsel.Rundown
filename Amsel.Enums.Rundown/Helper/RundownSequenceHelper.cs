using Amsel.Enums.Rundown.Enums;
using System.Threading;

namespace Amsel.Enums.Rundown.Helper
{
    public static class RundownSequenceHelper
    {
        #region PUBLIC METHODES
        public static bool IsAfterTransitionHide(this ERundownMode sequence) => sequence.CompareTo(ERundownMode.TRANSITION_HIDE) >
            0;

        public static bool IsAfterTransitionShow(this ERundownMode sequence) => sequence.CompareTo(ERundownMode.TRANSITION_SHOW) >
            0;

        public static bool IsBeforeTransitionHide(this ERundownMode sequence) => sequence.CompareTo(ERundownMode.TRANSITION_HIDE) <
            0;

        public static bool IsBeforeTransitionShow(this ERundownMode sequence) => sequence.CompareTo(ERundownMode.TRANSITION_SHOW) <
            0;

        public static bool IsBetweenTransitions(this ERundownMode sequence) => sequence.IsAfterTransitionShow() &&
            sequence.IsBeforeTransitionHide();

        public static bool IsModeExecutable(this ERundownMode sequence, CancellationToken cancellationToken, bool rundownSetIsVisible = true)
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

        public static bool IsTransitionHide(this ERundownMode sequence) => sequence ==
            ERundownMode.TRANSITION_HIDE;

        public static bool IsTransitionShow(this ERundownMode sequence) => sequence ==
            ERundownMode.TRANSITION_SHOW;
        #endregion
    }
}
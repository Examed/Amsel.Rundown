using Amsel.Enums.Rundown.Enums;
using System.Threading;

namespace Amsel.Enums.Rundown.Helper
{
    public static class RundownSequenceHelper
    {
        public static bool DoNotPlaySequence(this RundownSequenceType.EType sequence, CancellationToken cancellationToken, bool rundownSetIsVisible = true)
        {
            if (cancellationToken.IsCancellationRequested && !sequence.IsAfterTransitionOut())
            {

                if (sequence.IsBeforeTransitionIn())
                    return true;

                if (sequence.IsTransitionIn())
                    return true;

                if (sequence.IsBetweenTransitions())
                    return false;

                if (sequence.IsTransitionOut() && !rundownSetIsVisible)
                    return true;

                if (sequence.CompareTo(RundownSequenceType.EType.WAIT) == 0)
                    return true;
            }

            return false;
        }



        public static bool IsAfterTransitionOut(this RundownSequenceType.EType sequence) => sequence.CompareTo(RundownSequenceType.EType.TRANSITION_HIDE) > 0;

        public static bool IsBeforeTransitionIn(this RundownSequenceType.EType sequence) => sequence.CompareTo(RundownSequenceType.EType.TRANSITION_SHOW) < 0;

             public static bool IsBetweenTransitions(this RundownSequenceType.EType sequence) => !sequence.IsBeforeTransitionIn() && !sequence.IsAfterTransitionOut();

        public static bool IsTransitionIn(this RundownSequenceType.EType sequence) => sequence == RundownSequenceType.EType.TRANSITION_SHOW;

        public static bool IsTransitionOut(this RundownSequenceType.EType sequence) => sequence == RundownSequenceType.EType.TRANSITION_HIDE;
    }
}
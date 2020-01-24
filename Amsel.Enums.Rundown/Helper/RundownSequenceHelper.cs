using System.Threading;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.Enums.Rundown.Helper
{
    public static class RundownSequenceHelper
    {
        public static bool DoNotPlaySequence(this ERundownSequenceType sequence, CancellationToken cancellationToken, bool rundownSetIsVisible = true)
        {
            if (cancellationToken.IsCancellationRequested && !sequence.IsAfterTransitionOut())
            {
                if (sequence.IsBeforeTransitionIn())
                    return true;

                if (sequence.IsTransitionIn())
                    return true;

                if (sequence.IsTransitionOut() && !rundownSetIsVisible)
                    return true;

                if (sequence.CompareTo(ERundownSequenceType.WAIT) == 0)
                    return true;
            }

            return false;
        }

        public static bool IsTransitionIn(this ERundownSequenceType sequence)
        {
            return sequence == ERundownSequenceType.TRANSITION_IN;
        }

        public static bool IsTransitionOut(this ERundownSequenceType sequence)
        {
            return sequence == ERundownSequenceType.TRANSITION_OUT;
        }

        public static bool IsAfterTransitionOut(this ERundownSequenceType sequence)
        {
            return sequence.CompareTo(ERundownSequenceType.TRANSITION_OUT) > 0;
        }

        public static bool IsBeforeTransitionIn(this ERundownSequenceType sequence)
        {
            return sequence.CompareTo(ERundownSequenceType.TRANSITION_IN) < 0;
        }



    }
}
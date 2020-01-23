using System.Threading;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.Enums.Rundown.Helper
{
    public static class RundownSequenceHelper
    {
        public static bool DoNotPlaySequence(this ERundownSequence sequence, CancellationToken cancellationToken, bool rundownSetIsVisible = true)
        {
            if (cancellationToken.IsCancellationRequested && !sequence.IsAfterTransitionOut())
            {
                if (sequence.IsBeforeTransitionIn())
                    return true;

                if (sequence.IsTransitionIn())
                    return true;

                if (sequence.IsTransitionOut() && !rundownSetIsVisible)
                    return true;

                if (sequence.CompareTo(ERundownSequence.WAIT) == 0)
                    return true;
            }

            return false;
        }

        public static bool IsTransitionIn(this ERundownSequence sequence)
        {
            return sequence == ERundownSequence.TRANSITION_IN;
        }

        public static bool IsTransitionOut(this ERundownSequence sequence)
        {
            return sequence == ERundownSequence.TRANSITION_OUT;
        }

        public static bool IsAfterTransitionOut(this ERundownSequence sequence)
        {
            return sequence.CompareTo(ERundownSequence.TRANSITION_OUT) > 0;
        }

        public static bool IsBeforeTransitionIn(this ERundownSequence sequence)
        {
            return sequence.CompareTo(ERundownSequence.TRANSITION_IN) < 0;
        }



    }
}
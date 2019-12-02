using System.Threading;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Logging.Attribute;

namespace Amsel.Enums.Rundown.Helper
{
    [NoTrace]
    public static class RundownSequenceHelper
    {
        public static bool DoNotExcecuteSequence(this ERundownSequence sequence, CancellationToken cancellationToken, bool rundownSetIsVisible = true) {
            if (cancellationToken.IsCancellationRequested && !sequence.IsAfterTransitionOut()) {
                if (sequence.IsBeforeTransitionIn())
                    return true;

                if (sequence.IsBetweenTransitions())
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

        public static bool IsAfterTransitionOut(this ERundownSequence sequence) { return sequence.CompareTo(ERundownSequence.TRANSITION_OUT_STOP) > 0; }

        public static bool IsBeforeTransitionIn(this ERundownSequence sequence) { return sequence.CompareTo(ERundownSequence.TRANSITION_IN) < 0; }

        public static bool IsBetweenTransitions(this ERundownSequence sequence) {
            return sequence.CompareTo(ERundownSequence.TRANSITION_IN_STOP) > 0 && sequence.CompareTo(ERundownSequence.TRANSITION_OUT_LOAD) < 0;
        }

        public static bool IsTransitionIn(this ERundownSequence sequence) {
            return sequence.CompareTo(ERundownSequence.TRANSITION_IN_LOAD) >= 0 && sequence.CompareTo(ERundownSequence.TRANSITION_IN_STOP) <= 0;
        }

        public static bool IsTransitionOut(this ERundownSequence sequence) {
            return sequence.CompareTo(ERundownSequence.TRANSITION_OUT_LOAD) >= 0 && sequence.CompareTo(ERundownSequence.TRANSITION_OUT_STOP) <= 0;
        }
    }
}
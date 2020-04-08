namespace Amsel.Resources.Rundown.Controller
{
    public static class RundownSetControllerResources
    {
        public const string CREATE = "create";
        public const string ENQUEUE = "enqueue";
        public const string GET_BY_ID = "get";
        public const string GET_BY_COMPOSITE = "get/composite";
        public const string GET_SEQUENCES = "get/sequences";
    }

    public static class RundownQueueControllerResources
    {
        public const string GET_ALL = "get/all";
        public const string GET_NAMES = "get/names";
        public const string GET_RUNDOWNS = "get/rundowns";
    }

    public static class RundownSequenceControllerResources
    {
    }

    public static class RundownCompositeControllerResources
    {
        public const string GET_ALL = "get/all";
        public const string GET_COMPONENTS = "get/components";
    }
}
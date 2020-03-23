namespace Amsel.Resources.Rundown.Controller
{
    public static class RundownSetControllerResources
    {
        public const string CREATE = "create";
        public const string ENQUEUE = "enqueue";
        public const string GET_BY_ID = "get";
        public const string GET_BY_QUEUE = "get/queue";
    }

    public static class RundownQueueControllerResources
    {
        public const string GET_NAMES = "get/names";
    }

    public static class RundownSequenceControllerResources
    {
        public const string GET_BY_RUNDOWN = "get/rundown";
    }
}
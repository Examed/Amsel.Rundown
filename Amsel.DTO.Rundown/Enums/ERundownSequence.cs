namespace Amsel.DTO.Rundown.Enums
{
    public enum ERundownSequence
    {
        SCRUCTURE = 5,
        POSITIONING = 10,
        LOAD = 15,
        TRANSITION_IN_LOAD = 20,
        TRANSITION_IN = 25,
        TRANSITION_IN_STOP = 30,

        WHILE_Pre = 40,
        WHILE = 50,
        WHILE_Post = 60,

        WAIT = 65,

        TRANSITION_OUT_LOAD = 70,
        TRANSITION_OUT = 75,
        TRANSITION_OUT_STOP = 80,

        STOP = 90,
        CLEANUP = 100
    }
}
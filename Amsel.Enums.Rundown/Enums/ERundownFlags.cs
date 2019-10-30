using System;

namespace Amsel.DTO.Rundown.Enums
{
    [Flags]
    public enum ERundownFlags
    {
        NONE = 0,
        DEFAULT = NONE | NO_CAM | NO_CHROMA | NO_DUO | DYNAMIC_A,

        CAM = 1 << 1,
        NO_CAM = (1 << 2) & ~CAM,

        CHROMA = CAM | (1 << 3),
        NO_CHROMA = (1 << 4) & ~CHROMA,

        DUO = 1 << 5,
        NO_DUO = (1 << 6) & ~DUO,

        DYNAMIC_A = 1 << 7,
        DYNAMIC_B = (1 << 8) & ~DYNAMIC_A
    }
}
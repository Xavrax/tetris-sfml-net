using System;

namespace Tetris.Models.Gameplay.Terminos
{
    [Flags]
    public enum ETerminoShape
    {
        X0Y0 = 0x0001,
        X1Y0 = 0x0002,
        X2Y0 = 0x0004,
        X3Y0 = 0x0008,
        X0Y1 = 0x0010,
        X1Y1 = 0x0020,
        X2Y1 = 0x0040,
        X3Y1 = 0x0080,
        X0Y2 = 0x0100,
        X1Y2 = 0x0200,
        X2Y2 = 0x0400,
        X3Y2 = 0x0800,
        X0Y3 = 0x1000,
        X1Y3 = 0x2000,
        X2Y3 = 0x4000,
        X3Y3 = 0x8000,
    }
}
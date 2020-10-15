using System;
using System.Collections.Generic;
using System.Text;

namespace CareFusion.Mosaic.Devices.Ups
{
    public enum UpsState
    {
        Unknown,
        Connected,
        ConnectionLost,
        PowerFailure,
        PowerBack,
        BattLow,
        UpsFailure
    }
}

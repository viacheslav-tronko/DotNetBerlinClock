using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public interface IClock
    {
        IEnumerable<Lamp> TopBlinkingSecondsRow { get; }

        IEnumerable<Lamp> TopHoursRow { get; }

        IEnumerable<Lamp> BottomHoursRow { get; }

        IEnumerable<Lamp> TopMinutesRow { get; }

        IEnumerable<Lamp> BottomMinutesRow { get; }

        void SetTime(TimeSpan time);
    }
}

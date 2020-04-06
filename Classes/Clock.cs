using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Enums;
using BerlinClock.Extensions;

namespace BerlinClock
{
    public class Clock : IClock
    {
        public IEnumerable<Lamp> TopBlinkingSecondsRow { get; } = new[] { new Lamp(Color.Yellow) };

        public IEnumerable<Lamp> TopHoursRow { get; } = new[]
        {
            new Lamp(Color.Red),
            new Lamp(Color.Red),
            new Lamp(Color.Red),
            new Lamp(Color.Red)
        };

        public IEnumerable<Lamp> BottomHoursRow { get; } = new[]
        {
            new Lamp(Color.Red),
            new Lamp(Color.Red),
            new Lamp(Color.Red),
            new Lamp(Color.Red)
        };

        public IEnumerable<Lamp> TopMinutesRow { get; } = new[]
        {
            new Lamp(Color.Yellow),
            new Lamp(Color.Yellow),
            new Lamp(Color.Red),
            new Lamp(Color.Yellow),
            new Lamp(Color.Yellow),
            new Lamp(Color.Red),
            new Lamp(Color.Yellow),
            new Lamp(Color.Yellow),
            new Lamp(Color.Red),
            new Lamp(Color.Yellow),
            new Lamp(Color.Yellow)
        };

        public IEnumerable<Lamp> BottomMinutesRow { get; } = new[]
        {
            new Lamp(Color.Yellow),
            new Lamp(Color.Yellow),
            new Lamp(Color.Yellow),
            new Lamp(Color.Yellow),
        };

        public void SetTime(TimeSpan time)
        {
            SwitchOffAllLamps();
            SetSeconds(time.Seconds);
            SetHours((int)time.TotalHours);
            SetMinutes(time.Minutes);
        }

        private void SetSeconds(int seconds)
        {
            var isSecondsEven = seconds % 2 == 0;

            if (isSecondsEven)
                SwitchOnLamps(TopBlinkingSecondsRow);
        }

        private void SetHours(int hours)
        {
            var countOfLightsOnTopRow = hours / 5;
            var countOfLightsOnBottomRow = hours % 5;

            SwitchOnLamps(TopHoursRow.Take(countOfLightsOnTopRow));
            SwitchOnLamps(BottomHoursRow.Take(countOfLightsOnBottomRow));
        }

        private void SetMinutes(int minutes)
        {
            var countOfLightsOnTopRow = minutes / 5;
            var countOfLightsOnBottomRow = minutes % 5;

            SwitchOnLamps(TopMinutesRow.Take(countOfLightsOnTopRow));
            SwitchOnLamps(BottomMinutesRow.Take(countOfLightsOnBottomRow));
        }

        private void SwitchOffAllLamps()
        {
            SwitchOffLamps(TopBlinkingSecondsRow);
            SwitchOffLamps(TopHoursRow);
            SwitchOffLamps(BottomHoursRow);
            SwitchOffLamps(TopMinutesRow);
            SwitchOffLamps(BottomMinutesRow);
        }

        private void SwitchOffLamps(IEnumerable<Lamp> lamps) => lamps.ForEach(x => x.SwitchOff());

        private void SwitchOnLamps(IEnumerable<Lamp> lamps) => lamps.ForEach(x => x.SwitchOn());
    }
}

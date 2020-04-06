using System;
using BerlinClock;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private IClock clock;
        private IClockVisualizer clockVisualizer;

        public TimeConverter(IClock clock, IClockVisualizer clockVisualizer)
        { 
            this.clock = clock ?? throw new ArgumentNullException(nameof(clock));
            this.clockVisualizer = clockVisualizer ?? throw new ArgumentNullException(nameof(clockVisualizer));
        }
 
        public string ConvertTime(string aTime)
        {
            var time = ParseTime(aTime);

            clock.SetTime(time);

            return clockVisualizer.Visualize(clock);
        }

        private TimeSpan ParseTime(string aTime)
        {
            if (string.IsNullOrWhiteSpace(aTime))
                throw new ArgumentNullException(nameof(aTime));

            var timeParts = aTime.Split(':');

            var time = new TimeSpan(0, int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));

            return time;
        }
    }
}

using System.Collections.Generic;
using System.Text;
using BerlinClock.Enums;
using BerlinClock.Extensions;

namespace BerlinClock
{
    public class ClockVisualizer : IClockVisualizer
    {
        public string Visualize(IClock clock)
        {
            var builder = new StringBuilder();

            VisualizeRow(clock.TopBlinkingSecondsRow, builder);
            VisualizeRow(clock.TopHoursRow, builder);
            VisualizeRow(clock.BottomHoursRow, builder);
            VisualizeRow(clock.TopMinutesRow, builder);
            VisualizeRow(clock.BottomMinutesRow, builder);

            return builder.ToString().Trim();
        }

        private void VisualizeRow(IEnumerable<Lamp> lampRow, StringBuilder builder)
        {
            lampRow.ForEach(lamp => builder.Append(Convert(lamp)));
            builder.AppendLine();
        }

        private string Convert(Lamp lamp) =>
            lamp.IsOff
                ? "O"
                : lamp.Color == Color.Red
                    ? "R"
                    : "Y";
    }
}

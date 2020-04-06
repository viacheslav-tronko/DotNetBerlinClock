using BerlinClock.Enums;

namespace BerlinClock
{
    public class Lamp
    {
        public Lamp(Color color, LampState initialState = LampState.Off)
        {
            Color = color;
            State = initialState;
        }

        public Color Color { get; }

        public LampState State { get; private set; }

        public bool IsOff => State == LampState.Off;

        internal void SwitchOn() => State = LampState.On;

        internal void SwitchOff() => State = LampState.Off;
    }
}

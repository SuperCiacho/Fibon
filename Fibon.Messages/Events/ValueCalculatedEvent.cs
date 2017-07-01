namespace Fibon.Messages.Events
{
    public class ValueCalculatedEvent : IEvent
    {
        public int Number { get; set; }
        public int Value { get; set; }

        public ValueCalculatedEvent() { }

        public ValueCalculatedEvent(int number, int value)
        {
            this.Number = number;
            this.Value = value;
        }
    }
}
namespace Fibon.Messages.Commands
{
    public class CalculateValueCommand : ICommand
    {
        public int Number { get; set; }

        public CalculateValueCommand()
        {
        }

        public CalculateValueCommand(int number)
        {
            this.Number = number;
        }
    }
}
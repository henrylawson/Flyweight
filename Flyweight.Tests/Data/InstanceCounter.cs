namespace Flyweight.Tests.Data
{
    public class InstanceCounter : IInstanceCounter
    {
        public static int Count { get; private set; }

        public InstanceCounter()
        {
            Count++;
        }

        public static void Reset()
        {
            Count = 0;
        }
    }
}
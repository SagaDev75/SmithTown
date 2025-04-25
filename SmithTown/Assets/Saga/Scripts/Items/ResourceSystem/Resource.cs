namespace Saga.Items.ResourceSystem
{
    public class Resource
    {
        public string Name { get; }
        public int Count { get; private set; }

        public Resource(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public bool CheckCount(int amount)
        {
            return Count >= amount;
        }

        public void Spend(int amount)
        {
            Count -= amount;
            if (Count < 0) Count = 0;
        }

        public void Increase(int amount)
        {
            Count += amount;
        }
    }
}
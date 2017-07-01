using System.Collections.Generic;

namespace Fibon.Api.Repository
{
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<int, int> storage;

        public InMemoryRepository()
        {
            this.storage = new Dictionary<int, int>();
        }

        public void Add(int number, int result)
        {
            this.storage[number] = result;
        }

        public int? Get(int number)
        {
            return this.storage.TryGetValue(number, out int result) ? (int?)result : null;
        }
    }
}
using System;

namespace Domain.Entities
{
    public class Currency
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Currency()
        {
            Id = Guid.NewGuid();
        }
    }
}

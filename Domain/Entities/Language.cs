using System;

namespace Domain.Entities
{
    public class Language
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Language()
        {
            Id = Guid.NewGuid();
        }
    }
}
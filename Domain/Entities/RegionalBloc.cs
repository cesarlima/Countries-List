using System;

namespace Domain.Entities
{
    public class RegionalBloc
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public RegionalBloc()
        {
            Id = Guid.NewGuid();
        }
    }
}
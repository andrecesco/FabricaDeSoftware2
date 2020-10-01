using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaDeSoftware.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id = {Id}]";
        }
    }
}

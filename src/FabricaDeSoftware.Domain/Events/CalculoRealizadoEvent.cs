using FabricaDeSoftware.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaDeSoftware.Domain.Events
{
    public class CalculoRealizadoEvent : DomainEvent
    {
        public Calculo Calculo { get; private set; }

        public CalculoRealizadoEvent(Guid aggregateId, Calculo calculo) : base(aggregateId)
        {
            Calculo = calculo;
        }
    }
}

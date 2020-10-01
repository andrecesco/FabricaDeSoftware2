using FabricaDeSoftware.Core.DomainObjects;
using System;

namespace FabricaDeSoftware.Core.Data
{
    public interface IRepository<T> where T : IAggregateRoot
    {

    }
}

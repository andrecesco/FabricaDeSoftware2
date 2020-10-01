using Bogus;
using FabricaDeSoftware.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FabricaDeSoftware.UnitTest
{
    [CollectionDefinition(nameof(CalculoCollection))]
    public class CalculoCollection : ICollectionFixture<CalculoTestFixture>{ }

    public class CalculoTestFixture : IDisposable
    {
        public Calculo GerarNovoCalculo()
        {
            return new Faker<Calculo>("pt_BR")
                .CustomInstantiator(a => new Calculo(Guid.NewGuid(), Guid.NewGuid(), a.Random.Decimal()));
        }

        public void Dispose()
        {

        }
    }
}

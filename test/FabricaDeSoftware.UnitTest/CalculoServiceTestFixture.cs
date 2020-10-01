using Bogus;
using FabricaDeSoftware.Domain;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FabricaDeSoftware.UnitTest
{
    [CollectionDefinition(nameof(CalculoServiceCollection))]
    public class CalculoServiceCollection : ICollectionFixture<CalculoServiceTestFixture> { }

    public class CalculoServiceTestFixture : IDisposable
    {
        public AutoMocker Mocker;

        public Calculo GerarNovoCalculo()
        {
            return new Faker<Calculo>("pt_BR")
                .CustomInstantiator(a => new Calculo(Guid.NewGuid(), Guid.NewGuid(), a.Random.Decimal()));
        }

        public FilaCalculo GerarNovoFilaCalculo()
        {
            return new Faker<FilaCalculo>("pt_BR")
                .CustomInstantiator(_ => new FilaCalculo(Guid.NewGuid(), Guid.NewGuid(), 10, 10, 5, "1,2", 2));
        }

        public CalculoService ObterCalculoService()
        {
            Mocker = new AutoMocker();
            return Mocker.CreateInstance<CalculoService>();
        }

        public void Dispose()
        {

        }
    }
}

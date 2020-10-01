using FabricaDeSoftware.Core.DomainObjects;
using FabricaDeSoftware.Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FabricaDeSoftware.UnitTest
{
    [Collection(nameof(CalculoCollection))]
    public class CalculoTest
    {
        private readonly CalculoTestFixture _calculoTestFixture;

        public CalculoTest(CalculoTestFixture calculoTestFixture)
        {
            _calculoTestFixture = calculoTestFixture;
        }

        [Fact]
        public void Calculo_Validar_Devem_Retornar_Exceptions()
        {
            // Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Calculo(Guid.Empty, Guid.NewGuid(), 100)
            );

            Assert.Equal("O Id da configuração não pode ser vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Calculo(Guid.NewGuid(), Guid.Empty, 100)
            );

            Assert.Equal("O Id do usuario não pode ser vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Calculo(Guid.NewGuid(), Guid.NewGuid(), 0)
            );

            Assert.Equal("A distância da reta não pode ser menor ou igual a zero", ex.Message);
        }

        [Fact]
        public void Calculo_Atualiza_A_Quantidade_De_Pilares()
        {
            //Arrange
            var calculo = _calculoTestFixture.GerarNovoCalculo();

            //Act
            calculo.AtualizarQuantidadeDePilares(5);

            //Assert
            calculo.QuantidadeDePilares.Should().Be(5);
        }

        [Fact]
        public void Calculo_Nao_Atualiza_A_Quantidade_De_Pilares()
        {
            //Arrange
            var calculo = _calculoTestFixture.GerarNovoCalculo();

            //Act & Assert
            var ex = Assert.Throws<DomainException>(() => calculo.AtualizarQuantidadeDePilares(-1));
            Assert.Equal("A quantidade de pilares não pode ser menor do que zero", ex.Message);
        }

        [Fact]
        public void Calculo_Atualiza_A_Distancia_Entre_Vaos()
        {
            //Arrange
            var calculo = _calculoTestFixture.GerarNovoCalculo();

            //Act
            calculo.AtualizarDistanciaDosVaos(5);

            //Assert
            calculo.DistanciaEntreVaos.Should().Be(5);
        }

        [Fact]
        public void Calculo_Nao_Atualiza_A_Distancia_Entre_Vaos()
        {
            //Arrange
            var calculo = _calculoTestFixture.GerarNovoCalculo();

            //Act & Assert
            var ex = Assert.Throws<DomainException>(() => calculo.AtualizarDistanciaDosVaos(0));
            Assert.Equal("A distância entre vãos não pode ser menor ou igual a zero", ex.Message);
        }

        [Fact]
        public void Calculo_Atualiza_Pilares_Com_Base_Reforcada()
        {
            //Arrange
            var calculo = _calculoTestFixture.GerarNovoCalculo();

            //Act
            calculo.AtualizarPilaresComBaseReforcada(new List<int>() { 1 });

            //Assert
            Assert.Equal(1, calculo.QuantidadeDePilaresReforcados);
            Assert.Contains("1", calculo.PilaresComBaseReforcada);
        }

        [Fact]
        public void Calculo_Nao_Atualiza_Pilares_Com_Base_Reforcada()
        {
            //Arrange
            var calculo = _calculoTestFixture.GerarNovoCalculo();

            //Act & Assert
            var ex = Assert.Throws<DomainException>(() => calculo.AtualizarPilaresComBaseReforcada(null));
            Assert.Equal("A lista de pilares com base reforçada não pode ser nula", ex.Message);
        }
    }
}

using FabricaDeSoftware.Core.Bus;
using FabricaDeSoftware.Core.DomainObjects;
using FabricaDeSoftware.Core.Messages;
using FabricaDeSoftware.Domain;
using FluentAssertions;
using MediatR;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace FabricaDeSoftware.UnitTest
{
    [Collection(nameof(CalculoServiceCollection))]
    public class CalculoServiceTest
    {
        private readonly CalculoServiceTestFixture _calculoServiceTestFixture;

        public CalculoServiceTest(CalculoServiceTestFixture calculoServiceTestFixture)
        {
            _calculoServiceTestFixture = calculoServiceTestFixture;
        }

        [Fact]
        public async Task Deve_Realizar_Calculo_Com_Sucesso()
        {
            //Arrange
            var calculo = _calculoServiceTestFixture.GerarNovoCalculo();
            var calculoService = _calculoServiceTestFixture.ObterCalculoService();

            //Act
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Setup(a => a.ObterConfiguracao(calculo.IdConfiguracao))
                .ReturnsAsync(new Configuracao(Guid.NewGuid(), 10, 10));
            await calculoService.RealizarCalculo(calculo);

            //
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Verify(a => a.ObterConfiguracao(calculo.IdConfiguracao), Times.Once);
            _calculoServiceTestFixture.Mocker.GetMock<IMediatrHandler>().Verify(a => a.PublicarEvento(It.IsAny<Event>()), Times.Once);
        }

        [Fact]
        public async Task Deve_Realizar_Calculo_Com_Erro_Na_Configuracao()
        {
            //Arrange
            var calculo = _calculoServiceTestFixture.GerarNovoCalculo();
            var calculoService = _calculoServiceTestFixture.ObterCalculoService();

            //Act
            var ex = await Assert.ThrowsAsync<DomainException>(() => calculoService.RealizarCalculo(calculo));

            //Assert
            ex.Message.Should().Be("Não existe nenhuma configuração cadastrada.");
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Verify(a => a.ObterConfiguracao(calculo.IdConfiguracao), Times.Once);
            _calculoServiceTestFixture.Mocker.GetMock<IMediatrHandler>().Verify(a => a.PublicarEvento(It.IsAny<Event>()), Times.Never);
        }

        [Fact]
        public async Task Processa_Ao_Menos_Um_Item_Da_Fila()
        {
            //Arrange
            var filaCalculo = _calculoServiceTestFixture.GerarNovoFilaCalculo();
            var calculoService = _calculoServiceTestFixture.ObterCalculoService();
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Setup(a => a.ObterFilaCalculos())
                .ReturnsAsync(new List<FilaCalculo>() { filaCalculo });
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Setup(a => a.SalvarCalculo(filaCalculo)).ReturnsAsync(true);
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Setup(a => a.RemoverFilaCalculo(filaCalculo.Id)).ReturnsAsync(true);

            //Act
            await calculoService.ProcessarFila();

            //Assert
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Verify(a => a.ObterFilaCalculos(), Times.Once);
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Verify(a => a.SalvarCalculo(filaCalculo), Times.Once);
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Verify(a => a.RemoverFilaCalculo(filaCalculo.Id), Times.Once);
        }

        [Fact]
        public async Task Processa_Nenhum_Item_Da_Fila_Vazia()
        {
            //Arrange
            var filaCalculo = _calculoServiceTestFixture.GerarNovoFilaCalculo();
            var calculoService = _calculoServiceTestFixture.ObterCalculoService();
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Setup(a => a.ObterFilaCalculos())
                .ReturnsAsync(new List<FilaCalculo>());

            //Act
            await calculoService.ProcessarFila();

            //Assert
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Verify(a => a.ObterFilaCalculos(), Times.Once);
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Verify(a => a.SalvarCalculo(filaCalculo), Times.Never);
            _calculoServiceTestFixture.Mocker.GetMock<ICalculoDAO>().Verify(a => a.RemoverFilaCalculo(filaCalculo.Id), Times.Never);
        }
    }
}

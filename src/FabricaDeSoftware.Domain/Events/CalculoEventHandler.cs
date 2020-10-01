using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FabricaDeSoftware.Domain.Events
{
    public class CalculoEventHandler : INotificationHandler<CalculoRealizadoEvent>
    {
        private readonly ICalculoDAO _calculoDAO;

        public CalculoEventHandler(ICalculoDAO calculoDAO)
        {
            _calculoDAO = calculoDAO;
        }

        public async Task Handle(CalculoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            var filaCalculo = new FilaCalculo(notification.Calculo.IdConfiguracao, notification.Calculo.IdUsuario, notification.Calculo.DistanciaDaReta, notification.Calculo.QuantidadeDePilares, notification.Calculo.QuantidadeDePilaresReforcados, notification.Calculo.PilaresComBaseReforcada, notification.Calculo.DistanciaEntreVaos);

            await _calculoDAO.SalvarFilaCalculo(filaCalculo);
        }
    }
}

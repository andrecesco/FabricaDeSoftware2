using FabricaDeSoftware.Core.Bus;
using FabricaDeSoftware.Core.DomainObjects;
using FabricaDeSoftware.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabricaDeSoftware.Domain
{
    public class CalculoService : ICalculoService
    {
        private readonly ICalculoDAO _calculoDAO;
        private readonly IMediatrHandler _mediatrHandler;

        public CalculoService(ICalculoDAO calculoDAO, IMediatrHandler mediatrHandler)
        {
            _calculoDAO = calculoDAO;
            _mediatrHandler = mediatrHandler;
        }

        public async Task RealizarCalculo(Calculo calculo)
        {
            var configuracao = await _calculoDAO.ObterConfiguracao(calculo.IdConfiguracao).ConfigureAwait(false);

            Validacoes.ValidarSeNulo(configuracao, "Não existe nenhuma configuração cadastrada.");

            calculo.AtualizarQuantidadeDePilares(CalcularQuantidadeDePilares(calculo, configuracao));

            calculo.AtualizarDistanciaDosVaos(CalcularDistanciaDosVaos(calculo));

            calculo.AtualizarPilaresComBaseReforcada(CalcularBaseReforcada(calculo, configuracao));

            await _mediatrHandler.PublicarEvento(new CalculoRealizadoEvent(calculo.Id, calculo));
        }

        public async Task ProcessarFila()
        {
            foreach (var item in await _calculoDAO.ObterFilaCalculos().ConfigureAwait(false))
            {
                if(await _calculoDAO.SalvarCalculo(item))
                {
                    await _calculoDAO.RemoverFilaCalculo(item.Id);
                }
            }
        }

        private List<int> CalcularBaseReforcada(Calculo calculo, Configuracao configuracao)
        {
            var listaPilaresComBaseReforcada = new List<int>();

            var j = 0;
            for (int i = 1; i <= calculo.QuantidadeDePilares; i++)
            {
                j++;
                if (i == 1)
                {
                    listaPilaresComBaseReforcada.Add(i);
                    continue;
                }

                if ((j * configuracao.DistanciaMaximaEntrePilares) > configuracao.DistanciaMaximaDaReta)
                {
                    listaPilaresComBaseReforcada.Add(i);
                    j = 1;
                }

                if (i == calculo.QuantidadeDePilares)
                {
                    listaPilaresComBaseReforcada.Add(i);
                }
            }

            return listaPilaresComBaseReforcada;
        }

        private decimal CalcularDistanciaDosVaos(Calculo calculo)
        {
            var pilaresAdicionais = calculo.QuantidadeDePilares - 1;
            if (pilaresAdicionais == 0)
            {
                return calculo.DistanciaDaReta;
            }

            return calculo.DistanciaDaReta / pilaresAdicionais;
        }

        private int CalcularQuantidadeDePilares(Calculo calculo, Configuracao configuracao)
        {
            return (int)Math.Round(calculo.DistanciaDaReta / configuracao.DistanciaMaximaEntrePilares) + 1;
        }
    }
}

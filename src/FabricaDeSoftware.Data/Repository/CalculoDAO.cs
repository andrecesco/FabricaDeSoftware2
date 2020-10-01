using Dapper;
using FabricaDeSoftware.Core.Data;
using FabricaDeSoftware.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaDeSoftware.Data.Repository
{
    public class CalculoDAO : ICalculoDAO
    {
        private readonly IConfiguration _configuration;

        public CalculoDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Calculo>> ObterCalculos()
        {
            using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await conn.QueryAsync<Calculo>("SELECT Id, IdConfiguracao, IdUsuario, DistanciaDaReta, QuantidadeDePilares, QuantidadeDePilaresReforcados, PilaresComBaseReforcada, DistanciaEntreVaos, DataCadastro, DataDelecao FROM Calculo WHERE DataDelecao IS NULL ORDER BY DataCadastro DESC").ConfigureAwait(false);
        }

        public async Task<IEnumerable<FilaCalculo>> ObterFilaCalculos()
        {
            using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await conn.QueryAsync<FilaCalculo>("SELECT Id, IdConfiguracao, IdUsuario, DistanciaDaReta, QuantidadeDePilares, QuantidadeDePilaresReforcados, PilaresComBaseReforcada, DistanciaEntreVaos, DataCadastro FROM FilaCalculo ORDER BY DataCadastro ASC").ConfigureAwait(false);
        }

        public async Task<bool> SalvarCalculo(FilaCalculo calculo)
        {
            using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await conn.ExecuteAsync("INSERT INTO Calculo (Id, IdConfiguracao, IdUsuario, DistanciaDaReta, QuantidadeDePilares, QuantidadeDePilaresReforcados, PilaresComBaseReforcada, DistanciaEntreVaos, DataCadastro, DataDelecao) VALUES (@Id, @IdConfiguracao, @IdUsuario, @DistanciaDaReta, @QuantidadeDePilares, @QuantidadeDePilaresReforcados, @PilaresComBaseReforcada, @DistanciaEntreVaos, @DataCadastro, NULL)", new { calculo.Id, calculo.IdConfiguracao, calculo.IdUsuario, calculo.DistanciaDaReta, calculo.QuantidadeDePilares, calculo.QuantidadeDePilaresReforcados, calculo.PilaresComBaseReforcada, calculo.DistanciaEntreVaos, calculo.DataCadastro }) >= 1;
        }

        public async Task<bool> SalvarFilaCalculo(FilaCalculo filaCalculo)
        {
            using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await conn.ExecuteAsync("INSERT INTO FilaCalculo (Id, IdConfiguracao, IdUsuario, DistanciaDaReta, QuantidadeDePilares, QuantidadeDePilaresReforcados, PilaresComBaseReforcada, DistanciaEntreVaos, DataCadastro) VALUES (@Id, @IdConfiguracao, @IdUsuario, @DistanciaDaReta, @QuantidadeDePilares, @QuantidadeDePilaresReforcados, @PilaresComBaseReforcada, @DistanciaEntreVaos, @DataCadastro)", new { filaCalculo.Id, filaCalculo.IdConfiguracao, filaCalculo.IdUsuario, filaCalculo.DistanciaDaReta, filaCalculo.QuantidadeDePilares, filaCalculo.QuantidadeDePilaresReforcados, filaCalculo.PilaresComBaseReforcada, filaCalculo.DistanciaEntreVaos, filaCalculo.DataCadastro }) >= 1;
        }

        public async Task<bool> RemoverFilaCalculo(Guid id)
        {
            using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await conn.ExecuteAsync("DELETE FROM FilaCalculo WHERE Id = @Id", new { Id = id }) >= 1;
        }

        public async Task<Configuracao> ObterConfiguracao(Guid idConfiguracao)
        {
            using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await conn.QueryFirstAsync<Configuracao>("SELECT * FROM Configuracao WHERE ID = @Id", new { Id = idConfiguracao }).ConfigureAwait(false);
        }
    }
}

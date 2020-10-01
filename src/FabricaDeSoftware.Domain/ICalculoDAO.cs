using FabricaDeSoftware.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabricaDeSoftware.Domain
{
    public interface ICalculoDAO : IRepository<Calculo>
    {
        public Task<IEnumerable<Calculo>> ObterCalculos();

        public Task<IEnumerable<FilaCalculo>> ObterFilaCalculos();

        public Task<bool> SalvarCalculo(FilaCalculo calculo);

        public Task<bool> SalvarFilaCalculo(FilaCalculo calculo);

        public Task<bool> RemoverFilaCalculo(Guid id);

        public Task<Configuracao> ObterConfiguracao(Guid idConfiguracao);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabricaDeSoftware.Domain
{
    public interface ICalculoService
    {
        Task RealizarCalculo(Calculo calculo);

        Task ProcessarFila();

    }
}

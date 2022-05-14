using GCB.Dominio.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GCB.Testes.ObjetosValor
{
    public class RealTestes
    {
        [Fact]
        public void Ao_passar_um_valor_deve_ser_criar_o_valor_em_real()
        {
            var real = new Real(10);

            Assert.True(real.Valid);
        }
    }
}

using GCB.Dominio.Entidades;
using GCB.Dominio.Enums;
using GCB.Dominio.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GCB.Testes.Entidades
{
    public class ReferenciaTestes
    {
        [Fact]
        public void Nao_pode_criar_uma_referencia_com_o_mes_vazio()
        {
            Mes? mes = null;
            var referencia = new Referencia(mes.GetValueOrDefault());

            Assert.True(referencia.Invalid);
        }

        [Fact]
        public void Ao_criar_uma_referencia_deve_apontar_para_o_ano_atual()
        {
            var referencia = new Referencia(Mes.Janeiro);

            Assert.True(referencia.Valid);
            Assert.Equal(DateTime.Now.Year, referencia.Ano);
        }
    }
}

namespace GCB.QG
{
        public class Deposito
        {
            public string ExtratoId { get; set; }
            public string Descricao { get; set; }
            public decimal Valor { get; set; }

            public Deposito(string id, string descricao, decimal valor)
            {
                ExtratoId = id;
                Descricao = descricao;
                Valor = valor;
            }
        }
   
}

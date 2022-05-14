namespace GCB.QG
{
        public class Retirada
        {
            public string ExtratoId { get; set; }
            public string Descricao { get; set; }
            public decimal Valor { get; set; }

            public Retirada(string id, string descricao, decimal valor)
            {
                ExtratoId = id;
                Descricao = descricao;
                Valor = valor;
            }
        }
    
}

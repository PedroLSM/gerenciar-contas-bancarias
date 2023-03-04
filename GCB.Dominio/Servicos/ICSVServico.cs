using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace GCB.Dominio.Servicos
{
    public interface ICSVServico
    {
        public IList<T> LerCSV<T>(Stream file);
        public IList<T> LerCSV<T>(IFormFile file);
    }
}

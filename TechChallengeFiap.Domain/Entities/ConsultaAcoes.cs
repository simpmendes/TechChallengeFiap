using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFiap.Domain.Entities
{
    public class ConsultaAcoes
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public DateTime DataConsulta { get; set; }
    }
}

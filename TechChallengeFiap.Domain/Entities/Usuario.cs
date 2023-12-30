using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Domain.Enums;

namespace TechChallengeFiap.Domain.Entities
{
    public class Usuario: Entity
    {
        public string? Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public TipoPermissao Permissao { get; set; }
        public ICollection<ConsultaAcoes> ConsultaAcoes { get; set; }
    }
}

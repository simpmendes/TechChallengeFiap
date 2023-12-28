using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces;
using TechChallengeFiap.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFiap.Infra.Data
{
    public class RepositoryBase: IRepositoryBase
    {
        private readonly ConsultaAcoesDBContext _context;
        public RepositoryBase(ConsultaAcoesDBContext context)
        {
            _context = context;
        }
       
    }
}

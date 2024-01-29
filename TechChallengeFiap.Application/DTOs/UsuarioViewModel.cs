using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Enums;

namespace TechChallengeFiap.Application.DTOs
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
                
        }
        public UsuarioViewModel(int id, string nome, string nomeUsuario,TipoPermissao permissao)
        {
            Nome = nome;
            NomeUsuario = nomeUsuario;
            Permissao = permissao;
            Id = id;
            
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string NomeUsuario { get; set; }
        public TipoPermissao Permissao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedido
{
    public class UsuarioLogado
    {
        private static UsuarioLogado _instancia;

        // Propriedades do usuário
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }

        // Construtor privado para evitar instâncias externas
        private UsuarioLogado() { }

        // Método para obter a instância única
        public static UsuarioLogado Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new UsuarioLogado();
                return _instancia;
            }
        }

        // Método para definir os dados do usuário
        public void DefinirUsuario(int id, string nome, string login)
        {
            Id = id;
            Nome = nome;
            Login = login;
        }

        // Método para limpar o usuário ao fazer logout
        public void Logout()
        {
            _instancia = null;
        }
    }

}

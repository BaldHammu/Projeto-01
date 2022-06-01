using MimicAPI.Helpers;
using MimicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimicAPI.Repositories.Contracts
{
    public class Retorno
    {
        public List<Palavra> PalavraLista { get; set; }
        public Paginator Paginator { get; set; }
        public Retorno(List<Palavra> _palavra, Paginator _paginator)
        {
            PalavraLista = _palavra;
            Paginator = _paginator;
        }
    }
    public interface IPalavraRepository
    {
        Retorno ObterPalavras(UrlQuery query);
        Palavra Obter(int id);
        void Cadastrar(Palavra palavra);
        void Atualizar(Palavra palavra);
        void Deletar(int id);

    }
}

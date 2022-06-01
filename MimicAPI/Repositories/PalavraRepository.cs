using MimicAPI.Database;
using MimicAPI.Helpers;
using MimicAPI.Models;
using MimicAPI.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimicAPI.Repositories
{
    public class PalavraRepository : IPalavraRepository
    {
        private readonly MimicContext _banco;
        public PalavraRepository(MimicContext banco)
        {
            _banco = banco;
        }
        public Palavra Obter(int id)
        {
            return _banco.Palavras.Find(id);
        }



        public Retorno ObterPalavras(UrlQuery urlQuery)
        {
            var bdItem = _banco.Palavras.Where(x => x.Criado > urlQuery.Data || x.Atualizado > urlQuery.Data);
            Paginator paginator = new Paginator(urlQuery.PageNumber.Value + 1, urlQuery.PageSize.Value, bdItem.Count(), (int)Math.Ceiling(((double)bdItem.Count() / urlQuery.PageSize.Value)));
            if (urlQuery.PageSize.HasValue)
            {
                bdItem = bdItem.Skip(urlQuery.PageNumber.Value * urlQuery.PageSize.Value).Take(urlQuery.PageSize.Value);
            }
            if (urlQuery.PageNumber >= paginator.PagesTotal)
            {
                return null;
            }
            Retorno retorno = new Retorno(bdItem.ToList(),paginator);
            return retorno;

        }
        public void Atualizar(Palavra palavra)
        {
            _banco.Palavras.Update(palavra);
            _banco.SaveChangesAsync();
        }

        public void Cadastrar(Palavra palavra)
        {
            _banco.Palavras.Add(palavra);
            _banco.SaveChangesAsync();
        }

        public void Deletar(int id)
        {
            var palavra = _banco.Palavras.Find(id);
            palavra.Ativo = false;
            _banco.Palavras.Update(palavra);
            _banco.SaveChangesAsync();
        }


    }
}

using desafio_itau.Domain._Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
namespace desafio_itau.Aplicacao.Servicos.Transacoes;

    public class TransacaoService : ITransacaoService
    {
        private List<Transacao> transacoes = new List<Transacao>();
        
    public bool Transferir(Transacao transacao)
    {
        try
        {
            
            Validator.ValidateObject(transacao, new ValidationContext(transacao), validateAllProperties: true);
            
            if (transacao.DataHora > DateTime.Now)
            {
                return false; 
            }

            transacoes.Add(transacao);
            return true; 
        }
        catch (ValidationException)
        {
            return false;
        }
    }

        public void DeletarTransacao(Transacao transacao)
        {
            if (!transacoes.Contains(transacao))
            {
                throw new ArgumentException("A transação não existe na lista.");
            }
            transacoes.Remove(transacao);
        }
    }

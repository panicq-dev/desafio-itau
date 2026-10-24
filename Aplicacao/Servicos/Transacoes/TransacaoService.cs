using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using DesafioItau.Domain.Models;

namespace DesafioItau.Aplicacao.Servicos.Transacoes;

    public class TransacaoService : ITransacaoService
    {
        public static List<Transacao> TransacoesRegistradas = new List<Transacao>();
        
    public bool Transferir(Transacao transacao)
    {
        try
        {
            
            Validator.ValidateObject(transacao, new ValidationContext(transacao), validateAllProperties: true);
            
            if (transacao.DataHora > DateTime.Now)
            {
                return false; 
            }

            TransacoesRegistradas.Add(transacao);
            return true; 
        }
        catch (ValidationException)
        {
            return false;
        }
    }

        public void DeletarTransacao(Transacao transacao)
        {
            if (!TransacoesRegistradas.Contains(transacao))
            {
                throw new ArgumentException("A transação não existe na lista.");
            }
            TransacoesRegistradas.Remove(transacao);
        }

        public List<Transacao> ObterTransacoesNaUltimaHora()
        {
            var transacoesDaUltimaHora = TransacoesRegistradas
                .FindAll(transacao => (DateTime.Now - transacao.DataHora).TotalMinutes <= 60 && (DateTime.Now - transacao.DataHora).TotalMinutes >= 0);
            return transacoesDaUltimaHora;
        }
    }

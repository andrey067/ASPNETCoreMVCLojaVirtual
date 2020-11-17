using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Validacao
{
    public class EmailUnicoColaboradorAtribute : ValidationAttribute
    {


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //Pegar valor do campo Email
            string Email = (value as string).Trim();

            //Obtero repository do Colaborador
            IColaboradorRepository _colaboradorRepository = (IColaboradorRepository)validationContext.GetService(typeof(IColaboradorRepository));

            //Fazer a verificacao
            List<Colaborador> colaboradoresEmail = _colaboradorRepository.ObterColaboradorPorEmail(Email);

            Colaborador objColaborador = (Colaborador)validationContext.ObjectInstance;

            // - Cadastrado mais de 1 colaborador com mesmo email == ERRO
            if (colaboradoresEmail.Count > 1)
            {
                return new ValidationResult("Email ja existente!");

            }
            // - Colaborador == 1  && colaborador.Id || do registra que esta no banco - no caso troca de email no mesmo ID
            if (colaboradoresEmail.Count == 1 && objColaborador.Id != colaboradoresEmail[0].Id)
            {

                return new ValidationResult("Email já existente");
            }
            return ValidationResult.Success;
        }




    }
}

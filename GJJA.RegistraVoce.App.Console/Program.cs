using UI = System.Console;
using System;
using GJJA.RegistraVoce.DataAccess.DAOs;
using GJJA.RegistraVoce.Domain;
using System.Collections.Generic;
using GJJA.RegistraVoce.Domain.Enums;

namespace GJJA.RegistraVoce.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.WriteLine($"*** Bem Vindo *** {Environment.NewLine}");
            UI.WriteLine($"O que você deseja fazer? {Environment.NewLine}");
            UI.WriteLine("1. Listar pessoas");
            UI.WriteLine("2. Inserir pessoa");
            UI.WriteLine("0. Sair");
            int opcao = Convert.ToInt32(UI.ReadLine());
            switch(opcao)
            {
                case 0:
                    UI.WriteLine(" Tchau! ;)");
                    break;
                case 1:
                    ShowPeople();
                    break;
                case 2:
                    InsertPerson();
                    break;
                default:
                    UI.WriteLine("Opção Inválida!");   
                    break; 
            }
        }

        private static void InsertPerson()
        {
            try
            {
                UI.WriteLine("*** Inserção de pessoa ***");
                Person person =  new Person();
                UI.Write(" - Nome: ");
                person.Name = UI.ReadLine();
                UI.Write(" - Gênero (0 = M, 1 = F, 2 = Indefinido): ");
                person.Gender = (Gender)Convert.ToInt32(UI.ReadLine());
                UI.Write(" - CPF: ");
                person.DocumentNumber = UI.ReadLine();
                UI.Write(" - RG: ");
                person.Identification = UI.ReadLine();
                UI.Write(" - Data de Nascimento: ");
                person.BirthDate = Convert.ToDateTime(UI.ReadLine());
                UI.Write(" - Estado civil (0 = Solt., 1 = Cas., 2 = Divorc., 3 = Viuv.)");
                person.MaritalStatus = (MaritalStatus)Convert.ToInt32(UI.ReadLine());
                UI.Write(" - Endereço: ");
                person.Address = UI.ReadLine();
                UI.Write(" - Telefone");
                person.Phone = UI.ReadLine();
                PersonDAO personDAO = new PersonDAO();
                personDAO.Insert(person);
                UI.WriteLine(" ** Pessoa cadastrado com sucesso! ** ");
            }
            catch(Exception ex)
            {
                UI.WriteLine($"Houve um erro ao salvar a pessoa: {ex.Message}");
            }            
        }

        private static void ShowPeople()
        {
            PersonDAO personDAO = new PersonDAO();
            List<Person> people = personDAO.Select();
            if(people.Count == 0)
            {
                UI.WriteLine("Não existem pessoas cadastradas");
            }

            people.ForEach (person =>
            {
                UI.WriteLine($"[{person.Id}] {person.Name}");
            });
        }
    }
}

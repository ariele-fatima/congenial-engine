using UI = System.Console;
using System;
using GJJA.RegistraVoce.DataAccess.DAOs;
using GJJA.RegistraVoce.Domain;
using System.Collections.Generic;

namespace GJJA.RegistraVoce.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.WriteLine($"*** Bem Vindo *** {Environment.NewLine}");
            UI.WriteLine($"O que você deseja fazer? {Environment.NewLine}");
            UI.WriteLine("1. Listar Pessoas");
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
                default:
                    UI.WriteLine("Opção Inválida!");   
                    break; 
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

using UI = System.Console;
using System;
using GJJA.RegistraVoce.Domain;
using System.Collections.Generic;
using GJJA.RegistraVoce.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GJJA.RegistraVoce.DataAccess.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GJJA.RegistraVoce.App.Console.Factories;
using GJJA.Repository.Common.Interfaces;
using GJJA.RegistraVoce.Repository.Entity;

namespace GJJA.RegistraVoce.App.Console
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            SetUp();
            int opcao = -1;
            UI.WriteLine($"*** Bem Vindo *** {Environment.NewLine}");
            while(opcao != 0)
            {
                UI.WriteLine($"O que você deseja fazer? {Environment.NewLine}");
                UI.WriteLine("1. Listar pessoas");
                UI.WriteLine("2. Inserir pessoa");
                UI.WriteLine("3. Atualizar pessoa");
                UI.WriteLine("4. Deletar pessoa");
                UI.WriteLine("5. Contar pessoas");
                UI.WriteLine("0. Sair");
                opcao = Convert.ToInt32(UI.ReadLine());

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
                    case 3:
                        UpdatePerson();
                        break; 
                    case 4:
                        DeletePerson();
                        break; 
                    case 5:
                        CountPeople();
                        break;         
                    default:
                        UI.WriteLine("Opção Inválida!");   
                        break; 
                }
            }
        }

        private static void CountPeople()
        {
            try
            {
                
                ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();                
                UI.WriteLine($"Existe(m) {personRepository.Select().Count()} pessoa(s) cadastrada(s).");
            }
            catch(Exception ex)
            {
                UI.WriteLine($"Houve um erro ao contar a pessoa: {ex.Message}");
            }
        }


        private static void DeletePerson()
        {
            try
            {
                ShowPeople();
                UI.Write("Id da pessoa a ser deletada: ");
                int personId = Convert.ToInt32(UI.ReadLine());
                ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();
                personRepository.DeletetById(personId);
            }
            catch(Exception ex)
            {
                UI.WriteLine($"Houve um erro ao deletar a pessoa: {ex.Message}");
            }

        }

        private static void UpdatePerson()
        {            
            try
            {
                ShowPeople();
                UI.Write("Id da pessoa a ser atualizada: ");
                int personId = Convert.ToInt32(UI.ReadLine());
                ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();
                Person p = personRepository.SelectById(personId);
                if( p == null)
                {
                    throw new ArgumentException("ID de pessoa inexistente.");
                }
                GetPersonFromUI(p);
                personRepository.Update(p);
                

            }
            catch(Exception ex)
            {
                UI.WriteLine($"Houve um erro ao atualizar a pessoa: {ex.Message}");
            }
        }

        private static void InsertPerson()
        {
            try
            {
                UI.WriteLine("*** Inserção de pessoa ***");
                Person person = new Person();
                GetPersonFromUI(person);
                // PersonDAO personDAO = new PersonDAO(_connectionString);
                // personDAO.Insert(person);
                // RegistraVoceDbContext context = _serviceProvider.GetService<RegistraVoceDbContext>();
                // context.Set<Person>().Add(person);
                // context.SaveChanges();
                ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();
                personRepository.Insert(person);
                UI.WriteLine(" *** Pessoa cadastrado com sucesso! ** ");
            }
            catch (Exception ex)
            {
                UI.WriteLine($"Houve um erro ao salvar a pessoa: {ex.Message}");
            }            
        }

        private static void ShowPeople()
        {
            //PersonDAO personDAO = new PersonDAO(_connectionString);
            //List<Person> people = personDAO.Select();
            //RegistraVoceDbContext context = _serviceProvider.GetService<RegistraVoceDbContext>();
            //List<Person> people = context.Set<Person>().ToList();
            ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();
            List<Person> people = personRepository.Select();
            if(people.Count == 0)
            {
                UI.WriteLine("Não existem pessoas cadastradas");
            }

            people.ForEach (person =>
            {
                UI.WriteLine($"[{person.Id}] {person.Name}");
            });
        }
        private static void GetPersonFromUI(Person person)
        {
            if(string.IsNullOrEmpty(person.Name))
            {
                UI.Write(" - Nome: ");
                person.Name = UI.ReadLine();
                UI.Write(" - Gênero - 0 = M, 1 = F, 2 = Indefinido: ");
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
                UI.Write(" - Telefone: ");
                person.Phone = UI.ReadLine();
            }
            else
            {
                UI.Write($" - Nome: ({person.Name}): ");
                person.Name = UI.ReadLine();
                UI.Write($" - Gênero - 0 = M, 1 = F, 2 = Indefinido ({person.Gender}): ");
                person.Gender = (Gender)Convert.ToInt32(UI.ReadLine());
                UI.Write($" - CPF ({person.DocumentNumber}): ");
                person.DocumentNumber = UI.ReadLine();
                UI.Write($" - RG ({person.Identification}): ");
                person.Identification = UI.ReadLine();
                UI.Write($" - Data de Nascimento ({person.BirthDate}): ");
                person.BirthDate = Convert.ToDateTime(UI.ReadLine());
                UI.Write($" - Estado civil - 0 = Solt., 1 = Cas., 2 = Divorc., 3 = Viuv. ({person.MaritalStatus}): ");
                person.MaritalStatus = (MaritalStatus)Convert.ToInt32(UI.ReadLine());
                UI.Write($" - Endereço ({person.Address}): ");
                person.Address = UI.ReadLine();
                UI.Write($" - Telefone ({person.Phone}): ");
                person.Phone = UI.ReadLine();
            }            
                        
        }

        private static void SetUp()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<RegistraVoceDbContext>((provider) => 
            {
                return new RegistraVoceDbContextFactory().CreateDbContext(new string[]{});
            }); 
            services.AddScoped<ICrudRepository<Person, int>, PersonRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }

    }
}

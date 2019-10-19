using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using WebMVC.Models;
using GJJA.RegistraVoce.Domain.Enums;
using System;
using GJJA.RegistraVoce.DataAccess.Entity.Context;
using GJJA.Repository.Common.Interfaces;
using GJJA.RegistraVoce.Repository.Entity;
using Microsoft.Extensions.DependencyInjection;
using GJJA.RegistraVoce.Domain;
using System.Collections.Generic;
using WebMVC.Factories;

namespace WebMVC.Controllers
{
    public class PersonController :  Controller
    {
        private static ServiceProvider _serviceProvider;
        public ListPersonModel model;
        public PersonController()
        {
            model = new ListPersonModel();
            SetUp();
        }

        public IActionResult Index()
        {
            LoadPeople();
            return View(model);
        }

        private void LoadPeople()
        {
            ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();            
            List<Person> people = personRepository.Select();
            model= new ListPersonModel(people);

        }
        public IActionResult DeletePerson(Int32 personId)
        {
            ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();
            personRepository.DeletetById(personId);
            LoadPeople();
            return View("Index", model);
        }

        public IActionResult InsertPerson(Person person)
        {
            ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();
            personRepository.Insert(person);
            LoadPeople();
            return View("Index", model);
        }

        public IActionResult EditPerson(Int32 personId)
        {      
            ICrudRepository<Person, int> personRepository = _serviceProvider.GetService<ICrudRepository<Person, int>>();
            Person p = personRepository.SelectById(personId);
            LoadPeople();
            model.EditPerson = p;
            return View("Index", model);
        }

        public IActionResult Welcome()
        {            
            var model = new PersonModel();
            model.Id = 2;
            model.Name = "Carla";
            model.Gender = Gender.Female;
            model.DocumentNumber = "0987665";
            model.Identification = "556644777";
            model.BirthDate = new DateTime(1990, 10, 10);
            model.MaritalStatus = MaritalStatus.Single;
            model.Address = "Rua da minha casa";
            model.Phone = "24253647";
            model.Bla = "Oi pessoinha";
            return View(model);
        }

        private static void SetUp()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<RegistraVoceDbContext>((provider) => 
            {
                return new WebMVCDbContextFactory().CreateDbContext(new string[]{});
            }); 
            services.AddScoped<ICrudRepository<Person, int>, PersonRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
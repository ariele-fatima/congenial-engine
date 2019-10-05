using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using WebMVC.Models;
using GJJA.RegistraVoce.Domain.Enums;
using System;

namespace WebMVC.Controllers
{
    public class PersonController :  Controller
    {
        public IActionResult Index()
        {
            return View();
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

    }
}
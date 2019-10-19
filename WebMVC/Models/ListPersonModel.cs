using System;
using System.ComponentModel.DataAnnotations;
using GJJA.RegistraVoce.Domain.Enums;
using GJJA.RegistraVoce.Domain;
using System.Collections.Generic;

namespace WebMVC.Models
{
    public class ListPersonModel
    {
        public List<Person> ListPerson { get; set; }

        public Person EditPerson { get; set; }
        public ListPersonModel()
        {
            EditPerson = new Person();
            ListPerson = new List<Person>();
        }

        public ListPersonModel(List<Person> listPerson)
        {
            EditPerson = new Person();
            ListPerson = new List<Person>();            
            foreach(Person person in listPerson)
            {
                ListPerson.Add(person);
            }
        }

    }
}
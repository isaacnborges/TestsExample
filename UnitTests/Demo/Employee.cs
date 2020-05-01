using System;
using System.Collections.Generic;

namespace Demo
{
    public class Person
    {
        public string Name { get; protected set; }
        public string Nickname { get; set; }
    }

    public class Employee : Person
    {
        public double Salary { get; private set; }
        public ProfessionalLevel ProfessionalLevel { get; private set; }
        public IList<string> Skills { get; private set; }

        public Employee(string name, double salary)
        {
            Name = string.IsNullOrEmpty(name) ? "Fulano" : name;
            DefineSalary(salary);
            DefineSkills();
        }

        public void DefineSalary(double salary)
        {
            if (salary < 500) 
                throw new Exception("Salary less than allowed");

            Salary = salary;
            if (salary < 2000) 
                ProfessionalLevel = ProfessionalLevel.Junior;
            else if (salary >= 2000 && salary < 8000) 
                ProfessionalLevel = ProfessionalLevel.Pleno;
            else if (salary >= 8000) ProfessionalLevel = ProfessionalLevel.Senior;
        }

        private void DefineSkills()
        {
            var habilidadesBasicas = new List<string>()
            {
                "Logic",
                "OOP"
            };

            Skills = habilidadesBasicas;

            switch (ProfessionalLevel)
            {
                case ProfessionalLevel.Pleno:
                    Skills.Add("Tests");
                    break;
                case ProfessionalLevel.Senior:
                    Skills.Add("Tests");
                    Skills.Add("Microservices");
                    break;
            }
        }
    }

    public enum ProfessionalLevel
    {
        Junior,
        Pleno,
        Senior
    }

    public class EmployeeFactory
    {
        protected EmployeeFactory() { }

        public static Employee Create(string name, double salary) => new Employee(name, salary);
    }
}
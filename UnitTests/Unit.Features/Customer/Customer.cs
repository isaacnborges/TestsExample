using System;
using Features.Core;
using FluentValidation;

namespace Features.Clientes
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }

        protected Customer()
        {
        }

        public Customer(Guid id, string name, string lastName, DateTime birthDate, string email, bool active, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Lastname = lastName;
            BirthDate = birthDate;
            Email = email;
            Active = active;
            CreatedDate = createdDate;
        }

        public string FullName()
        {
            return $"{Name} {Lastname}";
        }

        public bool IsSpecial()
        {
            return CreatedDate < DateTime.Now.AddYears(-3) && Active;
        }

        public void Inactivate()
        {
            Active = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new ClientValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ClientValidator : AbstractValidator<Customer>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please make sure you have entered the name")
                .Length(2, 150).WithMessage("The name must be between 2 and 150 characters");

            RuleFor(c => c.Lastname)
                .NotEmpty().WithMessage("Please make sure you have entered the last name")
                .Length(2, 150).WithMessage("The last name must be between 2 and 150 characters");

            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("Customer must be 18 years or older");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
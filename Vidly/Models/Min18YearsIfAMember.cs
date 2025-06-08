using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //This ValidationContext.ObjectInstance will give us access to the containing class. In this case Customer
            //Since this is an object we need to cast it to Customer.
            var customer = (Customer)validationContext.ObjectInstance;
            //Here we have magic nukmbers which is not a good practice.
            //To remove the magic numbers we have to explicitly define the MembershipTypes in the domain
            //Here the MembershipType is of reference data.
            //if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            //    return ValidationResult.Success;

            //We will replace the magic strings with the static fields we have created
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;


            if (customer.BirthDate == null)
                return new ValidationResult(ErrorMessage = "Birthdate is required");


            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;



            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage = " Customer should be atleast 18 years old to go on a membership");

        }
    }
}
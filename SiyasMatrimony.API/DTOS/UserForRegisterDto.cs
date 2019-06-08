using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOS
{
    public class UserForRegisterDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileCreatedFor { get; set; }
        public string Gender { get; set; }
        public string MotherTongue { get; set; }
        public string Religion { get; set; }
        public string Cast { get; set; }
        public string SubCast { get; set; }
        public string MaritalStatus { get; set; }
        public string PinCode { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string CallingCode { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        //Physical
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BodyType { get; set; }
        public string Complexion { get; set; }
        public string PhysicalStatus { get; set; }

        //Qualification & Occupation
        public string  HighestQualification { get; set; }
        public string  EmploymentType{ get; set; }
        public string  Occupation{ get; set; }
        public string  Currency { get; set; }
        public string  MonthlyIncome{ get; set; }

        //Astrological
        public string Star { get; set; }
        public string Raasi { get; set; }
        public string ChovvaDosam { get; set; }
        public string timeOfBirth {get; set;}

        //Habits
        /// <summary>
        /// Vegetarian,NonVegetarian,Eggetarian
        /// </summary>
        public string FoodHabits { get; set; }
        public string Smoking { get; set; }
        public string Drinking { get; set; }

        //Family Profile
        /// <summary>
        /// Upper,Middle,Rich,Affluent
        /// </summary>
        public string FamilyStatus { get; set; }
        /// <summary>
        /// Joint Family,Nuclear Family,Others
        /// </summary>
        public string FamilyType { get; set; }

        /// <summary>
        /// Orthodox,Traditional,Moderate,Liberal
        /// </summary>
        public string FamilyValues { get; set; }

        public string ParentsMobileNumber { get; set; }
        public string ParentsMonthlyIncome { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}
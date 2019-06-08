using System;

namespace SiyasMatrimony.API.Helper
{
    public static class Extensions
    {
        public static int CalculateAge(this DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;

            if (dateOfBirth.AddYears(age) > DateTime.Now)
            {
                age--;
            }

            return age;
        }
    }
}

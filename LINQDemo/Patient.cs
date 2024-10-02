using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    internal class Patient
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public int YearOfBirth { get; set; }
        public double HeightInCm { get; set;}
        public double WeightInKg { get; set;}


        public int BMI  //ToDo simplify this properthy.
        {
            get { return (int)(WeightInKg / ((HeightInCm / 100) * (HeightInCm / 100))); }
        }

        public override string ToString()
        {
            
            //return $"{base.ToString()},{FirstName},{LastName},{YearOfBirth}";
            return $"{FirstName},{LastName},{YearOfBirth}";
        }

    }
}

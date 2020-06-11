using System;

namespace ComplexNumber
{
    struct ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public double Modulus { get; set; }
        public double Argument { get; set; }
        public string Value
        {
            get
            {
                if (Imaginary == 0)
                    return Real.ToString();

                string sign = Math.Sign(Imaginary) == -1 ? "-" : "+";
                return Real.ToString() + " " + sign + " " + Math.Abs(Imaginary).ToString() + 'i';
            }
        }
        public static ComplexNumber FromPolarCoordinates(double modulus, double argument)
        {
            return new ComplexNumber(Math.Cos(argument) * modulus, Math.Sin(argument) * modulus);
        }
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;

            Imaginary = imaginary;
            Modulus = Math.Sqrt(Real * Real + Imaginary * Imaginary);
            Argument = Math.Atan(Imaginary / Real);
        }

        public static ComplexNumber operator +(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first.Real + second.Real, first.Imaginary + second.Imaginary);
        }
     

        public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first.Real - second.Real, first.Imaginary - second.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first.Real * second.Real - first.Imaginary * second.Imaginary, first.Imaginary * second.Real + first.Real * second.Imaginary);
        }
   
        public static ComplexNumber operator /(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber((first.Real * second.Real + first.Imaginary * second.Imaginary) / (second.Real * second.Real + second.Imaginary * second.Imaginary), (first.Imaginary * second.Real - first.Real * second.Imaginary) / (second.Real * second.Real + second.Imaginary * second.Imaginary));
        }
      
        public static ComplexNumber operator ~(ComplexNumber first)
        {
            return new ComplexNumber(first.Real, first.Imaginary * -1);
        }
        public void Pow(int n)
        {
            this = FromPolarCoordinates(Math.Pow(Modulus, n), Argument * n);
        }
        public override string ToString() => Value;
    }
}

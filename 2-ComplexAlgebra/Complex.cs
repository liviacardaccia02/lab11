using System;
namespace ComplexAlgebra

{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public Complex(double real, double immaginary) 
        {
            Real = real;
            Imm = immaginary;
        }

        public double Real { get; }

        public double Imm { get; }

        public double Modulus => Math.Sqrt(Real * Real + Imm * Imm);

        public double Phase => Math.Atan2(Imm, Real);

        public Complex Complement()
        {
            return new Complex(Real, -Imm);
        }

        public Complex Sum(Complex complex)
        {
            return new Complex(Real + complex.Real, Imm + complex.Imm);
        }

        public Complex Sub(Complex complex)
        {
            return new Complex(Real - complex.Real, Imm - complex.Imm);
        }

        public override string ToString()
        {
            if (Real == 0) 
            {
                return Imm == 0 ? "0" : $"{Imm}i";
            }

            return Imm >= 0 ? $"{ Real } + { Imm }i" : $"{ Real } { Imm }i";
        }

        public override bool Equals(object obj) 
        {
            Complex complex = obj as Complex;

            if (complex == null) 
            {
                return false;
            }

            if (Real == complex.Real && Imm == complex.Imm) 
            {
                return true;
            }

            return false;
        }

    }
}
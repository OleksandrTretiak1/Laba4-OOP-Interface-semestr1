using System.Numerics;

namespace InterfaceTask
{
    // Реалізація для комплексних чисел
    class MyComplex : IMyNumber<MyComplex>
    {
        private double re; // дійсна частина
        private double im; // уявна частина

        // Конструктор
        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        // Додавання комплексних чисел
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(this.re + that.re, this.im + that.im);
        }

        // Віднімання комплексних чисел
        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.re - that.re, this.im - that.im);
        }

        // Множення комплексних чисел
        public MyComplex Multiply(MyComplex that)
        {
            double realPart = this.re * that.re - this.im * that.im;
            double imagPart = this.re * that.im + this.im * that.re;
            return new MyComplex(realPart, imagPart);
        }

        // Ділення комплексних чисел
        public MyComplex Divide(MyComplex that)
        {
            double divisor = that.re * that.re + that.im * that.im;
            if (divisor == 0) throw new DivideByZeroException("Cannot divide by zero.");
            double realPart = (this.re * that.re + this.im * that.im) / divisor;
            double imagPart = (this.im * that.re - this.re * that.im) / divisor;
            return new MyComplex(realPart, imagPart);
        }

        // Перевизначення ToString для зручного виводу комплексного числа
        public override string ToString()
        {
            return $"{re}{(im >= 0 ? "+" : "")}{im}i";
        }
    }

}
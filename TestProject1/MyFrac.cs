using System.Numerics;

namespace InterfaceTask
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger nom; // чисельник
        private BigInteger denom; // знаменник

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");
            this.nom = nom;
            this.denom = denom;
            Normalize();
        }

        public MyFrac(int nom, int denom) : this(new BigInteger(nom), new BigInteger(denom)) { }

        private void Normalize()
        {
            if (denom < 0)
            {
                nom = -nom;
                denom *= -1;
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(nom, denom);
            if (gcd > 1)
            {
                nom /= gcd;
                denom /= gcd;
            }
        }

        // Реалізація методів інтерфейсу
        public MyFrac Add(MyFrac b)
        {
            BigInteger commonDenom = denom * b.denom;
            BigInteger newNom = nom * b.denom + b.nom * denom;
            return new MyFrac(newNom, commonDenom);
        }

        public MyFrac Subtract(MyFrac b)
        {
            BigInteger commonDenom = denom * b.denom;
            BigInteger newNom = nom * b.denom - b.nom * denom;
            return new MyFrac(newNom, commonDenom);
        }

        public MyFrac Multiply(MyFrac b)
        {
            BigInteger newNom = nom * b.nom;
            BigInteger newDenom = denom * b.denom;
            return new MyFrac(newNom, newDenom);
        }

        public MyFrac Divide(MyFrac b)
        {
            if (b.nom == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            BigInteger newNom = nom * b.denom;
            BigInteger newDenom = denom * b.nom;
            return new MyFrac(newNom, newDenom);
        }

        public int CompareTo(MyFrac? b)
        {
            if (b is null)
                return 1; // Поточний об'єкт більший за null.

            BigInteger left = this.nom * b.denom;
            BigInteger right = this.denom * b.nom;

            return left.CompareTo(right);
        }

        public override string ToString()
        {
            return $"{nom}/{denom}";
        }
    }
}

using NUnit.Framework;
using System;

namespace InterfaceTask.Tests
{
    [TestFixture]
    public class MyFracTests
    {
        [Test]
        public void Add_TwoFractions_ReturnsCorrectResult()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(1, 3);

            var result = f1.Add(f2);

            Assert.That(result.ToString(), Is.EqualTo("5/6"));
        }

        [Test]
        public void Subtract_TwoFractions_ReturnsCorrectResult()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(1, 3);

            var result = f1.Subtract(f2);

            Assert.That(result.ToString(), Is.EqualTo("1/6"));
        }

        [Test]
        public void Multiply_TwoFractions_ReturnsCorrectResult()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(2, 3);

            var result = f1.Multiply(f2);

            Assert.That(result.ToString(), Is.EqualTo("1/3")); // Скорочена форма
        }


        [Test]
        public void Divide_TwoFractions_ReturnsCorrectResult()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(2, 3);

            var result = f1.Divide(f2);

            Assert.That(result.ToString(), Is.EqualTo("3/4"));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(0, 1);

            Assert.Throws<DivideByZeroException>(() => f1.Divide(f2));
        }

        [Test]
        public void CompareTo_FractionsComparison_ReturnsCorrectResult()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(2, 4);
            var f3 = new MyFrac(3, 4);

            Assert.That(f1.CompareTo(f2), Is.EqualTo(0)); // 1/2 == 2/4
            Assert.That(f1.CompareTo(f3), Is.LessThan(0)); // 1/2 < 3/4
            Assert.That(f3.CompareTo(f1), Is.GreaterThan(0)); // 3/4 > 1/2
        }

        [Test]
        public void CompareTo_NullFraction_ReturnsPositive()
        {
            var f = new MyFrac(1, 2);

            MyFrac? nullFraction = null; // Nullable тип
            Assert.That(f.CompareTo(nullFraction), Is.EqualTo(1));
        }


        [Test]
        public void Constructor_NormalizesFraction()
        {
            var f = new MyFrac(-1, -2);

            Assert.That(f.ToString(), Is.EqualTo("1/2"));
        }

        [Test]
        public void Constructor_ThrowsExceptionOnZeroDenominator()
        {
            Assert.Throws<DivideByZeroException>(() => new MyFrac(1, 0));
        }
    }
}

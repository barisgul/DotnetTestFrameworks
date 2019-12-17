using DotNetTestFrameworks;
using FluentAssertions;
using NUnit.Framework;

namespace NunitExamples
{
    [TestFixture]
    public class MathsTests
    {
        private Maths maths;

        [SetUp]
        public void Setup()
        {
            maths = new Maths();
        }

        /// <summary>
        /// 3a pattern kullanımında statik variable ile test case oluşturma
        /// </summary>
        [Test,Order(1)]
        public void Add_SumTwoNumbers_ShouldReturnValidNumber()
        {
            //Arrange
            int value1 = 3;
            int value2 = 5;

            //Act
            var result = maths.Add(value1, value2);

            //Assert
            Assert.AreEqual(8, result, "Hata!");
        }
        /// <summary>
        /// TestCase attribute ile kullanım
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        [TestCase(3,5,8),Order(2)]
        [TestCase(3, 4, 7)]
        public void Add_SumTwoNumbers_ShouldReturnValidNumberWithTestCaseAttribute(params int[] testData)
        {
            //Arrange
            decimal value1 = testData[0];
            decimal value2 = testData[1];

            //Act
            var result = maths.Add(value1, value2);

            //Assert
            Assert.AreEqual(testData[2], result, "Hata alındı!");
        }

        /// <summary>
        /// Values attribute ile kullanım
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        [Test]
        public void Add_SumTwoNumbers_ShouldReturnValidNumberWithVAluesAttribute([Values(2,5)] int val1,
        [Values(2,6)] int val2)
        {
            //Arrange
            decimal value1 =val1;
            decimal value2 = val2;

            //Act
            var result = maths.Add(value1, value2);

            //Assert
            Assert.GreaterOrEqual(result, 6, "Hata alındı!");
        }

        /// <summary>
        /// Range attribute kullanımı   
        /// </summary>
        [Test]
        public void RangeAttributeMethod( [Values(1,2,3)] int value,
                                          [Range(0.2,0.8,0.2)] double d)
        {
            //Act
            var sum = value + d;

            //Assert
            Assert.GreaterOrEqual(sum, 2);
        }

        /// <summary>
        /// Random attribute kullanımı   
        /// </summary>
        [Test]
                                          //Arrange
        public void RandomAttributeMethod([Values(1, 2, 3)] int value,
                                          [Random(-5,5,5)] double d)
        {
            //Act
            var multiply = value * d;

            //Assert
            Assert.Positive(multiply, "Result is negative!");
        }

        //Arrange
        [TestCase(3, 5, 8), Order(3)]
        [TestCase(3, 4, 7)]
        public void FluentAssertionMethod(params int[] testData)
        {
            //Act
            var sum = testData[0] + testData[1];

            //Assert
            sum.Should().Equals(testData[2]);
            sum.Should().NotBe(null);
            sum.Should().BePositive();
            sum.Should().NotBe(0);
        }

        /// <summary>
        /// TearDown
        /// </summary>
        public void TearDown()
        {
            //end of class under test
        }
    }
}

using DotNetTestFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XunitExamples
{
    public class MathsTests :  IDisposable
    {
        Maths maths;

        //setup yerine constructor
        public MathsTests()
        {
            maths = new Maths();
            Console.WriteLine("Test Started!");
        }

        /// <summary>
        /// 3a pattern kullanımında statik variable ile test case oluşturma
        /// </summary>
        [Fact]
        public void Add_SumTwoNumbers_ShouldReturnValidNumber()
        {
            //Arrange
            int value1 = 3;
            int value2 = 5;

            //Act
            var result = maths.Add(value1, value2);

            //Assert
            Assert.Equal(8, result);
        }

        /// <summary>
        /// Theory attribute ile kullanım
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(3, 4, 7)]
        public void Add_SumTwoNumbers_ShouldReturnValidNumberWithTheoryAttribute(params int[] testData)
        {
            //Arrange
            decimal value1 = testData[0];
            decimal value2 = testData[1];

            //Act
            var result = maths.Add(value1, value2);

            //Assert
            Assert.Equal(testData[2], result);
        }


        //teardown yerine dispose
        public void Dispose()
        {
            //end of class under test
            Console.WriteLine("Test finished!");
        }
    }
}

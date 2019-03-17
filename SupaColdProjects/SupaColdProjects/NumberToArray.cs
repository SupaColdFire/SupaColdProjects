using System;
using NUnit.Framework;

namespace SupaColdProjects
{
    [TestFixture]
    public class NumberToArray
    {
        [Test]
        public void NumberToArrayTest()
        {
            Assert.AreEqual(new int[]{1,2,5},IntToArray(125));
            Assert.AreEqual(new int[]{3,4,1,9},IntToArray(3419));
            Assert.AreNotEqual(new int[]{1,2,5},IntToArray(12515));
            
        }
        
        [Test]
        public void ArrayLengthTest()
        {
            Assert.AreEqual(3 ,GetArrayLength(125));
            Assert.AreEqual(1 ,GetArrayLength(5));
            Assert.AreEqual(2 ,GetArrayLength(25));
            Assert.AreEqual(10 ,GetArrayLength(1111111115));
        }

        private int GetArrayLength(int number)
        {
            //10^2 == 100;
            return (int) Math.Log10(number)+1;
        }
        
        
        private int[] IntToArray(int number)
        {
            var arrayLength = GetArrayLength(number);
            var result = new int[arrayLength];
            for (var i = 0; i < arrayLength; i++)
            {
                var a = Math.Pow(10, arrayLength - i - 1);
                var left = number / a;
                result[i] = (int) left;
                number -= (int) a * result[i];
            }
            return result;
        }
    }
}
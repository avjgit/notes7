using Xunit;

namespace howtouse
{
    public class MyTests
    {
        [Fact]
        public void MyTest()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact(Skip="Example of wrong test. Use one with expected excetion.")]
        public void Badmethod()
        {
            double result = DivideNumbers(5, 0);
            Assert.Equal(double.PositiveInfinity, result);
        }
        public void DivideByZeroThrowsException()
        {
            Assert.Throws<System.DivideByZeroException>(
                delegate
                {
                    DivideNumbers(5, 0);
                });
        }

        public int DivideNumbers(int top, int bottom)
        {
            return top / bottom;
        }
    }
}

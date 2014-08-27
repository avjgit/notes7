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

        [Fact]
        public void DivideByZeroThrowsException()
        {
            Assert.Throws<System.DivideByZeroException>(
                delegate
                {
                    DivideNumbers(5, 0);
                });
        }

        [Fact(Timeout=40)]
        public void LongRunningTest()
        {
            System.Threading.Thread.Sleep(50);
        }

        public int DivideNumbers(int top, int bottom)
        {
            return top / bottom;
        }
    }
}

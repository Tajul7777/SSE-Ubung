using Xunit;
using Moq;
using System.IO;

namespace Task3
{
    public class Tests
    {
        private IResultWriter _resultWriter;

        public Tests()
        {
            var mock = new Mock<IResultWriter>();
            mock.Setup(o => o.WriteResult(It.IsAny<double>()));
            _resultWriter = mock.Object;
        }

        [Fact]
        public void TestMultiply()
        {
            var c = new Calculator(_resultWriter);
            var result = c.Multiply(3, 2);
            Assert.Equal(result, 6);
        }

        [Fact]
        public void TestDivide()
        {
            var c = new Calculator(_resultWriter);
            var result = c.Divide(6, 3);
            Assert.Equal(result, 2);
        }

        [Fact]
        public void TestDivideByZero()
        {
            var c = new Calculator(_resultWriter);
            var result = c.Divide(6, 0);
            Assert.Equal(result, double.NaN);
        }

        [Fact]
        public void TestException()
        {
            var mock = new Mock<IResultWriter>();
            mock.Setup(o => o.WriteResult(It.IsAny<double>())).Throws(new IOException("Disk is full"));

            var c = new Calculator(mock.Object);
            Assert.Throws<IOException>(() => c.Multiply(3, 2));
        }
    }
}
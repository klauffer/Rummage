using Xunit;

namespace Search.Tests
{
    public sealed class IndexItemShould
    {
        [Fact]
        public void NotEquate()
        {
            var indexItem1 = new IndexItem("1", "Mr.Burnes");
            var indexItem2 = new IndexItem("2", "Mr.Burnes");

            Assert.False(indexItem1.Equals(indexItem2));
        }

        [Fact]
        public void Equate()
        {
            var indexItem1 = new IndexItem("1", "Mr.Burnes");
            var indexItem2 = new IndexItem("1", "Mr.Burnes");

            Assert.True(indexItem1.Equals(indexItem2));
        }

        [Fact]
        public void EquateWithOperand()
        {
            var indexItem1 = new IndexItem("1", "Mr.Burnes");
            var indexItem2 = new IndexItem("1", "Mr.Burnes");

            Assert.True(indexItem1 == indexItem2);
        }

        [Fact]
        public void NotEquateWithOperand()
        {
            var indexItem1 = new IndexItem("1", "Mr.Burnes");
            var indexItem2 = new IndexItem("2", "Mr.Burnes");

            Assert.True(indexItem1 != indexItem2);
        }
    }
}

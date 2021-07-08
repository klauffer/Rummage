using Xunit;

namespace Rummage.Tests
{
    public sealed class IndexItemShould
    {
        [Fact]
        public void NotEquate()
        {
            var indexItem1 = IndexItem<int>.From(PhraseId<int>.From(1), "Mr.Burnes");
            var indexItem2 = IndexItem<int>.From(PhraseId<int>.From(2), "Mr.Burnes");

            Assert.False(indexItem1.Equals(indexItem2));
        }

        [Fact]
        public void Equate()
        {
            var indexItem1 = IndexItem<int>.From(PhraseId<int>.From(1), "Mr.Burnes");
            var indexItem2 = IndexItem<int>.From(PhraseId<int>.From(1), "Mr.Burnes");

            Assert.True(indexItem1.Equals(indexItem2));
        }

        [Fact]
        public void EquateWithOperand()
        {
            var indexItem1 = IndexItem<int>.From(PhraseId<int>.From(1), "Mr.Burnes");
            var indexItem2 = IndexItem<int>.From(PhraseId<int>.From(1), "Mr.Burnes");

            Assert.True(indexItem1 == indexItem2);
        }


        [Fact]
        public void NotEquateWithOperand()
        {
            var indexItem1 = IndexItem<int>.From(PhraseId<int>.From(1), "Mr.Burnes");
            var indexItem2 = IndexItem<int>.From(PhraseId<int>.From(2), "Mr.Burnes");

            Assert.True(indexItem1 != indexItem2);
        }
    }
}

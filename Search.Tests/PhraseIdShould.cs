using Xunit;

namespace Rummage.Tests
{
    public sealed class PhraseIdShould
    {
        [Fact]
        public void BeEquatable()
        {
            var phraseId1 = PhraseId<int>.From(1);
            var phraseId2 = PhraseId<int>.From(1);
            Assert.Equal(phraseId1, phraseId2);
        }

        [Fact]
        public void BeInequatable()
        {
            var phraseId1 = PhraseId<int>.From(1);
            var phraseId2 = PhraseId<int>.From(2);
            Assert.NotEqual(phraseId1, phraseId2);
        }
    }
}

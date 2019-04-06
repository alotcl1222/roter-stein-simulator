using FsCheck;
using FsCheck.Xunit;
using RoterStein.Domain;
using RoterStein.Domain.Classes;
using Xunit;
using static LanguageExt.Prelude;

namespace TestProject1
{
    public class UnitTest1
    {
        [Property(Arbitrary = new[] {typeof(Arbitrary)})]
        public Property 適正範囲内の数値でLevelが作成できること(int level)
        {
            return Level.Create(level).IsRight.ToProperty();
        }

        [Fact]
        public void 引数がNullだったらぬるぽ()
        {
            Assert.True(Player.Create(null, null).IsLeft);
        }

        [Fact]
        public void 引数が適切ならPlayerを作成できる()
        {
            Level.Create(42)
                .Match(
                    r => Assert.True(Player.Create(new Squire(), Optional(r)).IsRight),
                    l => Assert.True(false));
        }
    }
}
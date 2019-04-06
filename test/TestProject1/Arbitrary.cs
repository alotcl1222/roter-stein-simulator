using FsCheck;
using JetBrains.Annotations;
using RoterStein.Domain;

namespace TestProject1
{
    [UsedImplicitly]
    public static class Arbitrary
    {
        [UsedImplicitly]
        public static Arbitrary<int> ValidLevelGenerator()
        {
            return Gen
                .Choose(Level.LowerBound, Level.UpperBound)
                .ToArbitrary();
        }
    }
}
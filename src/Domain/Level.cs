using System.Diagnostics.CodeAnalysis;
using LanguageExt;
using RoterStein.Domain.Errors;
using static LanguageExt.Prelude;

namespace RoterStein.Domain
{
    public class Level : ILevel
    {
        private Level(int value)
        {
            Value = value;
        }

        [ExcludeFromCodeCoverage] public static int LowerBound => 0;

        [ExcludeFromCodeCoverage] public static int UpperBound => 100;

        [ExcludeFromCodeCoverage] public int Value { get; }

        public static Either<IError, ILevel> Create(int value)
        {
            return value switch
                {
                int x when x < LowerBound => Left<IError, ILevel>(new Noob()),
                int x when x > UpperBound => Left<IError, ILevel>(new Cheater()),
                int x => Right<IError, ILevel>(new Level(x))
                };
        }
    }
}
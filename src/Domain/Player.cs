using System.Diagnostics.CodeAnalysis;
using LanguageExt;
using RoterStein.Domain.Classes;
using RoterStein.Domain.Errors;

namespace RoterStein.Domain
{
    public class Player : IPlayer
    {
        private Player(IClass cls, ILevel level)
        {
            Class = cls;
            Level = level;
        }

        [ExcludeFromCodeCoverage] public IClass Class { get; }

        [ExcludeFromCodeCoverage] public ILevel Level { get; }

        public static Either<IError, IPlayer> Create(
            Option<IClass> cls,
            Option<ILevel> level)
        {
            return
                cls.ToEither<IError>(new NullPo()).Bind(c =>
                    level.ToEither<IError>(new NullPo()).Bind<IPlayer>(l =>
                        new Player(c, l)));
        }
    }
}
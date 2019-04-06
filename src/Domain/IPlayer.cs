using RoterStein.Domain.Classes;

namespace RoterStein.Domain
{
    public interface IPlayer
    {
        IClass Class { get; }
        ILevel Level { get; }
    }
}
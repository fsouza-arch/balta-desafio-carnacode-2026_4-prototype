using Prototype.Dominio.Interfaces;

namespace Prototype.Dominio.Entites;

public class Margins : IDocumentPrototype
{
    public int Top { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
    public int Right { get; set; }

    public IDocumentPrototype Clone() => (Margins)this.MemberwiseClone();
}
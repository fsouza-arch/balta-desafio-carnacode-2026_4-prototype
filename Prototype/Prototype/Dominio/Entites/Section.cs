using Prototype.Dominio.Interfaces;

namespace Prototype.Dominio.Entites;

public class Section : IDocumentPrototype
{
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsEditable { get; set; }
    public List<string> Placeholders { get; set; }

    public Section() => Placeholders = new List<string>();

    public IDocumentPrototype Clone()
    {
        var clone = (Section)this.MemberwiseClone();
        // Cópia profunda
        clone.Placeholders = new List<string>(this.Placeholders);
        return clone;
    }
}
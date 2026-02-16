using Prototype.Dominio.Interfaces;

namespace Prototype.Dominio.Entites;

public class DocumentStyle : IDocumentPrototype
{
    public string FontFamily { get; set; }
    public int FontSize { get; set; }
    public string HeaderColor { get; set; }
    public string LogoUrl { get; set; }
    public Margins PageMargins { get; set; }

    public IDocumentPrototype Clone()
    {
        var clone = (DocumentStyle)this.MemberwiseClone();
        clone.PageMargins = (Margins)this.PageMargins.Clone();
        return clone;
    }
}
using Prototype.Dominio.Interfaces;

namespace Prototype.Dominio.Entites;

public class DocumentTemplate : IDocumentPrototype
{
    public string Title { get; set; }
    public string Category { get; set; }
    public List<Section> Sections { get; set; }
    public DocumentStyle Style { get; set; }
    public List<string> RequiredFields { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
    public ApprovalWorkflow Workflow { get; set; }
    public List<string> Tags { get; set; }

    public DocumentTemplate()
    {
        Sections = new List<Section>();
        RequiredFields = new List<string>();
        Metadata = new Dictionary<string, string>();
        Tags = new List<string>();
    }

    public IDocumentPrototype Clone()
    {
        var clone = (DocumentTemplate)this.MemberwiseClone();

        clone.Sections = this.Sections.Select(s => (Section)s.Clone()).ToList();

        clone.Style = (DocumentStyle)this.Style.Clone();
        clone.Workflow = (ApprovalWorkflow)this.Workflow.Clone();

        clone.RequiredFields = new List<string>(this.RequiredFields);
        clone.Tags = new List<string>(this.Tags);
        clone.Metadata = new Dictionary<string, string>(this.Metadata);

        return clone;
    }
}
using Prototype.Dominio.Interfaces;

namespace Prototype.Dominio.Entites;

public class ApprovalWorkflow : IDocumentPrototype
{
    public List<string> Approvers { get; set; }
    public int RequiredApprovals { get; set; }
    public int TimeoutDays { get; set; }

    public ApprovalWorkflow() => Approvers = new List<string>();

    public IDocumentPrototype Clone()
    {
        var clone = (ApprovalWorkflow)this.MemberwiseClone();
        clone.Approvers = new List<string>(this.Approvers);
        return clone;
    }
}
using Prototype.Application.Prototypes;
using Prototype.Dominio.Entites;

namespace Prototype.Application.Services;

public class DocumentService
{
    private readonly TemplateRegistry _registry;

    public DocumentService(TemplateRegistry registry)
    {
        _registry = registry;
        InitializeDefaultTemplates();
    }

    private void InitializeDefaultTemplates()
    {
        Console.WriteLine("--- Inicializando Templates Originais (Operação Custosa) ---");

        var baseContract = new DocumentTemplate
        {
            Title = "Contrato Base",
            Category = "Contratos",
            Style = new DocumentStyle
            {
                FontFamily = "Arial",
                FontSize = 12,
                HeaderColor = "#003366",
                PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
            },
            Workflow = new ApprovalWorkflow { RequiredApprovals = 2, TimeoutDays = 5 }
        };
        baseContract.Workflow.Approvers.Add("gerente@empresa.com");
        baseContract.Workflow.Approvers.Add("juridico@empresa.com");

        var serviceTemplate = (DocumentTemplate)baseContract.Clone();
        serviceTemplate.Title = "Contrato de Prestação de Serviços";
        serviceTemplate.Sections.Add(new Section { Name = "Cláusula 1", Content = "Objeto do serviço..." });
        serviceTemplate.Tags.Add("servicos");
        _registry.AddTemplate("servico", serviceTemplate);

        var consultingTemplate = (DocumentTemplate)baseContract.Clone();
        consultingTemplate.Title = "Contrato de Consultoria";
        consultingTemplate.Sections.Add(new Section { Name = "Cláusula 1", Content = "Objeto da consultoria..." });
        consultingTemplate.Tags.Add("consultoria");
        _registry.AddTemplate("consultoria", consultingTemplate);
    }

    public DocumentTemplate CreateFromTemplate(string type)
    {
        Console.WriteLine($"Clonando template do tipo: {type}");
        return _registry.GetClone(type);
    }
}

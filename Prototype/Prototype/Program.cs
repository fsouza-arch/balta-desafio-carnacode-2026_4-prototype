using Prototype.Application.Prototypes;
using Prototype.Application.Services;
using Prototype.Dominio.Entites;

Console.WriteLine("=== Sistema de Templates (Padrão Prototype) ===\n");

var registry = new TemplateRegistry();
var service = new DocumentService(registry);

var startTime = DateTime.Now;

Console.WriteLine("\nGerando 5 contratos de serviço via CLONAGEM...");
for (int i = 1; i <= 5; i++)
{
    var contract = service.CreateFromTemplate("servico");
    contract.Title = $"Contrato #{i} - Cliente XYZ";
}

var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
Console.WriteLine($"\nTempo total para 5 clones: {elapsed}ms (Muito mais rápido!)");

var original = registry.GetClone("servico");
var clone = (DocumentTemplate)original.Clone();

clone.Sections[0].Name = "NOME ALTERADO NO CLONE";

Console.WriteLine("\n--- Verificação de Deep Copy ---");
Console.WriteLine($"Original Section[0]: {original.Sections[0].Name}");
Console.WriteLine($"Clone Section[0]:    {clone.Sections[0].Name}");

if (original.Sections[0].Name != clone.Sections[0].Name)
    Console.WriteLine("SUCESSO: O clone é totalmente independente!");
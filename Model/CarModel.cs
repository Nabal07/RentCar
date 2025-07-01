// oque aparece para o usuario
// é interessante usar modela para o usurario nao tem contato direto com a entidade

namespace RentCarFree.Api.Models;

public class CarModel
{
    public string? Marca {get; set;}
    public string? Modelo {get; set;}
    public int Ano {get; set;}
    public string? Placa {get; set;}
    public string? Cor {get; set;}
    
}
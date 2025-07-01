namespace RentCarFree.Api.Entities;
public class Car
{
    public Car(string marca, string modelo, string cor, int ano, string placa)
    {
        Id = Guid.NewGuid();
        Marca = marca;
        Modelo = modelo;
        Cor = cor;
        Ano = ano;
        Placa = placa;
        Ativo = true;
        CriadoEm = DateTime.Now;
    }

    public Guid Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public int Ano { get; set; }
    public string Placa { get; set; }
    public DateTime CriadoEm { get; set; }
    public bool Ativo { get; set; }
}
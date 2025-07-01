namespace RentCarFree.Api.Entities;
public class User
{
    public User(string nome, string cpf, string dataNascimento)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        CPF = cpf;
        DataNascimento = dataNascimento;
        CriadoEm = DateTime.Now;
        Ativo = true;

    }

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }
    
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string DataNascimento { get; set; }
    public DateTime CriadoEm { get; set; }
    public bool Ativo { get; set; }

}
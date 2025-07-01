//Representação do banco de dados, tanto em memoria como um real
using RentCarFree.Api.Controllers;
using RentCarFree.Api.Controllers.UsersController;
using RentCarFree.Api.Entities;
namespace RentCarFree.Context;

public class AppDbContext
{
    public AppDbContext()
    {
        // Criando uma lista vazia
        Cars = new List<Car>();
        Users = new List<User>();
    }
    public List<Car> Cars { get; set; }
    public List<User> Users{ get; set; }

}


//postgress server
//pg admin
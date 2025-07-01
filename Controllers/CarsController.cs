using Microsoft.AspNetCore.Mvc;
using RentCarFree.Api.Entities;
using RentCarFree.Api.Models;
using RentCarFree.Context;

namespace RentCarFree.Api.Controllers.CarsController;
[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{

    private readonly AppDbContext _context;
    public CarsController(AppDbContext context)
    {
        _context = context;
    }

    // GET api/cars/
    [HttpGet]
    public IActionResult GetAll()
    {
    // AQUI LISTA OS CARROS QUE ESTAO COMO ATIVO == TRUE
        List<Car> cars = _context.Cars
        .Where(carro => carro.Ativo == true) //apenas quem esta true
        .ToList();
        
        return Ok(cars);
    }

    // GET api/cars/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id) //assinatura do metodo
    {

        var car = _context.Cars.FirstOrDefault(carro => carro.Id == id);

        if(car == null)
        {
            return NotFound("Nao foi possivel encontar o carro com o Id: " + id);
        }

        return Ok(car);
    }

    //POST api/cars
    [HttpPost]
    public IActionResult Post(CarModel model)
    {
        // var car = new Car()
        // {
        //     id = Guid.NewGuid(),
        //     marca = model.marca,
        //     modelo = model.modelo,
        //     cor = model.cor,
        //     ano = model.ano,
        //     placa = model.placa,
        //     CriadoEm = DateTime.Now,
        //     ativo = true
        // };

        var car = new Car(model.Marca, model.Modelo, model.Cor, model.Ano, model.Placa);
                                                                                                                                                                
        _context.Cars.Add(car);

        return Created("Post", car);
    }

    // PUT api/cars
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, CarModel model) //assinatura do metodo
    {
        var car = _context.Cars.FirstOrDefault(carro => carro.Id == id);  

        if( car == null)
            return NotFound();                                                                                      

        //CoaLencia nula
        //Operador ternario: (condição) ? [se for verdade faça isso] : [se for falso faça isso]

        car.Marca = model.Marca ?? car.Marca;
        car.Modelo = model.Modelo ?? car.Modelo;
        car.Placa = model.Placa ?? car.Placa;
        car.Ano = (model.Ano > 0) ? model.Ano : car.Ano ;
        car.Cor = model.Cor ?? car.Cor;

        return Ok(car);
    }

    // DELETE api/cars
    [HttpDelete ("{id}")]
    public IActionResult Delete(Guid id)
    {
        
        var car = _context.Cars.FirstOrDefault(carro => carro.Id == id);

        if(car == null)
        {
            return NotFound("Nao foi possivel encontrar o carro de Id: " + id);
        }

        car.Ativo = false;
        var resposta = "Seu carro foi removido / vendido com sucesso";
       //_context.Cars.Remove(car);

        return Ok(resposta);
    }
}












































// FEITOS:
// REST API
// Banco de dados em memoria
// LINQ (Where, FirstOrDefault, ToList)
// CRUD (CREATE, READ, DELETE)

//PROXIMOS PASSOS:
// ADICIONAR UM BANCO DE DADOS SQL atraves do EF Core
// FINALIZAR O METODO PUT 
// CRIAR UMA CAMADA DE SERVISOS
// CRIAR UMA CAMADA DE REPOSITORIOS
// SUBIR NO GITHUB

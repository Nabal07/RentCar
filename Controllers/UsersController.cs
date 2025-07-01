using System.Net;
using Microsoft.AspNetCore.Mvc;
using RentCarFree.Api.Entities;
using RentCarFree.Api.Models;
using RentCarFree.Context;

namespace RentCarFree.Api.Controllers.UsersController;
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    // Parametro para chamar o banco
    private readonly AppDbContext _context;
    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // GET api/users
    [HttpGet]
    public IActionResult GetAll()
    {
        List<User> users = _context.Users
        .Where(user => user.Ativo == true) //apenas quem esta true
        .ToList();
        
        return Ok(users);
    }

    // GET api/users/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id && user.Ativo == true);
        if (user == null)
        {
            return NotFound("Nao foi possivel encontar o usuário com o Id: " + id);
        }

        return Ok(user);
    }

    // POST api/users
    [HttpPost]
    public IActionResult Post(UserModel model)
    {
        var user = new User(model.Nome, model.CPF, model.DataNascimento);
        _context.Users.Add(user);
        _context.SaveChanges();
        return Created("Post", user);
    }

    // PUT api/users/{id}
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, UserModel model)
    {
        var userDB = _context.Users.FirstOrDefault(user => user.Id == id);
        if (userDB == null)
        {
            return NotFound();
        }
        
        userDB.Nome = model.Nome ?? userDB.Nome;
        userDB.CPF = model.CPF ?? userDB.CPF;
        userDB.DataNascimento = model.DataNascimento ?? userDB.DataNascimento;

        _context.SaveChanges();
        return Ok(userDB);
    }

    // DELETE api/users/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);
        if (user == null)
        {
            return NotFound("Nao foi possivel encontrar o usuário de Id: " + id);
        }
        
        user.Ativo = false;
        _context.SaveChanges();
        var resposta = "Seu usuário foi removido com sucesso";

        return Ok(resposta);
    }
}

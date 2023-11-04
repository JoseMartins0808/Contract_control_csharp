using API.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using API.Persistence;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Controllers;

[ApiController]
[Route("users")]
public class PersonController: ControllerBase {

    private DatabaseContext _repository {get; set;}

    public PersonController (DatabaseContext repository) {
        this._repository = repository;
    }

    [HttpGet]
    public ActionResult<List<Person>> GetAllPersons(){
       
        List<Person> result = _repository.Persons.Include(person => person.contracts).ToList();

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Person> createPerson ([FromBody]Person person){

        _repository.Persons.Add(person);
        _repository.SaveChanges();

        return Created("Created", person);
    }

    [HttpPatch("{id}")]
    public ActionResult<Person> updatePerson ([FromRoute]int id, [FromBody]Person person) {

        Person? personFound = _repository.Persons.SingleOrDefault(user => user.id == id);

        if(personFound is null) return BadRequest(new{
            message = "User not found",
            status = HttpStatusCode.BadRequest
        });

        try{

            _repository.Persons.Update(personFound);
            _repository.SaveChanges();

        }catch(System.Exception){

            return BadRequest(new{
                message = "User not found",
                status = HttpStatusCode.BadRequest
            });
        }
        
        return Ok(person);
    }

    [HttpDelete("{id}")]
    public ActionResult<object> deletePerson ([FromRoute]int id) {

        Person? personFound = _repository.Persons.SingleOrDefault(user => user.id == id);

        if(personFound is null) return BadRequest(new {
            message = "Person not found",
            status = HttpStatusCode.BadRequest
        });

        _repository.Persons.Remove(personFound);
        _repository.SaveChanges();

        return NoContent();
    }

}
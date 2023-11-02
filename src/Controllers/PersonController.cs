using API.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using API.Persistence;

namespace API.Controllers;

[ApiController]
[Route("users")]
public class PersonController: ControllerBase {

    private DatabaseContext _repository {get; set;}

    public PersonController (DatabaseContext repository) {
        this._repository = repository;
    }

    [HttpGet]
    public List<Person> GetAllPersons(){
       
        return _repository.Persons.ToList();
    }

    [HttpPost]
    public Person createPerson ([FromBody]Person person){

        _repository.Persons.Add(person);
        _repository.SaveChanges();

        return person;
    }

    [HttpPatch("{name}")]
    public Person updatePerson ([FromRoute]string name, [FromBody]Person person) {
        // Person person = new Person();
        person.name = name;
        return person;
    }


}
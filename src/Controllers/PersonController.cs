using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("users")]
public class PersonController: ControllerBase {

    [HttpGet]
    public Person Get(){
        Person person = new Person("Pedro", "053", true, "1234", 5);

        Contract newContract = new Contract();

        person.contracts.Add(newContract);

        return person;
    }

    [HttpPost]
    public Person createPerson (Person person){

        return person;
    }


}
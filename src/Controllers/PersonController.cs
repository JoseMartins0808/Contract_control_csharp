using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("users")]
public class PersonController: ControllerBase {

    [HttpGet]
    public string Hello (){
        return "Hell O!";
    }


}
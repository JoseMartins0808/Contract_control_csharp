namespace API.Models;


public class Person {

    public Person(){
        this.name = "John Doe";
        this.cpf = "000.111.222-33";
        this.IsActive = true;
    }

    public string name {get; set; }

    public int age {get; set;}

    public string cpf {get; set;}

    public Boolean? IsActive {get; set;}

}

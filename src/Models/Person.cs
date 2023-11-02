namespace API.Models;
using System.Collections.Generic;

public class Person {

    public Person(){
        this.name = "John";
        this.cpf = "000.222.555-22";
        this.password = "1234";
        this.contracts = new List<Contract>();
    }

    public Person(string name, string cpf, Boolean is_active, string password, int age){
        this.name = name;
        this.password = password;
        this.age = age;
        this.cpf = cpf;
        this.is_active = is_active;
        this.contracts = new List<Contract>();
    }

    public int id {get; set;}

    public string name {get; set; }

    public string password {get; set;}

    public int age {get; set;}

    public string cpf {get; set;}

    public Boolean? is_active {get; set;}

    public List<Contract> contracts {get; set; }
}

//   #EuPerdiOMedoDoDotNet

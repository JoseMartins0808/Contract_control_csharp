namespace API.Models;

public class Contract {

    public Contract () {
        this.created_at = DateTime.Now;
        this.value = 0;
        this.token_id = "1234";
        this.paid = false;
    }
    
    public DateTime created_at{get; set;}

    public string token_id{get; set;}

    public double value {get; set;}

    public Boolean paid {get; set;}
}
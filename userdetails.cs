public class userdetails
{
<<<<<<< HEAD
    internal string pass;
    internal double balance;
    internal string email;
    internal DateOnly birthdate;
    internal int ?id;
    internal string category;
    internal int max_count;
    internal string name;
=======
    public string pass;
    public double balance;
    public string email;
    public DateOnly birthdate;
    public int ?id;
    public string category;
    internal int max_count;
    
    public string name;
>>>>>>> 54c1d5a48c955a04e5ccd482bd8e930815702f35
    public userdetails(string pass, double balance, string email, DateOnly birthdate, int? id, string category = null)
    {
        this.pass = pass;
        this.balance = balance;
        this.email = email;
        this.birthdate = birthdate;
        this.id = id;
        this.category = category ?? (balance > 10000 ? "vip" : "regular");
    }
}
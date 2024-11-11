public class userdetails
{

    internal string pass;
    internal double balance;
    internal string email;
    internal DateOnly birthdate;
    internal int ?id;
    internal string category;
    internal int max_count;
    internal string name;
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

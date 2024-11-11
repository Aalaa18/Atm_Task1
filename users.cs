using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;




public class users
    {


        internal int counter = 3;
        internal Dictionary<string, userdetails> user = new Dictionary<string, userdetails>();
        public users() {
        DateOnly birthDate1 = DateOnly.ParseExact("18/03/2003", "dd/MM/yyyy");
        DateOnly birthDate2 = DateOnly.ParseExact("18/03/2003", "dd/MM/yyyy");
        user.Add("Aalaa",new userdetails("12345678",5600,"lili.adel@gamil.com",birthDate1,1,"regular") );
        user.Add("sama", new userdetails("123456789",11000,"sama@gamil.com",birthDate2,2,"vip") );
        }
        public bool checkuser_category(string name)
         {
            if (user[name].category=="vip")
            return true;
            else
            return false;
         }
        public void showbalance(string name)
         {  
             if(user.ContainsKey(name))
        {
            Console.WriteLine("your current balance is:"+" "+user[name].balance);
        }
        else
        {
            Console.WriteLine("incorrect name"); 
        }
        
    
       
         }
        public void addusers( userdetails s,string name)
        {

           s.id = counter;
          // s.category = determinetype(s.balance);
           user.Add(name, new userdetails(s.pass,s.balance,s.email,s.birthdate, s.id));
           counter++;

    }
        public void display()
        {
            foreach (var user in user)
            {
                Console.WriteLine(user.Key+"  "+user.Value.balance);
            }
        }
        public bool checkusers(string name, string pass)
    {
        bool checking = false;
        foreach (var x in user)
        {


            if (x.Key == name && x.Value.pass == pass)
            {
                checking = true;
                break;
            }
            else
            {
                checking = false;
            }
            
        }
        return checking;
    }

}


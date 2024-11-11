using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

public abstract class savingoperations
{
    internal Stack<(string, string, double, DateTime)> stack = new Stack<(string, string, double, DateTime)>();
    public abstract void save_date_time(String name, string operation, Double amount);
    public abstract void display_stack();
}

public class operations
{
    private users _users;

    internal List<TransactionInfo> transactions = new List<TransactionInfo>();
    internal List<TransactionInfo> transhistory = new List<TransactionInfo>();
    internal List<TransactionInfo> non_mange=new List<TransactionInfo>();

    List<TransactionInfo> transactions = new List<TransactionInfo>();
    List<TransactionInfo> transhistory = new List<TransactionInfo>();
    List<TransactionInfo> non_mange=new List<TransactionInfo>();

    public operations(users users)
    {
        _users = users;
    }
    public void start()
    {
        Console.WriteLine(@"
1- login
2- create account
");
    }
    public void showoptions(string name)
    {
        if (_users.user[name].category == "regular")
        {
            Console.WriteLine(@"
1- Perform a current balance inquiry
2- Perform a deposit
3- Perform a withdrawal
4- make a transaction
5- show recieved transcation
6- show sent transactions
7- show non_managerical operations
press x to exit

"


);
        }
        else
        {
            Console.WriteLine(@"
1- Perform a current balance inquiry
2- Perform a deposit
3- Perform a withdrawal
4- make a transaction
5- show recieved transcation
6- show sent transactions
7- show non_managerical operations
8-Add new user
9-remove a user
press x to exit

"
);

        }

    }
    public double deposite(string s, double amount)
    {
        // Check if the user exists in the dictionary
        if (_users.user.ContainsKey(s))
        {
            //Extract the tuple(pass, balance) from the dictionary



            //Update the balance
            _users.user[s].balance += amount;

            //Reassign the modified tuple back to the dictionary

            Console.WriteLine(_users.user[s].balance);

            // Return the updated balance
            return _users.user[s].balance;
        }
        else
        {
            throw new KeyNotFoundException("User not found.");
        }
    }
    public double withdraw(string s, double amount)
    {
        var info = _users.user[s];
        if (amount > info.balance)
        {
            Console.WriteLine("there's no sufficient balance ");

        }
        else
        {
            info.balance -= amount;
            _users.user[s] = info;

        }
        return info.balance;
    }

    internal int count_id = 1, count = 1;
    public void transfermoney(string sender, string reciever, double amount)
    {
        if (_users.user[sender].max_count > 10)
        {
            Console.WriteLine("sorry you have reached your max operations today");
            
        }
        else
        {
            if (_users.user[sender].balance > amount)
            {
                if (_users.user.ContainsKey(reciever))
                {

                    TransactionInfo t = new TransactionInfo
                    {
                        UserId = _users.user[reciever].id,
                        TransactionId = 1,
                        reciever_Username = reciever,
                        sender_Username = sender,
                        OperationAmount = amount,
                        balancebefore = _users.user[reciever].balance,
                        // balanceafter = users.user[s].balance - amount,
                        operationdatetime = DateTime.Now,
                        OperationId = count_id++,
                        iscomplete = false,

                    };
                    //users.user[s].balance -= amount;
                    transactions.Add(t);
                    transhistory.Add(t);
                    _users.user[sender].max_count = count++;
                    Console.WriteLine("Added successfully");
                    _users.user[sender].balance -= amount;
                }
                else
                {
                    Console.WriteLine("please enter correct username");
                }
            }
            else
            {

                Console.WriteLine("there's no sufficient amount of money");
            }
        }
    }
    public void DisplayTransactions( string name)
    {
        if(transactions.Count==0)
        {
            Console.WriteLine("there's no operations done yet");

        }
        foreach (var transaction in transhistory)
        {
            if(transaction.sender_Username == name)
            {
                Console.WriteLine("Transaction ID: " + transaction.TransactionId);
                Console.WriteLine("Username: " + transaction.reciever_Username);
                Console.WriteLine("Operation ID: " + transaction.OperationId);
                Console.WriteLine("Operation Amount: " + transaction.OperationAmount);
                Console.WriteLine("Operation Date and Time: " + transaction.operationdatetime);
                Console.WriteLine("Is Complete: " + transaction.iscomplete);
                Console.WriteLine("------------------------------------");
            }
            else
            {
                Console.WriteLine("there's no operations done yet");
            }

        }
    }
    public void recieveMoney(string s)
    {


        if (transactions.Count == 0 || !transactions.Any(x => x.reciever_Username == s))
        {
            Console.WriteLine("there's no Transactions");
        }
        else
        {
            // var newuser = users.user[s];
            foreach (var t in transactions)
            {
                if (t.reciever_Username == s && transactions.Count != 0)
                {
                    Console.WriteLine(@"Sender_Name:" + " " + t.sender_Username + " " + "Operation ID: " + t.OperationId + " " + "Operation Amount: " + t.OperationAmount + " " + "Operation Date and Time: " + t.operationdatetime
                   + " " + "if you want to accept it please enter the operation_id other wise press x"
                     );

                }
            }
            string x = Console.ReadLine();
            foreach (var tr in transactions)
            {
                if (x.ToLower() == "x")
                {
                    break;
                }
                else
                {
                    if (int.Parse(x) == tr.OperationId && tr.reciever_Username == s && !tr.iscomplete)
                    {
                        tr.balancebefore = _users.user[s].balance;
                        tr.balanceafter = _users.user[s].balance + tr.OperationAmount;
                        tr.iscomplete = true;
                        _users.user[s].balance = tr.balanceafter;
                        Console.WriteLine("Transaction accepted and balance updated.");
                        transactions.RemoveAll(ss => ss.OperationId == int.Parse(x));

                        break;


                    }



                }
            }







        }


        //break;



    }
    public void removeusers(string s)
    {
        if (!transactions.Any(x => x.reciever_Username == s))
        {


            _users.user.Remove(s);
            Console.WriteLine("removed succesfly");


        }
        else
        {
            Console.WriteLine("Alerttttt there's a transactions");
            foreach (var t in transactions)
            {
                Console.WriteLine(@"sender_name:" + " " + t.sender_Username + " " + "operation_id:" + " " + t.OperationId + " " + "amount:" + " " + t.OperationAmount

                    );
            }
            Console.WriteLine("Do you want to cancel these transactions  y/n ");
            char c = char.Parse(Console.ReadLine());
            foreach (var t in transactions)
            {
                if (c == 'n' || c == 'N')
                {
                    break;

                }
                else if (c == 'y' || c == 'Y')
                {
                    _users.user.Remove(s);
                    _users.user[t.sender_Username].balance += t.OperationAmount;
                    Console.WriteLine("removed succesfly");
                    break;

                }
            }



        }
    }
    public void addusers(string ans)
    {
        string user_name;
        do
        {
            Console.WriteLine("please enter the user name");
            user_name = Console.ReadLine();
            if (_users.user.ContainsKey(user_name))
            {
                Console.WriteLine("these name is already taken");
            }
        } while (_users.user.ContainsKey(user_name));

        string user_pass;
        do
        {
            Console.WriteLine("please enter the  password the password should be at lease 8 characters");
             user_pass = Console.ReadLine();
            if (user_pass.Length < 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" the password is too short");
                Console.ResetColor();


            }
        } while (user_pass.Length < 8);

        string user_mail;
        do {
            Console.WriteLine("please enter the  email it should be like exaple***@gmail.com");
             user_mail = Console.ReadLine();
            if (!user_mail.Contains("@gmail.com"))
            {
                Console.WriteLine("please enter a valid email");

            }
        } while (!user_mail.Contains("@gmail.com"));

        DateOnly day;
        Console.WriteLine("please enter the  birthdate in the format MM/dd/yyyy:\" ");
        var user_birthdate = Console.ReadLine();
        day = DateOnly.ParseExact(user_birthdate, "M/d/yyyy");
      

        Console.WriteLine("please enter the  balance you want too add");
        var user_balance = double.Parse(Console.ReadLine());
        userdetails new_user = new userdetails(user_pass, user_balance,  user_mail, day,null);
        _users.addusers(new_user, user_name);
        Console.ForegroundColor = ConsoleColor.Green;
        save_nonmange(user_name, ans);
        //_users.display();
        Console.WriteLine("User added successfully! ");
        Console.ResetColor();
        


    }
    public void save_nonmange(string name,string x)
    {
        if (int.TryParse(x, out int z))
        {

            if (z == 1)
            {
                TransactionInfo info = new TransactionInfo
                {
                    sender_Username = name,
                    TransactionId = 2,
                    operation_name = "Login",
                    operationdatetime = DateTime.Now,

                };
                non_mange.Add(info);
            }
            else if (z == 2 || z == 6)
            {
                TransactionInfo info = new TransactionInfo
                {
                    sender_Username = name,
                    TransactionId = 3,
                    operation_name = "create account",
                    operationdatetime = DateTime.Now,

                };
                non_mange.Add(info);
            }
        }
        else if (x.ToLower() == "x" || x.ToUpper() == "X")
        {
            TransactionInfo info = new TransactionInfo
            {
                sender_Username = name,
                TransactionId = 3,
                operation_name = "Log out",
                operationdatetime = DateTime.Now,

            };
            non_mange.Add(info);
        }
       

    }
    public void display_nonmange(string name)
    {
        foreach(TransactionInfo info in non_mange)
        {
            if(info.sender_Username==name)
            Console.WriteLine(info.sender_Username+" "+info.TransactionId+" "+info.operationdatetime+" "+info.operation_name);
        }
    }
}






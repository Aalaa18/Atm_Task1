using System;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            users users = new users();
            operations operations = new operations(users);
            
          
            
            
            while (true)
            {
                operations.start();
                Console.WriteLine("Enter your choice");

                var an=( Console.ReadLine());
              
                if (int.Parse(an) == 1)
                {
                    Console.Write("please enter your user name: ");
                    string name = Console.ReadLine();
                    Console.Write("please enter the password: ");
                    string pass = Console.ReadLine();
                    operations.save_nonmange(name, an);


                    if (users.checkusers(name, pass))
                    {
                        while (true)
                        {
                            try
                            {
                                operations.showoptions(name);
                                Console.WriteLine("Enter your choice");
                                string z = Console.ReadLine();
                                if(z.ToLower()=="x"||z.ToUpper()=="X")
                                {
                                    operations.save_nonmange(name,z);
                                    break;
                                }
                                int x = int.Parse(z);
                                
                                 if (x == 1)
                                {
                                    users.showbalance(name);
                                    
               

                                }
                                else if (x == 2)
                                {

                                    Console.WriteLine("enter the deposite amount ");
                                    var dep = Console.ReadLine();
                                    double value = operations.deposite( name, Math.Abs(double.Parse(dep)));
                                    Console.WriteLine($"the balance after deposite :{value}");
                                    //users.display();

                                }
                                else if (x == 3)
                                {
                                    Console.WriteLine("enter the withdraw amount");
                                    var with = Console.ReadLine();
                                   
                                    double value2 = operations.withdraw( name, Math.Abs(double.Parse(with)));
                                    Console.WriteLine($"the balance after withdraw :{value2}");
                                   

                                }
                                else if (x == 4)
                                {
                                    Console.WriteLine("please enter the Reciever Name");
                                    var rec_name = Console.ReadLine();
                                    Console.WriteLine("please enter the amount");
                                    var rec_amount = double.Parse(Console.ReadLine());
                                   operations.transfermoney(name,rec_name, rec_amount);
                                   
                         

                                }
                                else if(x==5)
                                {
                                   
                                    operations.recieveMoney(name);
                            
                                }
                                else if (x == 6)
                                {

                                    operations.DisplayTransactions(name);

                                }
                                else if (x == 7)
                                {

                                    operations.display_nonmange(name);

                                }
                                else if (x == 8 && users.checkuser_category(name))
                                {
                                    operations.addusers(z);



                                }
                                else if (x == 9&&users.checkuser_category(name))
                                {
                                    Console.WriteLine("please enter the user name");
                                    var user_name = Console.ReadLine();
                                    //users.display();
                                    operations.removeusers(user_name);
     
                                }



                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("please enter a correct number from 1 --> 5");
                                    Console.ResetColor();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("error! please enter a number");

                            }
                            finally
                            {
                                Console.ResetColor();
                            }

                        }


                        
                    }
                    else
                    {
                        Console.WriteLine("the user name or password is not correct try again");
                    }
                }

                else if(int.Parse(an) ==2)
                {

                    operations.addusers(an);
                    
                    Console.WriteLine("now you can login ! ");





                }
                }
            }

        }
        


    }

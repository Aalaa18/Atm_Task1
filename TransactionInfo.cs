using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TransactionInfo
{
    internal int TransactionId;
    internal int? UserId;
    internal int OperationId;
    internal string sender_Username;
    internal string reciever_Username;
    internal double OperationAmount;
    internal DateTime operationdatetime;
    internal double balancebefore;
    internal double balanceafter;
    internal bool iscomplete;
    internal string operation_name;




}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebToDoList.Servises
{
    public interface IMessageInterface
    {
        string Send();
    }

    public class TimeService
    {
        public string GetTime() => DateTime.Now.ToString("hh:mm");
    }
}

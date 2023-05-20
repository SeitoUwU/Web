using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace Web.Models
{
    public class BarSenttings:IBarSenttings
    {
        public String Server { get; set; }
        public String Database { get; set; }
        public String Collection { get; set;}

    }
    public interface IBarSenttings
    {
        String Server { get; set; }
        String Database { get; set; }
       String Collection { get; set; }

    }
}

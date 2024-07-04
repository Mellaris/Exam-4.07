using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1
{
    public static class AllLists
    {
        public static List<string> typeAgent = new List<string> { "1 тип", "2 тип", "3 тип" };
        public static List<string> typeProduct = new List<string> { "Продукты", "Одежда", "Техника" };
        public static List<AddNewIndornationAgents> agents = new List<AddNewIndornationAgents>();
        public static List<AddNewIndornationAgents> editAgent = new List<AddNewIndornationAgents>();
        public static List<AddNewIndornationAgents> rangAgent = new List<AddNewIndornationAgents>();
    }
}

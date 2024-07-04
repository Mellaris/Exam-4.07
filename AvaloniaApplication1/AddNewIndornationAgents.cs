using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1
{
    public class AddNewIndornationAgents
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Rang { get; set; }
        public string Adres { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string NameBos { get; set; }
        public int NomberPhone { get; set; }
        public string Email { get; set; }
        public string fileName { get; set; }
        public int AllSales { get; set; }
        public int Discount { get; set; }
        public int idEdit { get; set; }
        public int idAg { get; set; }
        public Bitmap ImageLogo
        {
            get
            {
                return new Bitmap(fileName);
            }
            set { }
        }
        public List<HistoryAgent> salesAgent { get; set; } = new List<HistoryAgent>();
    }
}

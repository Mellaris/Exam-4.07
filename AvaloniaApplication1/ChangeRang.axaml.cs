using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Numerics;
using System.Xml.Linq;

namespace AvaloniaApplication1;

public partial class ChangeRang : Window
{
    public ChangeRang()
    {
        InitializeComponent();
        AllLists.rangAgent.Sort((x, y) => y.Rang.CompareTo(x.Rang));
        foreach (AddNewIndornationAgents agent in AllLists.rangAgent)
        {
            rang.Text  = agent.Rang.ToString();
            break;
        }
    }
    public void EditRang(object sender, RoutedEventArgs e)
    {
        foreach (AddNewIndornationAgents agent in AllLists.rangAgent)
        {
            agent.Rang = Convert.ToInt32(rang.Text);         
        }
        foreach (AddNewIndornationAgents agent in AllLists.rangAgent)
        {
            foreach (AddNewIndornationAgents agent2 in AllLists.agents)
            {
                if (agent.idEdit == agent2.idEdit)
                {
                    agent2.Name = agent.Name;
                    agent2.Type = agent.Type;
                    agent2.Rang = agent.Rang;
                    agent2.Adres = agent.Adres;
                    agent2.INN = agent.INN;
                    agent2.KPP = agent.KPP;
                    agent2.NameBos = agent.NameBos;
                    agent2.NomberPhone = agent.NomberPhone;
                    agent2.Email = agent.Email;
                    agent2.fileName = agent.fileName;
                    agent2.AllSales = agent.AllSales;
                    agent2.Discount = agent.Discount;
                    agent2.salesAgent = agent.salesAgent;

                }
            }
        }
        Close();
    }
}
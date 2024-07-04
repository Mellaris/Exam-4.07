using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Linq;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        int currentPage = 0;
        public MainWindow()
        {
            InitializeComponent();
            if(AllLists.agents.Count > 0)
            {
                AgentsAll.ItemsSource = AllLists.agents.ToList();
            }
            UpdateList();
            namberList.Text = "1";
        }
        public void Change(object sender, RoutedEventArgs e)
        {
            AllLists.rangAgent.Clear();
            foreach(AddNewIndornationAgents a in AgentsAll.SelectedItems)
            {
                AllLists.rangAgent.Add(a);
            }
            new ChangeRang().ShowDialog(this);
        }
        public void UpdateList()
        {
            
            if(AllLists.agents.Count > 0 )
            {
                int startIndex = currentPage * 10;
                AgentsAll.ItemsSource = AllLists.agents.Skip(startIndex).Take(10).ToList();
            }
        }
        public void Run(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int maxPage = (AllLists.agents.Count + 1) / 2 - 1;
            if (currentPage < maxPage)
            {
                currentPage++;
                int n = currentPage;
                namberList.Text = Convert.ToString(n + 1);
                UpdateList();
            }
        }
        public void Back(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                int n = currentPage;
                namberList.Text = Convert.ToString(n);
                UpdateList();
            }
        }
        public void Point(object sender, PointerReleasedEventArgs e)
        {
            rangEdit.IsVisible = true;

        }
        public void SortMinus(object sender, RoutedEventArgs e)
        {
            if(sortirovka.SelectedIndex == 0)
            {
                AllLists.agents.Sort((p1, p2) => -p1.Name.CompareTo(p2.Name));
                AgentsAll.ItemsSource = AllLists.agents.ToList();
            }
            else if(sortirovka.SelectedIndex == 1)
            {
                AllLists.agents.Sort((x, y) => y.Discount.CompareTo(x.Discount));
                AgentsAll.ItemsSource = AllLists.agents.ToList();
            }
            else if(sortirovka.SelectedIndex == 2)
            {
                AllLists.agents.Sort((x, y) => y.Rang.CompareTo(x.Rang));
                AgentsAll.ItemsSource = AllLists.agents.ToList();
            }
        }
        public void SortPlus(object sender, RoutedEventArgs e)
        {
            if (sortirovka.SelectedIndex == 0)
            {
                AllLists.agents.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
                AgentsAll.ItemsSource = AllLists.agents.ToList();
            }
            else if (sortirovka.SelectedIndex == 1)
            {
                AllLists.agents.Sort((x, y) => x.Discount.CompareTo(y.Discount));
                AgentsAll.ItemsSource = AllLists.agents.ToList();
            }
            else if (sortirovka.SelectedIndex == 2)
            {
                AllLists.agents.Sort((x, y) => x.Rang.CompareTo(y.Rang));
                AgentsAll.ItemsSource = AllLists.agents.ToList();
            }
        }
        public void EditAgent(object sender, RoutedEventArgs e)
        {
            int selectDel = (int)(sender as Button).Tag;
            foreach(AddNewIndornationAgents agent in AllLists.agents)
            {
                if(selectDel == agent.idEdit)
                {
                    AllLists.editAgent.Add(agent);
                    break;
                }
            }
            new Edit().Show();
            Close();
        }
        public void Add(object sender, RoutedEventArgs e)
        {
            new AddNewAgent().Show();
            Close();
        }
    }
}
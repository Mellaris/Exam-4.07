using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaApplication1
{
    public partial class Edit : Window
    {
        string fileName;
        int sumAllKol = 0;
        int sales = 0;
        public List<HistoryAgent> history = new List<HistoryAgent>();
        public List<HistoryAgent> history2 = new List<HistoryAgent>();
        public Edit()
        {
            InitializeComponent();
            foreach (AddNewIndornationAgents agent in AllLists.editAgent)
            {
                name.Text = agent.Name;
                rang.Text = Convert.ToString(agent.Rang);
                adres.Text = Convert.ToString(agent.Adres);
                inn.Text = agent.INN;
                kpp.Text = agent.KPP;
                nameBos.Text = agent.NameBos;
                phone.Text = Convert.ToString(agent.NomberPhone);
                email.Text = Convert.ToString(agent.Email);
                im.Source = new Bitmap(agent.fileName);
                fileName = agent.fileName;
                History.ItemsSource = agent.salesAgent;
                history = agent.salesAgent;
            }
        }
        public void DeleteThisAgent(object sender, RoutedEventArgs e)
        {
            foreach (AddNewIndornationAgents agentEdit in AllLists.editAgent)
            {
                foreach (AddNewIndornationAgents agent in AllLists.agents)
                {
                    if (agentEdit.idAg == agent.idAg)
                    {
                        int select = agentEdit.idAg;
                        if (history.Count == 0)
                        {
                            AllLists.agents.RemoveAt(select);
                            new MainWindow().Show();
                            Close();
                            break;
                        }
                    }
                }
            }
        }
        public void Add(object sender, RoutedEventArgs e)
        {
            if (history.Count > 0)
            {
                foreach (HistoryAgent agent in history)
                {
                    sumAllKol = sumAllKol + agent.KolProduct;
                }
            }
            if (sumAllKol >= 0 && sumAllKol <= 10000) { sales = 0; }
            else if (sumAllKol >= 10000 && sumAllKol <= 50000) { sales = 5; }
            else if (sumAllKol >= 50000 && sumAllKol <= 150000) { sales = 10; }
            else if (sumAllKol >= 150000 && sumAllKol <= 500000) { sales = 20; }
            else { sales = 25; }
            foreach (AddNewIndornationAgents agent in AllLists.editAgent)
            {
                foreach (AddNewIndornationAgents agent2 in AllLists.agents)
                {
                    if (agent.idEdit == agent2.idEdit)
                    {
                        agent2.Name = name.Text;
                        agent2.Type = Convert.ToString(typeAgents.SelectedIndex);
                        agent2.Rang = Convert.ToInt32(rang.Text);
                        agent2.Adres = adres.Text;
                        agent2.INN = inn.Text;
                        agent2.KPP = kpp.Text;
                        agent2.NameBos = nameBos.Text;
                        agent2.NomberPhone = Convert.ToInt32(phone.Text);
                        agent2.Email = email.Text;
                        agent2.fileName = fileName;
                        agent2.AllSales = sumAllKol;
                        agent2.Discount = sales;
                        agent2.salesAgent = history;

                    }
                }
            }
            if (AllLists.agents.Count > 0)
            {
                foreach (AddNewIndornationAgents agent in AllLists.agents)
                {
                    foreach (string a in AllLists.typeAgent)
                    {
                        if (agent.Type == Convert.ToString(AllLists.typeAgent.IndexOf(a)))
                        {
                            agent.Type = a;
                            break;
                        }
                    }
                }
            }
            AllLists.editAgent.Clear();

            new MainWindow().Show();
            Close();
        }
        public void NewHistory(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(kol.Text) && !string.IsNullOrEmpty(date.Text))
            {
                history.Add(new HistoryAgent()
                {
                    NameProduct = Convert.ToString(product.SelectedIndex),
                    KolProduct = Convert.ToInt32(kol.Text),
                    Date = Convert.ToDateTime(date.Text),
                    idDelete = history.Count,
                });
            }
            if (history.Count > 0)
            {
                foreach (HistoryAgent agent in history)
                {
                    foreach (string a in AllLists.typeProduct)
                    {
                        if (agent.NameProduct == Convert.ToString(AllLists.typeProduct.IndexOf(a)))
                        {
                            agent.NameProduct = a;
                            break;
                        }
                    }
                }

                History.ItemsSource = history.ToList();
            }

        }
        public void DeleteHistory(object sender, RoutedEventArgs e)
        {
            //Удаление происходит, но по какой-то причине лист не обновляется. Хотя он пустой. Ошибка только визуальная 
            int selectDel = (int)(sender as Button).Tag;
            foreach (HistoryAgent a in history)
            {
                if (selectDel == history.IndexOf(a))
                {
                    history.RemoveAt(selectDel);
                    break;
                }
            }
            History.ItemsSource = history.ToList();
        }
        public async void NewPhoto(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                var topLevel = await openFileDialog.ShowAsync(this);
                fileName = String.Join("", topLevel);
                im.Source = new Bitmap(fileName);
            }
            catch
            {
                fileName = "Assets/picture_заглушка.png";
                im.Source = new Bitmap(fileName);
            }
        }


    }
}

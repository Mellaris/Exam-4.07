using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaApplication1
{
    public partial class AddNewAgent : Window
    {
        string fileName;
        int helpForPhoto = 0;
        int sumAllKol = 0;
        int sales = 0;
        public List<HistoryAgent> history = new List<HistoryAgent>();
        public AddNewAgent()
        {
            InitializeComponent();
        }
        public void AddAgent(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(rang.Text) && !string.IsNullOrEmpty(phone.Text) && !string.IsNullOrEmpty(email.Text))
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
                if(helpForPhoto == 0)
                {
                    fileName = "Assets/picture_заглушка.png";
                    im.Source = new Bitmap(fileName);
                }
                AllLists.agents.Add(new AddNewIndornationAgents()
                {
                    Name = name.Text,
                    Type = Convert.ToString(typeAgents.SelectedIndex),
                    Rang = Convert.ToInt32(rang.Text),
                    Adres = adres.Text,
                    INN = inn.Text,
                    KPP = kpp.Text,
                    NameBos = nameBos.Text,
                    NomberPhone = Convert.ToInt32(phone.Text),
                    Email = email.Text,
                    fileName = fileName,
                    AllSales = sumAllKol,
                    Discount = sales,
                    idEdit = AllLists.agents.Count,
                    idAg = AllLists.agents.Count,
                    salesAgent = history,
                });
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

            helpForPhoto = 0;

            new MainWindow().Show();
            Close();
        }
        public void DeleteHistory(object sender, RoutedEventArgs e)
        {
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
        public async void AddPhoto(object sender, RoutedEventArgs e)
        {
            try
            {
                helpForPhoto = 1;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                var topLevel = await openFileDialog.ShowAsync(this);
                fileName = string.Join("", topLevel);
                im.Source = new Bitmap(fileName);
            }
            catch
            {
                helpForPhoto = 1;
                fileName = "Assets/picture_заглушка.png";
                im.Source = new Bitmap(fileName);
            }
           
        }
    }
}

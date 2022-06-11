using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuyTickets.xaml
    /// </summary>
    public partial class BuyTickets : Page
    {
        List<Flight> flights;
        public BuyTickets(Airport outAirport , Airport InAirport)
        {
            InitializeComponent();
            flights = Skyline_DBEntities.GetContext().Flight.ToList();
            
            foreach(Flight flight in flights)
            {
                double FlyTime = Math.Sqrt(Math.Pow(Double.Parse(InAirport.CoordinatesX.Replace('.', ',')) - Double.Parse(outAirport.CoordinatesX.Replace('.', ',')), 2) +
                                           Math.Pow(Double.Parse(InAirport.CoordinatesY.Replace('.', ',')) - Double.Parse(outAirport.CoordinatesY.Replace('.', ',')), 2));
                flight.boarding_time = flight.departure_time.AddHours(FlyTime); 
            }



            DateList.ItemsSource = flights;
        }

        private void DateList_Selected(object sender, RoutedEventArgs e)
        {
            if ((Flight)DateList.SelectedItem is Flight && DateList.SelectedItems.Count == 1)
            {
                Flight thisF = (Flight)DateList.SelectedItem;

                WrapPanel wrapPanel = new WrapPanel();
                wrapPanel.Orientation = Orientation.Vertical;
                if (thisF.Plane.Number_of_seats < 350)
                {
                    List<WrapPanel> wrapPanels = new List<WrapPanel>();

                    for (int i = 0; i < 3; i++)
                    {
                        wrapPanels.Add(new WrapPanel());

                        for (int a = 0; a < 3; a++)
                        {
                            wrapPanels[a].Children.Add(new WrapPanel
                            {
                                Orientation = Orientation.Vertical,
                                Name = "RadPanel"
                            }) ;
                            
                            for (int b = 0; b <= thisF.Plane.Number_of_seats / 3; b++)
                            {
                                ((WrapPanel)wrapPanels[a].FindName("RadPanel")).Children.Add((new CheckBox()));
                            }
                        }
                    }

                }
                else
                {
                    List<WrapPanel> wrapPanels = new List<WrapPanel>();
                    
                    for (int i = 0; i < 2; i++)
                    {
                        wrapPanels.Add(new WrapPanel());
                        for (int a = 0; a < 3; a++)
                        {
                            for (int b = 0; b <= thisF.Plane.Number_of_seats / 3; b++)
                            {
                                wrapPanel.Children.Add(new CheckBox());
                            }
                        }
                    }
                }
                ChairOrietation.Children.Add(wrapPanel);
            }
        }
    }
}

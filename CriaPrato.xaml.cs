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
using System.Windows.Shapes;

namespace JogoGourmet
{
    /// <summary>
    /// Interaction logic for CriaPrato.xaml
    /// </summary>
    public partial class CriaPrato : Window
    {
        public CriaPrato()
        {
            InitializeComponent();
            DefaultMessage.Text = "Qual prato você pensou?";
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResponseCancelaButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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

namespace Zadanie2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RadioButton checkedRadioButton = null;
        private readonly List<RadioButton> radioButtons = new List<RadioButton>();

        public MainWindow()
        {
            InitializeComponent();

            radioButtons.Add(Answer1);
            radioButtons.Add(Answer2);
            radioButtons.Add(Answer3);
            radioButtons.Add(Answer4);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            UncheckRadioButtons();
            SetResultLabelContent();
        }

        private void Answer_Checked(object sender, RoutedEventArgs e)
        {
            checkedRadioButton = sender as RadioButton;

            SetResultLabelContent();
        }

        private void SetResultLabelContent()
        {
            if (checkedRadioButton != null)
            {
                ResultField.Content = checkedRadioButton.Name;
            } 
            else
            {
                ResultField.Content = "";
            }
        }

        private void UncheckRadioButtons()
        {
            if (checkedRadioButton != null)
            {
                checkedRadioButton.IsChecked = false;
                checkedRadioButton = null;
            }
        }

    }
}

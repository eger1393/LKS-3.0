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

namespace LKS_3._0.View
{
    /// <summary>
    /// Логика взаимодействия для ChangeRankWindow.xaml
    /// </summary>
    public partial class ChangeRankWindow : Window
    {
        Student selec_st;
        public ChangeRankWindow(Student SelectStudent)
        {
            InitializeComponent();

            selec_st = SelectStudent;

            labelFIO.Content = selec_st.ToString();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxRank.Text != "")
            {
                selec_st.Rank = comboBoxRank.Text;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите должность!", "Ошибка!");
            }
            
        }
    }
}

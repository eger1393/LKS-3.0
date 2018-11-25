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

            labelFIO.Content = selec_st.Initials;

            comboBoxRank.ItemsSource = Troop.Ranks;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxRank.Text != "")
            {
                if (comboBoxRank.Text == Troop.Ranks[1])
                {
                    Troop select_troop = selec_st.Troop.FirstOrDefault(u => u.SboriTroop == false);
                    Student last_PC = select_troop.PlatoonCommander;
                    if (last_PC != null)
                    {
                        last_PC.Rank = Troop.Ranks[0];
                    }

                    selec_st.Rank = Troop.Ranks[1];
                }
                else
                {
                    selec_st.Rank = comboBoxRank.Text;
                }
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

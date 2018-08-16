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
            if(comboBoxRank.Text != "")
            {
                selec_st.Rank = comboBoxRank.Text;

                if(comboBoxRank.Text == "КВ")
                {
                    selec_st.Troop.FirstOrDefault(u => u.SboriTroop == false).PlatoonCommander = selec_st;
                }


                var tmp = selec_st.Troop.FirstOrDefault(u => u.PlatoonCommander == selec_st);

                if(tmp != null && comboBoxRank.Text != "КВ")
                {
                    tmp.Id_PC = null;
                    tmp.PlatoonCommander = null;
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

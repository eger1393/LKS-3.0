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
    /// Логика взаимодействия для AddNoteStudent.xaml
    /// </summary>
    public partial class AddNoteStudent : Window
    {
        public Student temp_st;
        public AddNoteStudent(Student temp_st)
        {
            InitializeComponent();
            
            this.temp_st = temp_st;

            textNoteBox.Text = this.temp_st.Note;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            temp_st.Note = textNoteBox.Text;
            DialogResult = true;
            Close();
        }
    }
}

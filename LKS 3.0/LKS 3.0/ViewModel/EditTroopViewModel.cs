using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Data.Entity;
using System.Windows;

namespace LKS_3._0.ViewModel
{
    public class EditTroopViewModel : INotifyPropertyChanged
    {
        public ApplicationContext DataBaseTr;
        private Troop selectTroop;
        private Student selectStudent;
        private Prepod selectPrepod;
        private BindingList<Student> selectTroopListStudent;
        BindingList<Troop> troops;

        public EditTroopViewModel(ref ApplicationContext temp_DB, BindingList<Troop> troops)
        {
            DataBaseTr = temp_DB;
            Troops = troops;
        }

        RelayCommand saveChangeCommand;
        RelayCommand addCommand;
        RelayCommand deleteCommand;
        RelayCommand exelentCommand;
        RelayCommand updatePCCommand, updateRPCommand;

        public RelayCommand SaveChangeCommand
        {
            get
            {
                return saveChangeCommand ??
                  (saveChangeCommand = new RelayCommand((selectedItem) =>
                  {
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem == null) return;

                      Troop temp_t = selectedItem as Troop;
                      DataBaseTr.Troops.Local.Insert(temp_t.Id, temp_t);
                      DataBaseTr.SaveChanges();


                  }));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                     
                  }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(selectedItem =>
                    {
                        // если ни одного объекта не выделено, выходим
                        if (selectedItem == null) return;

                        MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить родственника?", "Внимание!", MessageBoxButton.YesNo);
                        if (res.ToString() == "Yes")
                        {
                            Troop temp = selectedItem as Troop;
                            DataBaseTr.Troops.Remove(temp);
                            DataBaseTr.SaveChanges();
                            Troop._count--;
                            Troops = DataBaseTr.Troops.Local.ToBindingList();
                        }
                        else if (res.ToString() == "No")
                        {
                            deleteCommand = null;
                            return;
                        }


                    }, (obj) => Troops.Count() > 0));
            }

        }
        public RelayCommand ExelentCommand
        {
            get
            {
                return exelentCommand ??
                  (exelentCommand = new RelayCommand((selectedItem) =>
                  {
                      

                  }));
            }
        }

        public RelayCommand UpdatePCCommand
        {
            get
            {
                return updatePCCommand ??
                  (updatePCCommand = new RelayCommand((selectedItem) =>
                  {
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem == null) return;

                      Student temp = selectedItem as Student;

                      SelectTroop.Id_PC = temp.Id;
                      SelectTroop.PlatoonCommander = temp;
                


                  }));
            }
        }

        public RelayCommand UpdateRPCommand
        {
            get
            {
                return updateRPCommand ??
                  (updateRPCommand = new RelayCommand((selectedItem) =>
                  {
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem == null) return;

                      Prepod temp = selectedItem as Prepod;

                      SelectTroop.Id_RP = temp.Id;
                      SelectTroop.ResponsiblePrepod = temp;
                 

                  }));
            }
        }
        public BindingList<Troop> Troops
        {
            get
            {
                return troops;
            }

            set
            {
                troops = value;
                OnPropertyChanged();
            }
        }

        public Troop SelectTroop
        {
            get
            {
                return selectTroop;
            }

            set
            {
                selectTroop = value;
                SelectTroopListStudent = Troops.Where(u => u.NumberTroop == value.NumberTroop).First().ListStudents;

                if (value.Id_RP != 0)
                {
                    SelectPrepod = DataBaseTr.Prepods.Where(u => u.Id == value.Id_RP).First();
                }
                else
                {
                    SelectPrepod = null;
                }
                
                OnPropertyChanged();
            }
        }

        public Student SelectStudent
        {
            get
            {
                return selectStudent;
            }

            set
            {
                selectStudent = value;
                OnPropertyChanged();
            }
        }

        public Prepod SelectPrepod
        {
            get
            {
                return selectPrepod;
            }

            set
            {
                selectPrepod = value;
                OnPropertyChanged();
            }
        }

        public BindingList<Student> SelectTroopListStudent
        {
            get
            {
                return selectTroopListStudent;
            }

            set
            {
                selectTroopListStudent = value;
                OnPropertyChanged();
            }
        }

      

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

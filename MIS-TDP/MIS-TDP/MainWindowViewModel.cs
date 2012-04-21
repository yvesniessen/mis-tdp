using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MIS_TDP
{
    public class MainWindowViewModel : ViewModelBase
    {


        #region Constructor
        public MainWindowViewModel()
        {
            this._ButtonCommand = new DelegateCommand(this.ButtonCommandAction);
            loadTestData();
        }

        private void loadTestData()
        {
            items = new ObservableCollection<DataModelExample>();
            items.Add(new DataModelExample { Name = "Title1", Content = "Content1" });
            items.Add(new DataModelExample { Name = "Title2", Content = "Content2" });
            items.Add(new DataModelExample { Name = "Title3", Content = "Content3" });
        }
        #endregion 

        #region properties
        private ObservableCollection<DataModelExample> items;
        public ObservableCollection<DataModelExample> Items
        {
            get
            {
                return Items;
            }
            set
            {
                Items = value;
                OnPropertyChanged("Items");
                Debug.WriteLine("Property: Items");
            }
        }


        private string data = default(string);
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged("Data");
                Debug.WriteLine("Data Property Changed");
            }
        }
        #endregion

        #region ButtonCommands
        private ICommand _ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return _ButtonCommand;
            }
            set
            {
                _ButtonCommand = value;
                Debug.WriteLine("Button Command: " +_ButtonCommand.ToString());
            }
        }
        void ButtonCommandAction(object p)
        {
            Debug.WriteLine("ButtonCommandAction");
        }
        #endregion
    }
}


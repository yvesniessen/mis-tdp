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
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using MIS_TDP.Controller;

namespace MIS_TDP
{

    public abstract class ViewModelBase : INotifyPropertyChanged, ICommand
    {
        public virtual void Initialize(IDictionary<string, string> parameters)
        {
        }

        #region Public Member

        public DatabaseController databaseController = DatabaseController.Instance;

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Expression Blend Design Check
        // Diese Funktion prüft, ob das Design Expression Blend kompatibel ist
        public bool IsDesignTime
        {
            get { return DesignerProperties.IsInDesignTool; }
        }
        #endregion

        #region Icommand Implementation
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                Debug.WriteLine(parameter.ToString());
            }
            else
            {
                //Debug.WriteLine(parameter.ToString());
            }
        }
        #endregion

        protected T GetService<T>() where T : class
        {
            if (typeof(T) == typeof(INavigationService))
            {
                return new SimpleNavigationService() as T;
            }

            return null;
        }
    }
}

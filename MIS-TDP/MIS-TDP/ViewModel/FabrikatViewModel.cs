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
        public class FabrikatViewModel : ViewModelBase
        {
            #region Constructor
            public FabrikatViewModel()
            {
                //@Gruppe: muss das hier hin ich habe KA
                this.item = new TblFabrikat();
            }

            #endregion

            #region properties

            private TblFabrikat item;
            public TblFabrikat Item
            {
                get
                {
                    return item;
                }
                set
                {
                    item = value;
                    OnPropertyChanged("Item");
                    Debug.WriteLine("Property: Item");
                }
            }

            
            #endregion

            #region ButtonCommands

            public void AddFabrikat()
            {
                TblFabrikat neuesFabrikat = new TblFabrikat();
                neuesFabrikat = Item;

                databaseController.AddFabrikat(neuesFabrikat);
            }

            #endregion
        }
    }
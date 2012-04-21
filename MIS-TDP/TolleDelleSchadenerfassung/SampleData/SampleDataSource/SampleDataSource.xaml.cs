//      *********    DIESE DATEI DARF NICHT GEÄNDERT WERDEN     *********
//      Diese Datei wurde von einem Designwerkzeug erstellt. Änderungen
//      dieser Datei können Fehler verursachen.
namespace Expression.Blend.SampleData.SampleDataSource
{
	using System; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class SampleDataSource { }
#else

	public class SampleDataSource : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		public SampleDataSource()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("/TolleDelleSchadenerfassung;component/SampleData/SampleDataSource/SampleDataSource.xaml", System.UriKind.Relative);
				if (System.Windows.Application.GetResourceStream(resourceUri) != null)
				{
					System.Windows.Application.LoadComponent(this, resourceUri);
				}
			}
			catch (System.Exception)
			{
			}
		}

		private Versicherter _Versicherter = new Versicherter();

		public Versicherter Versicherter
		{
			get
			{
				return this._Versicherter;
			}
		}

		private Fabrikat _Fabrikat = new Fabrikat();

		public Fabrikat Fabrikat
		{
			get
			{
				return this._Fabrikat;
			}
		}

		private Versicherung _Versicherung = new Versicherung();

		public Versicherung Versicherung
		{
			get
			{
				return this._Versicherung;
			}
		}

		private Auftrag _Auftrag = new Auftrag();

		public Auftrag Auftrag
		{
			get
			{
				return this._Auftrag;
			}
		}

		private Dateien _Dateien = new Dateien();

		public Dateien Dateien
		{
			get
			{
				return this._Dateien;
			}
		}

		private Kraftfahrzeuge _Kraftfahrzeuge = new Kraftfahrzeuge();

		public Kraftfahrzeuge Kraftfahrzeuge
		{
			get
			{
				return this._Kraftfahrzeuge;
			}
		}
	}

	public class Versicherter : System.Collections.ObjectModel.ObservableCollection<VersicherterItem>
	{ 
	}

	public class VersicherterItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private double _Versichertennummer = 0;

		public double Versichertennummer
		{
			get
			{
				return this._Versichertennummer;
			}

			set
			{
				if (this._Versichertennummer != value)
				{
					this._Versichertennummer = value;
					this.OnPropertyChanged("Versichertennummer");
				}
			}
		}

		private string _Name = string.Empty;

		public string Name
		{
			get
			{
				return this._Name;
			}

			set
			{
				if (this._Name != value)
				{
					this._Name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}

		private string _Vorname = string.Empty;

		public string Vorname
		{
			get
			{
				return this._Vorname;
			}

			set
			{
				if (this._Vorname != value)
				{
					this._Vorname = value;
					this.OnPropertyChanged("Vorname");
				}
			}
		}
	}

	public class Fabrikat : System.Collections.ObjectModel.ObservableCollection<FabrikatItem>
	{ 
	}

	public class FabrikatItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private string _Bezeichnung = string.Empty;

		public string Bezeichnung
		{
			get
			{
				return this._Bezeichnung;
			}

			set
			{
				if (this._Bezeichnung != value)
				{
					this._Bezeichnung = value;
					this.OnPropertyChanged("Bezeichnung");
				}
			}
		}
	}

	public class Versicherung : System.Collections.ObjectModel.ObservableCollection<VersicherungItem>
	{ 
	}

	public class VersicherungItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private double _Versicherungsnummer = 0;

		public double Versicherungsnummer
		{
			get
			{
				return this._Versicherungsnummer;
			}

			set
			{
				if (this._Versicherungsnummer != value)
				{
					this._Versicherungsnummer = value;
					this.OnPropertyChanged("Versicherungsnummer");
				}
			}
		}

		private string _Name = string.Empty;

		public string Name
		{
			get
			{
				return this._Name;
			}

			set
			{
				if (this._Name != value)
				{
					this._Name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}
	}

	public class Auftrag : System.Collections.ObjectModel.ObservableCollection<AuftragItem>
	{ 
	}

	public class AuftragItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private double _Auftragsnummer = 0;

		public double Auftragsnummer
		{
			get
			{
				return this._Auftragsnummer;
			}

			set
			{
				if (this._Auftragsnummer != value)
				{
					this._Auftragsnummer = value;
					this.OnPropertyChanged("Auftragsnummer");
				}
			}
		}

		private string _Datum = string.Empty;

		public string Datum
		{
			get
			{
				return this._Datum;
			}

			set
			{
				if (this._Datum != value)
				{
					this._Datum = value;
					this.OnPropertyChanged("Datum");
				}
			}
		}
	}

	public class Dateien : System.Collections.ObjectModel.ObservableCollection<DateienItem>
	{ 
	}

	public class DateienItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private string _Dateiname = string.Empty;

		public string Dateiname
		{
			get
			{
				return this._Dateiname;
			}

			set
			{
				if (this._Dateiname != value)
				{
					this._Dateiname = value;
					this.OnPropertyChanged("Dateiname");
				}
			}
		}

		private System.Windows.Media.ImageSource _Objekt = null;

		public System.Windows.Media.ImageSource Objekt
		{
			get
			{
				return this._Objekt;
			}

			set
			{
				if (this._Objekt != value)
				{
					this._Objekt = value;
					this.OnPropertyChanged("Objekt");
				}
			}
		}
	}

	public class KraftfahrzeugeItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private string _Kennzeichen = string.Empty;

		public string Kennzeichen
		{
			get
			{
				return this._Kennzeichen;
			}

			set
			{
				if (this._Kennzeichen != value)
				{
					this._Kennzeichen = value;
					this.OnPropertyChanged("Kennzeichen");
				}
			}
		}

		private string _Halter = string.Empty;

		public string Halter
		{
			get
			{
				return this._Halter;
			}

			set
			{
				if (this._Halter != value)
				{
					this._Halter = value;
					this.OnPropertyChanged("Halter");
				}
			}
		}
	}

	public class Kraftfahrzeuge : System.Collections.ObjectModel.ObservableCollection<KraftfahrzeugeItem>
	{ 
	}
#endif
}

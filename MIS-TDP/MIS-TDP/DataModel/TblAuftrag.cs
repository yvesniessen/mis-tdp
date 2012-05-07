//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.IO;
using System.IO.IsolatedStorage;

using Microsoft.Phone.Data.Linq.Mapping;
using Microsoft.Phone.Data.Linq;



[global::System.Data.Linq.Mapping.TableAttribute(Name="tblAuftrag")]
public partial class TblAuftrag : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _AuftragNr;
	
	private System.Nullable<int> _GeschaetzterSchaden;
	
	private string _VersicherterName;
	
	private string _VersicherterVorname;
	
	private System.Nullable<int> _VersicherungNr;
	
	private System.Nullable<System.DateTime> _Datum;
	
	private System.Nullable<int> _KfzFabrikatNr;
	
	private string _KfzKennzeichen;
	
	private System.Nullable<int> _AttachmentNr;
	
	private EntityRef<TblAttachment> _TblAttachment;
	
	private EntityRef<TblFabrikat> _TblFabrikat;
	
	private EntityRef<TblVersicherung> _TblVersicherung;
	
    #region Definitionen der Extensibility-Methode
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAuftragNrChanging(int value);
    partial void OnAuftragNrChanged();
    partial void OnGeschaetzterSchadenChanging(System.Nullable<int> value);
    partial void OnGeschaetzterSchadenChanged();
    partial void OnVersicherterNameChanging(string value);
    partial void OnVersicherterNameChanged();
    partial void OnVersicherterVornameChanging(string value);
    partial void OnVersicherterVornameChanged();
    partial void OnVersicherungNrChanging(System.Nullable<int> value);
    partial void OnVersicherungNrChanged();
    partial void OnDatumChanging(System.Nullable<System.DateTime> value);
    partial void OnDatumChanged();
    partial void OnKfzFabrikatNrChanging(System.Nullable<int> value);
    partial void OnKfzFabrikatNrChanged();
    partial void OnKfzKennzeichenChanging(string value);
    partial void OnKfzKennzeichenChanged();
    partial void OnAttachmentNrChanging(System.Nullable<int> value);
    partial void OnAttachmentNrChanged();
    #endregion
	
	public TblAuftrag()
	{
		this._TblAttachment = default(EntityRef<TblAttachment>);
		this._TblFabrikat = default(EntityRef<TblFabrikat>);
		this._TblVersicherung = default(EntityRef<TblVersicherung>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="auftragNr", Storage="_AuftragNr", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int AuftragNr
	{
		get
		{
			return this._AuftragNr;
		}
		set
		{
			if ((this._AuftragNr != value))
			{
				this.OnAuftragNrChanging(value);
				this.SendPropertyChanging();
				this._AuftragNr = value;
				this.SendPropertyChanged("AuftragNr");
				this.OnAuftragNrChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="geschaetzterSchaden", Storage="_GeschaetzterSchaden", DbType="Int")]
	public System.Nullable<int> GeschaetzterSchaden
	{
		get
		{
			return this._GeschaetzterSchaden;
		}
		set
		{
			if ((this._GeschaetzterSchaden != value))
			{
				this.OnGeschaetzterSchadenChanging(value);
				this.SendPropertyChanging();
				this._GeschaetzterSchaden = value;
				this.SendPropertyChanged("GeschaetzterSchaden");
				this.OnGeschaetzterSchadenChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="versicherterName", Storage="_VersicherterName", DbType="NVarChar(100)")]
	public string VersicherterName
	{
		get
		{
			return this._VersicherterName;
		}
		set
		{
			if ((this._VersicherterName != value))
			{
				this.OnVersicherterNameChanging(value);
				this.SendPropertyChanging();
				this._VersicherterName = value;
				this.SendPropertyChanged("VersicherterName");
				this.OnVersicherterNameChanged();
			}
		}
	}

    public string Versicherter
    {
        get
        {
            if (this.VersicherterVorname != null)
                return this.VersicherterName + ", " + this.VersicherterVorname;
            else if (this.VersicherterName != null)
                return this.VersicherterName;
            else return "KEIN_Name";
        }
    }
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="versicherterVorname", Storage="_VersicherterVorname", DbType="NVarChar(100)")]
	public string VersicherterVorname
	{
		get
		{
			return this._VersicherterVorname;
		}
		set
		{
			if ((this._VersicherterVorname != value))
			{
				this.OnVersicherterVornameChanging(value);
				this.SendPropertyChanging();
				this._VersicherterVorname = value;
				this.SendPropertyChanged("VersicherterVorname");
				this.OnVersicherterVornameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="versicherungNr", Storage="_VersicherungNr", DbType="Int")]
	public System.Nullable<int> VersicherungNr
	{
		get
		{
			return this._VersicherungNr;
		}
		set
		{
			if ((this._VersicherungNr != value))
			{
				this.OnVersicherungNrChanging(value);
				this.SendPropertyChanging();
				this._VersicherungNr = value;
				this.SendPropertyChanged("VersicherungNr");
				this.OnVersicherungNrChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="datum", Storage="_Datum", DbType="DateTime")]
	public System.Nullable<System.DateTime> Datum
	{
		get
		{
			return this._Datum;
		}
		set
		{
			if ((this._Datum != value))
			{
				this.OnDatumChanging(value);
				this.SendPropertyChanging();
				this._Datum = value;
				this.SendPropertyChanged("Datum");
				this.OnDatumChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="kfzFabrikatNr", Storage="_KfzFabrikatNr", DbType="Int")]
	public System.Nullable<int> KfzFabrikatNr
	{
		get
		{
			return this._KfzFabrikatNr;
		}
		set
		{
			if ((this._KfzFabrikatNr != value))
			{
				this.OnKfzFabrikatNrChanging(value);
				this.SendPropertyChanging();
				this._KfzFabrikatNr = value;
				this.SendPropertyChanged("KfzFabrikatNr");
				this.OnKfzFabrikatNrChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="kfzKennzeichen", Storage="_KfzKennzeichen", DbType="NVarChar(100)")]
	public string KfzKennzeichen
	{
		get
		{
			return this._KfzKennzeichen;
		}
		set
		{
			if ((this._KfzKennzeichen != value))
			{
				this.OnKfzKennzeichenChanging(value);
				this.SendPropertyChanging();
				this._KfzKennzeichen = value;
				this.SendPropertyChanged("KfzKennzeichen");
				this.OnKfzKennzeichenChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AttachmentNr", DbType="Int")]
	public System.Nullable<int> AttachmentNr
	{
		get
		{
			return this._AttachmentNr;
		}
		set
		{
			if ((this._AttachmentNr != value))
			{
				if (this._TblAttachment.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnAttachmentNrChanging(value);
				this.SendPropertyChanging();
				this._AttachmentNr = value;
				this.SendPropertyChanged("AttachmentNr");
				this.OnAttachmentNrChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_AttachmentNr", Storage="_TblAttachment", ThisKey="AttachmentNr", OtherKey="AttachmentNr", IsForeignKey=true)]
	public TblAttachment TblAttachment
	{
		get
		{
			return this._TblAttachment.Entity;
		}
		set
		{
			TblAttachment previousValue = this._TblAttachment.Entity;
			if (((previousValue != value) 
						|| (this._TblAttachment.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._TblAttachment.Entity = null;
					//previousValue.TblAuftrag.Remove(this);
				}
				this._TblAttachment.Entity = value;
				if ((value != null))
				{
					//value.TblAuftrag.Add(this);
					this._AttachmentNr = value.AttachmentNr;
				}
				else
				{
					this._AttachmentNr = default(Nullable<int>);
				}
				this.SendPropertyChanged("TblAttachment");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_KFZFabrikatNr", Storage="_TblFabrikat", ThisKey="KfzFabrikatNr", OtherKey="ID", IsForeignKey=true)]
	public TblFabrikat TblFabrikat
	{
		get
		{
			return this._TblFabrikat.Entity;
		}
		set
		{
			TblFabrikat previousValue = this._TblFabrikat.Entity;
			if (((previousValue != value) 
						|| (this._TblFabrikat.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._TblFabrikat.Entity = null;
					//previousValue.TblAuftrag.Remove(this);
				}
				this._TblFabrikat.Entity = value;
				if ((value != null))
				{
					//value.TblAuftrag.Add(this);
					this._KfzFabrikatNr = value.ID;
				}
				else
				{
					this._KfzFabrikatNr = default(Nullable<int>);
				}
				this.SendPropertyChanged("TblFabrikat");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_VersicherungNR", Storage="_TblVersicherung", ThisKey="VersicherungNr", OtherKey="VersicherungNr", IsForeignKey=true)]
	public TblVersicherung TblVersicherung
	{
		get
		{
			return this._TblVersicherung.Entity;
		}
		set
		{
			TblVersicherung previousValue = this._TblVersicherung.Entity;
			if (((previousValue != value) 
						|| (this._TblVersicherung.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._TblVersicherung.Entity = null;
					//previousValue.TblAuftrag.Remove(this);
				}
				this._TblVersicherung.Entity = value;
				if ((value != null))
				{
					//value.TblAuftrag.Add(this);
					this._VersicherungNr = value.VersicherungNr;
				}
				else
				{
					this._VersicherungNr = default(Nullable<int>);
				}
				this.SendPropertyChanged("TblVersicherung");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
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



[global::System.Data.Linq.Mapping.TableAttribute(Name="tblAttachment")]
public partial class TblAttachment : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _AttachmentNr;
	
	private System.Nullable<int> _Typ;
	
	private string _Data;
	
	private System.Nullable<int> _AuftragNr;
	
	private EntityRef<TblAuftrag> _TblAuftrag;
	
    #region Definitionen der Extensibility-Methode
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAttachmentNrChanging(int value);
    partial void OnAttachmentNrChanged();
    partial void OnTypChanging(System.Nullable<int> value);
    partial void OnTypChanged();
    partial void OnDataChanging(string value);
    partial void OnDataChanged();
    partial void OnAuftragNrChanging(System.Nullable<int> value);
    partial void OnAuftragNrChanged();
    #endregion
	
	public TblAttachment()
	{
		this._TblAuftrag = default(EntityRef<TblAuftrag>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="attachmentNr", Storage="_AttachmentNr", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int AttachmentNr
	{
		get
		{
			return this._AttachmentNr;
		}
		set
		{
			if ((this._AttachmentNr != value))
			{
				this.OnAttachmentNrChanging(value);
				this.SendPropertyChanging();
				this._AttachmentNr = value;
				this.SendPropertyChanged("AttachmentNr");
				this.OnAttachmentNrChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="typ", Storage="_Typ", DbType="Int")]
	public System.Nullable<int> Typ
	{
		get
		{
			return this._Typ;
		}
		set
		{
			if ((this._Typ != value))
			{
				this.OnTypChanging(value);
				this.SendPropertyChanging();
				this._Typ = value;
				this.SendPropertyChanged("Typ");
				this.OnTypChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="data", Storage="_Data", DbType="NVarChar(100)")]
	public string Data
	{
		get
		{
			return this._Data;
		}
		set
		{
			if ((this._Data != value))
			{
				this.OnDataChanging(value);
				this.SendPropertyChanging();
				this._Data = value;
				this.SendPropertyChanged("Data");
				this.OnDataChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="auftragNr", Storage="_AuftragNr", DbType="Int")]
	public System.Nullable<int> AuftragNr
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
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_AuftragNr", Storage="_TblAuftrag", ThisKey="AuftragNr", OtherKey="AuftragNr", IsForeignKey=true)]
	public TblAuftrag TblAuftrag
	{
		get
		{
			return this._TblAuftrag.Entity;
		}
		set
		{
			TblAuftrag previousValue = this._TblAuftrag.Entity;
			if (((previousValue != value) 
						|| (this._TblAuftrag.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._TblAuftrag.Entity = null;
					previousValue.TblAttachment.Remove(this);
				}
				this._TblAuftrag.Entity = value;
				if ((value != null))
				{
					value.TblAttachment.Add(this);
					this._AuftragNr = value.AuftragNr;
				}
				else
				{
					this._AuftragNr = default(Nullable<int>);
				}
				this.SendPropertyChanged("TblAuftrag");
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
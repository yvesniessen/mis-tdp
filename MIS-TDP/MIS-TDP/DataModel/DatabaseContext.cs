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



public partial class DatabaseContext : System.Data.Linq.DataContext
{
	
	public bool CreateIfNotExists()
	{
		bool created = false;
		if (!this.DatabaseExists())
		{
			string[] names = this.GetType().Assembly.GetManifestResourceNames();
			string name = names.Where(n => n.EndsWith(FileName)).FirstOrDefault();
			if (name != null)
			{
				using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
				{
					if (resourceStream != null)
					{
						using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
						{
							using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(FileName, FileMode.Create, myIsolatedStorage))
							{
								using (BinaryWriter writer = new BinaryWriter(fileStream))
								{
									long length = resourceStream.Length;
									byte[] buffer = new byte[32];
									int readCount = 0;
									using (BinaryReader reader = new BinaryReader(resourceStream))
									{
										// read file in chunks in order to reduce memory consumption and increase performance
										while (readCount < length)
										{
											int actual = reader.Read(buffer, 0, buffer.Length);
											readCount += actual;
											writer.Write(buffer, 0, actual);
										}
									}
								}
							}
						}
						created = true;
					}
					else
					{
						this.CreateDatabase();
						created = true;
					}
				}
			}
			else
			{
				this.CreateDatabase();
				created = true;
			}
		}
		return created;
	}
	
	public bool LogDebug
	{
		set
		{
			if (value)
			{
				this.Log = new DebugWriter();
			}
		}
	}
	
	public static string ConnectionString = "Data Source=isostore:/Database.sdf";

	public static string ConnectionStringReadOnly = "Data Source=appdata:/Database.sdf;File Mode=Read Only;";

	public static string FileName = "Database.sdf";

	public DatabaseContext(string connectionString) : base(connectionString)
	{
		OnCreated();
	}
	
  #region Definitionen der Extensibility-Methode
  partial void OnCreated();
  partial void InsertTblAttachment(TblAttachment instance);
  partial void UpdateTblAttachment(TblAttachment instance);
  partial void DeleteTblAttachment(TblAttachment instance);
  partial void InsertTblAuftrag(TblAuftrag instance);
  partial void UpdateTblAuftrag(TblAuftrag instance);
  partial void DeleteTblAuftrag(TblAuftrag instance);
  partial void InsertTblFabrikat(TblFabrikat instance);
  partial void UpdateTblFabrikat(TblFabrikat instance);
  partial void DeleteTblFabrikat(TblFabrikat instance);
  partial void InsertTblVersicherung(TblVersicherung instance);
  partial void UpdateTblVersicherung(TblVersicherung instance);
  partial void DeleteTblVersicherung(TblVersicherung instance);
  #endregion
	
	public System.Data.Linq.Table<TblAttachment> TblAttachment
	{
		get
		{
			return this.GetTable<TblAttachment>();
		}
	}
	
	public System.Data.Linq.Table<TblAuftrag> TblAuftrag
	{
		get
		{
			return this.GetTable<TblAuftrag>();
		}
	}
	
	public System.Data.Linq.Table<TblFabrikat> TblFabrikat
	{
		get
		{
			return this.GetTable<TblFabrikat>();
		}
	}
	
	public System.Data.Linq.Table<TblVersicherung> TblVersicherung
	{
		get
		{
			return this.GetTable<TblVersicherung>();
		}
	}
}
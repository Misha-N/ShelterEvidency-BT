﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShelterEvidency.Database
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ShelterDatabase")]
	public partial class ShelterDatabaseLINQDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAnimals(Animals instance);
    partial void UpdateAnimals(Animals instance);
    partial void DeleteAnimals(Animals instance);
    partial void InsertBreeds(Breeds instance);
    partial void UpdateBreeds(Breeds instance);
    partial void DeleteBreeds(Breeds instance);
    partial void InsertCoatTypes(CoatTypes instance);
    partial void UpdateCoatTypes(CoatTypes instance);
    partial void DeleteCoatTypes(CoatTypes instance);
    partial void InsertFurColors(FurColors instance);
    partial void UpdateFurColors(FurColors instance);
    partial void DeleteFurColors(FurColors instance);
    partial void InsertSpecies(Species instance);
    partial void UpdateSpecies(Species instance);
    partial void DeleteSpecies(Species instance);
    partial void InsertStays(Stays instance);
    partial void UpdateStays(Stays instance);
    partial void DeleteStays(Stays instance);
    #endregion
		
		public ShelterDatabaseLINQDataContext() : 
				base(global::ShelterEvidency.Properties.Settings.Default.ShelterDatabaseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ShelterDatabaseLINQDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShelterDatabaseLINQDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShelterDatabaseLINQDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShelterDatabaseLINQDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Animals> Animals
		{
			get
			{
				return this.GetTable<Animals>();
			}
		}
		
		public System.Data.Linq.Table<Breeds> Breeds
		{
			get
			{
				return this.GetTable<Breeds>();
			}
		}
		
		public System.Data.Linq.Table<CoatTypes> CoatTypes
		{
			get
			{
				return this.GetTable<CoatTypes>();
			}
		}
		
		public System.Data.Linq.Table<FurColors> FurColors
		{
			get
			{
				return this.GetTable<FurColors>();
			}
		}
		
		public System.Data.Linq.Table<Species> Species
		{
			get
			{
				return this.GetTable<Species>();
			}
		}
		
		public System.Data.Linq.Table<Stays> Stays
		{
			get
			{
				return this.GetTable<Stays>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Animals")]
	public partial class Animals : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _ChipNumber;
		
		private System.Nullable<System.DateTime> _Birth;
		
		private string _Sex;
		
		private string _Species;
		
		private string _Breed;
		
		private string _CoatType;
		
		private string _FurColor;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnChipNumberChanging(string value);
    partial void OnChipNumberChanged();
    partial void OnBirthChanging(System.Nullable<System.DateTime> value);
    partial void OnBirthChanged();
    partial void OnSexChanging(string value);
    partial void OnSexChanged();
    partial void OnSpeciesChanging(string value);
    partial void OnSpeciesChanged();
    partial void OnBreedChanging(string value);
    partial void OnBreedChanged();
    partial void OnCoatTypeChanging(string value);
    partial void OnCoatTypeChanged();
    partial void OnFurColorChanging(string value);
    partial void OnFurColorChanged();
    #endregion
		
		public Animals()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChipNumber", DbType="NVarChar(50)")]
		public string ChipNumber
		{
			get
			{
				return this._ChipNumber;
			}
			set
			{
				if ((this._ChipNumber != value))
				{
					this.OnChipNumberChanging(value);
					this.SendPropertyChanging();
					this._ChipNumber = value;
					this.SendPropertyChanged("ChipNumber");
					this.OnChipNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birth", DbType="DateTime")]
		public System.Nullable<System.DateTime> Birth
		{
			get
			{
				return this._Birth;
			}
			set
			{
				if ((this._Birth != value))
				{
					this.OnBirthChanging(value);
					this.SendPropertyChanging();
					this._Birth = value;
					this.SendPropertyChanged("Birth");
					this.OnBirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="NChar(10)")]
		public string Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Species", DbType="NVarChar(50)")]
		public string Species
		{
			get
			{
				return this._Species;
			}
			set
			{
				if ((this._Species != value))
				{
					this.OnSpeciesChanging(value);
					this.SendPropertyChanging();
					this._Species = value;
					this.SendPropertyChanged("Species");
					this.OnSpeciesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Breed", DbType="NVarChar(50)")]
		public string Breed
		{
			get
			{
				return this._Breed;
			}
			set
			{
				if ((this._Breed != value))
				{
					this.OnBreedChanging(value);
					this.SendPropertyChanging();
					this._Breed = value;
					this.SendPropertyChanged("Breed");
					this.OnBreedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CoatType", DbType="NChar(10)")]
		public string CoatType
		{
			get
			{
				return this._CoatType;
			}
			set
			{
				if ((this._CoatType != value))
				{
					this.OnCoatTypeChanging(value);
					this.SendPropertyChanging();
					this._CoatType = value;
					this.SendPropertyChanged("CoatType");
					this.OnCoatTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FurColor", DbType="NChar(10)")]
		public string FurColor
		{
			get
			{
				return this._FurColor;
			}
			set
			{
				if ((this._FurColor != value))
				{
					this.OnFurColorChanging(value);
					this.SendPropertyChanging();
					this._FurColor = value;
					this.SendPropertyChanged("FurColor");
					this.OnFurColorChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Breeds")]
	public partial class Breeds : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Breed;
		
		private System.Nullable<int> _Species;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnBreedChanging(string value);
    partial void OnBreedChanged();
    partial void OnSpeciesChanging(System.Nullable<int> value);
    partial void OnSpeciesChanged();
    #endregion
		
		public Breeds()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Breed", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Breed
		{
			get
			{
				return this._Breed;
			}
			set
			{
				if ((this._Breed != value))
				{
					this.OnBreedChanging(value);
					this.SendPropertyChanging();
					this._Breed = value;
					this.SendPropertyChanged("Breed");
					this.OnBreedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Species", DbType="Int")]
		public System.Nullable<int> Species
		{
			get
			{
				return this._Species;
			}
			set
			{
				if ((this._Species != value))
				{
					this.OnSpeciesChanging(value);
					this.SendPropertyChanging();
					this._Species = value;
					this.SendPropertyChanged("Species");
					this.OnSpeciesChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CoatTypes")]
	public partial class CoatTypes : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _CoatType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCoatTypeChanging(string value);
    partial void OnCoatTypeChanged();
    #endregion
		
		public CoatTypes()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CoatType", DbType="NVarChar(50)")]
		public string CoatType
		{
			get
			{
				return this._CoatType;
			}
			set
			{
				if ((this._CoatType != value))
				{
					this.OnCoatTypeChanging(value);
					this.SendPropertyChanging();
					this._CoatType = value;
					this.SendPropertyChanged("CoatType");
					this.OnCoatTypeChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FurColors")]
	public partial class FurColors : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FurColor;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFurColorChanging(string value);
    partial void OnFurColorChanged();
    #endregion
		
		public FurColors()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FurColor", DbType="NVarChar(50)")]
		public string FurColor
		{
			get
			{
				return this._FurColor;
			}
			set
			{
				if ((this._FurColor != value))
				{
					this.OnFurColorChanging(value);
					this.SendPropertyChanging();
					this._FurColor = value;
					this.SendPropertyChanged("FurColor");
					this.OnFurColorChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Species")]
	public partial class Species : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Species()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Stays")]
	public partial class Stays : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<System.DateTime> _Start;
		
		private System.Nullable<System.DateTime> _Finish;
		
		private System.Nullable<int> _Animal;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnStartChanging(System.Nullable<System.DateTime> value);
    partial void OnStartChanged();
    partial void OnFinishChanging(System.Nullable<System.DateTime> value);
    partial void OnFinishChanged();
    partial void OnAnimalChanging(System.Nullable<int> value);
    partial void OnAnimalChanged();
    #endregion
		
		public Stays()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Start", DbType="DateTime")]
		public System.Nullable<System.DateTime> Start
		{
			get
			{
				return this._Start;
			}
			set
			{
				if ((this._Start != value))
				{
					this.OnStartChanging(value);
					this.SendPropertyChanging();
					this._Start = value;
					this.SendPropertyChanged("Start");
					this.OnStartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Finish", DbType="DateTime")]
		public System.Nullable<System.DateTime> Finish
		{
			get
			{
				return this._Finish;
			}
			set
			{
				if ((this._Finish != value))
				{
					this.OnFinishChanging(value);
					this.SendPropertyChanging();
					this._Finish = value;
					this.SendPropertyChanged("Finish");
					this.OnFinishChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Animal", DbType="Int")]
		public System.Nullable<int> Animal
		{
			get
			{
				return this._Animal;
			}
			set
			{
				if ((this._Animal != value))
				{
					this.OnAnimalChanging(value);
					this.SendPropertyChanging();
					this._Animal = value;
					this.SendPropertyChanged("Animal");
					this.OnAnimalChanged();
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
}
#pragma warning restore 1591

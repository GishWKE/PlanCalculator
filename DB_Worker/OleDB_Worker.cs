namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.OleDb;
	using System.Linq;

	using BaseComponents;

	public class OleDB_Worker : IDisposable
	{
		private OleDbCommand command;
		private string fileName = string.Empty;
		public string DataSource
		{
			get => fileName;
			set
			{
				fileName = value;
				command?.Connection?.Close ( );
				command?.Connection?.Dispose ( );
				command?.Dispose ( );
				command = null;
				if ( !value.IsEmpty ( ) )
				{
					command = new OleDbCommand
					{
						Connection = new OleDbConnection ( ConnectionString )
					};
				}
			}
		}
		public string ConnectionString
		{
			get
			{
				try
				{
					if ( DataSource.IsEmpty ( ) )
					{
						throw new Exception ( "Не задано имя файла с БД" );
					}

					return new OleDbConnectionStringBuilder
					{
						DataSource = DataSource,
						Provider = DBProviders.Provider
					}.ConnectionString;
				}
				catch
				{
					throw;
				}
			}
		}
		public DataTable GetTable ( string sql )
		{
			if ( command == null || command.Connection == null )
			{
				throw new Exception ( "Ошибка при создании подключения к БД" );
			}
			var dt = new DataTable ( );
			command.CommandText = sql;
			command.Connection.Open ( );
			using ( var reader = command.ExecuteReader ( ) )
			{
				dt.Load ( reader );
			}
			command.Connection.Close ( );
			command.CommandText = string.Empty;
			return dt.Copy ( );
		}
		public object GetValue ( string sql )
		{
			if ( command == null || command.Connection == null )
			{
				throw new Exception ( "Ошибка при создании подключения к БД" );
			}
			command.CommandText = sql;
			command.Connection.Open ( );
			var dt = command.ExecuteScalar ( );
			command.Connection.Close ( );
			command.CommandText = string.Empty;
			return dt;
		}
		public object GetValue ( string sql, List<OleDbParameter> parameters )
		{
			if ( command == null || command.Connection == null )
			{
				throw new Exception ( "Ошибка при создании подключения к БД" );
			}
			command.CommandText = sql;
			command.Parameters.AddRange ( parameters.ToArray ( ) );
			command.Connection.Open ( );
			var dt = command.ExecuteScalar ( );
			command.Connection.Close ( );
			command.CommandText = string.Empty;
			command.Parameters.Clear ( );
			return dt;
		}
		public object GetValue ( string sql, (string name, object value) parameter ) => GetValue ( sql, new List<OleDbParameter> { CreateParameter ( parameter.name, parameter.value ) } );
		public object GetValue ( string sql, List<(string name, object value)> parameters ) => GetValue ( sql, CreateParameter ( parameters ) );
		public void ExecuteQuery ( string sql )
		{
			if ( command == null || command.Connection == null )
			{
				throw new Exception ( "Ошибка при создании подключения к БД" );
			}
			command.CommandText = sql;
			command.Connection.Open ( );
			command.ExecuteNonQuery ( );
			command.Connection.Close ( );
			command.CommandText = string.Empty;
		}
		public void ExecuteQuery ( string sql, List<OleDbParameter> parameters )
		{
			if ( command == null || command.Connection == null )
			{
				throw new Exception ( "Ошибка при создании подключения к БД" );
			}
			command.CommandText = sql;
			command.Parameters.AddRange ( parameters.ToArray ( ) );
			command.Connection.Open ( );
			command.ExecuteNonQuery ( );
			command.Connection.Close ( );
			command.CommandText = string.Empty;
			command.Parameters.Clear ( );
		}
		public void ExecuteQuery ( string sql, (string name, object value) parameter ) => ExecuteQuery ( sql, new List<OleDbParameter> { CreateParameter ( parameter.name, parameter.value ) } );
		public void ExecuteQuery ( string sql, List<(string name, object value)> parameters ) => ExecuteQuery ( sql, CreateParameter ( parameters ) );
		public void Dispose ( )
		{
			command?.Connection?.Close ( );
			command?.Connection?.Dispose ( );
			command?.Dispose ( );
		}
		public OleDbParameter CreateParameter ( string name, object value ) => new OleDbParameter ( name, value );
		public List<OleDbParameter> CreateParameter ( List<(string name, object value)> par )
		{
			/*var ret = new List<OleDbParameter> ( );
			foreach ( var p in par )
			{
				ret.Add ( CreateParameter ( p.name, p.value ) );
			}
			return ret;*/
			return new List<OleDbParameter> ( par.AsParallel ( ).Select ( p => CreateParameter ( p.name, p.value ) ) );
		}
	}
}

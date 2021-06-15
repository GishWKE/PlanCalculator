namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Data;
	using System.Data.OleDb;
	using System.Data.SqlClient;
	using System.Windows.Forms;
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
			return dt;
		}
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
		}
		public void ExecuteQuery ( string sql, List<OleDbParameter> parameters )
		{
			if ( command == null || command.Connection == null )
			{
				throw new Exception ( "Ошибка при создании подключения к БД" );
			}
			command.CommandText = sql;
			var tmp = parameters.AsParallel ( ).Select ( p => command.Parameters.Add ( p ) ).Count ( );
			command.Connection.Open ( );
			command.ExecuteNonQuery ( );
			command.Connection.Close ( );
		}

		public void Dispose ( )
		{
			command?.Connection?.Close ( );
			command?.Connection?.Dispose ( );
			command?.Dispose ( );
		}
	}
}

namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using System.Linq;

	using BaseComponents;

	public class SQL_DB_Worker
	{
		private SqlCommand command;
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
					command = new SqlCommand
					{
						Connection = new SqlConnection ( ConnectionString )
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

					return new SqlConnectionStringBuilder
					{
						DataSource = DataSource
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
		public void ExecuteQuery ( string sql, List<SqlParameter> parameters)
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
	}
}

namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.OleDb;
	using System.IO;
	using System.Linq;
	using Resource;
	using Resource.Properties;
	using BaseComponents;

	public class OleDB_Worker : IDisposable
	{
		private OleDbCommand command = null;
		private string fileName = null;
		public string DataSource
		{
			get => fileName;
			set
			{
				if ( value.IsEmpty ( ) )
				{
					CloseAndClear ( );
					return;
				}
				if ( fileName.IsPathEquals ( value ) )
				{
					return;
				}

				CloseAndClear ( );
				if ( File.Exists ( value ) )
				{
					fileName = value;
					command = new OleDbCommand
					{
						Connection = new OleDbConnection ( ConnectionString )
					};
					if ( command == null || command.Connection == null )
					{
						throw new Exception ( DB.Connection_create_error );
					}
				}
			}
		}
		public string ConnectionString
		{
			get
			{
				try
				{
					return DataSource.IsEmpty ( )
                        ?                     throw new Exception ( DB.No_filename )
						: new OleDbConnectionStringBuilder
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
			command.CommandText = sql;
			command.Connection.Open ( );
			var dt = new DataTable ( );
			using ( var reader = command.ExecuteReader ( ) )
			{
				dt.Load ( reader );
			}
			Close ( );
			return dt.Copy ( );
		}
		#region GetValue functions
		public object GetValue ( string sql, List<OleDbParameter> parameters = null )
		{
			command.CommandText = sql;
			if ( parameters != null )
			{
				command.Parameters.AddRange ( parameters.ToArray ( ) );
			}

			command.Connection.Open ( );
			var value = command.ExecuteScalar ( );
			Close ( );
			return value;
		}
		public object GetValue ( string sql, OleDbParameter parameter ) => GetValue ( sql, new List<OleDbParameter> { parameter } );
		public object GetValue ( string sql, (string name, object value) parameter ) => GetValue ( sql, CreateParameter ( parameter ) );
		public object GetValue ( string sql, List<(string name, object value)> parameters ) => GetValue ( sql, CreateParameter ( parameters ) );
		#endregion
		#region ExecuteQuery functions
		public void ExecuteQuery ( string sql, List<OleDbParameter> parameters = null )
		{
			command.CommandText = sql;
			if ( parameters != null )
			{
				command.Parameters.AddRange ( parameters.ToArray ( ) );
			}

			command.Connection.Open ( );
			command.ExecuteNonQuery ( );
			Close ( );
		}
		public void ExecuteQuery ( string sql, OleDbParameter parameter ) => ExecuteQuery ( sql, new List<OleDbParameter> { parameter } );
		public void ExecuteQuery ( string sql, (string name, object value) parameter ) => ExecuteQuery ( sql, CreateParameter ( parameter ) );
		public void ExecuteQuery ( string sql, List<(string name, object value)> parameters ) => ExecuteQuery ( sql, CreateParameter ( parameters ) );
		#endregion
		#region Create Parameters Lists
		public OleDbParameter CreateParameter ( string name, object value ) => new OleDbParameter ( name, value );
		public OleDbParameter CreateParameter ( (string name, object value) par ) => CreateParameter ( par.name, par.value );
		public List<OleDbParameter> CreateParameter ( List<(string name, object value)> par ) => new List<OleDbParameter> ( par.AsParallel ( ).Select ( p => CreateParameter ( p ) ) );
		#endregion
		public void Dispose ( ) => CloseAndClear ( );
		private void CloseAndClear ( )
		{
			Close ( );
			command?.Connection?.Dispose ( );
			command?.Dispose ( );
			command = null;
			fileName = null;
		}
		private void Close ( )
		{
			command?.Connection?.Close ( );
			command?.CommandText?.Clear ( );
			command?.Parameters?.Clear ( );
		}
	}
}

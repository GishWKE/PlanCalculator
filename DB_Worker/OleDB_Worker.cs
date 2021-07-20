namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.OleDb;
	using System.IO;

	using BaseComponents;

	using Resource.Properties;

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
				fileName = new FileInfo ( value ).FullName;
				try
				{
					command = new OleDbCommand
					{
						Connection = new OleDbConnection ( ConnectionString )
					};
					if ( command == null || command.Connection == null )
					{
						throw new Exception ( DB.Connection_create_error );
					}
				}
				catch
				{
					CloseAndClear ( );
					throw;
				}
			}
		}
		public string ConnectionString
		{
			get
			{
				try
				{
					return DataSource.IsEmpty ( ) ?
						throw new Exception ( DB.No_filename ) :
						new OleDbConnectionStringBuilder
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
				return null;
			}
			command.CommandText = sql.Replace ( Environment.NewLine, " " );
			command.Connection.Open ( );
			var dt = new DataTable ( );
			using ( var reader = command.ExecuteReader ( ) )
			{
				dt.Load ( reader );
			}
			Close ( );
			return dt;
		}
		#region GetValue functions
		public object GetValue ( string sql )
		{
			if ( command == null || command.Connection == null )
			{
				return null;
			}

			command.CommandText = sql.Replace ( Environment.NewLine, " " );
			command.Connection.Open ( );
			var ret = command.ExecuteScalar ( );
			Close ( );
			return ret;
		}
		public object GetValue ( string sql, string name, object value )
		{
			if ( command == null || command.Connection == null )
			{
				return null;
			}

			AddParameter ( name, value );
			return GetValue ( sql );
		}
		public object GetValue ( string sql, (string name, object value) par )
		{
			if ( command == null || command.Connection == null )
			{
				return null;
			}

			AddParameter ( par );
			return GetValue ( sql );
		}
		public object GetValue ( string sql, IEnumerable<(string name, object value)> par )
		{
			if ( command == null || command.Connection == null )
			{
				return null;
			}

			AddParameter ( par );
			return GetValue ( sql );
		}
		public object GetValue ( string sql, Dictionary<string, object> par )
		{
			if ( command == null || command.Connection == null )
			{
				return null;
			}

			AddParameter ( par );
			return GetValue ( sql );
		}
		#endregion
		#region ExecuteQuery functions
		public void ExecuteQuery ( string sql )
		{
			if ( command == null || command.Connection == null )
			{
				return;
			}

			command.CommandText = sql.Replace ( Environment.NewLine, " " );
			command.Connection.Open ( );
			command.ExecuteNonQuery ( );
			Close ( );
		}
		public void ExecuteQuery ( string sql, string name, object value )
		{
			if ( command == null || command.Connection == null )
			{
				return;
			}

			AddParameter ( name, value );
			ExecuteQuery ( sql );
		}
		public void ExecuteQuery ( string sql, (string name, object value) par )
		{
			if ( command == null || command.Connection == null )
			{
				return;
			}

			AddParameter ( par );
			ExecuteQuery ( sql );
		}
		public void ExecuteQuery ( string sql, IEnumerable<(string name, object value)> par )
		{
			if ( command == null || command.Connection == null )
			{
				return;
			}

			AddParameter ( par );
			ExecuteQuery ( sql );
		}
		public void ExecuteQuery ( string sql, Dictionary<string, object> par )
		{
			if ( command == null || command.Connection == null )
			{
				return;
			}

			AddParameter ( par );
			ExecuteQuery ( sql );
		}
		#endregion
		#region Create Parameters Lists
		public void AddParameter ( string name, object value ) => command.Parameters.AddWithValue ( name, value );
		public void AddParameter ( (string name, object value) par ) => AddParameter ( par.name, par.value );
		public void AddParameter ( IEnumerable<(string name, object value)> par )
		{
			foreach ( var p in par )
			{
				AddParameter ( p );
			}
		}
		public void AddParameter ( Dictionary<string, object> par )
		{
			foreach ( var k in par.Keys )
			{
				AddParameter ( k, par [ k ] );
			}
		}
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

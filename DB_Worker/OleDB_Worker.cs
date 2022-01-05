﻿/*
  Copyright © 2021 Antipov Roman (https://github.com/GishWKE), Tsys' Alexandr (https://github.com/AlexTsys256)


   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Data.OleDb;
	using System.IO;

	using BaseComponents;

	using Resource.Properties;

	public class OleDB_Worker : I_DB_Handler<OleDbCommand>
	{
		public OleDbCommand command
		{
			get; set;
		}
		private FileInfo fileName = null;
		[DefaultValue ( "" )]
		public FileInfo DataSource
		{
			get => fileName;
			set
			{
				if ( value == null )
				{
					return;
				}
				if ( !value.Exists )
				{
					CloseAndClear ( );
					return;
				}
				if ( fileName.IsPathEquals ( value ) )
				{
					return;
				}

				CloseAndClear ( );
				fileName = value;
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
		[DefaultValue ( "" )]
		public string ConnectionString
		{
			get
			{
				try
				{
					if ( !DataSource.Exists )
					{
						throw new Exception ( DB.No_filename );
					}
					return new OleDbConnectionStringBuilder
					{
						DataSource = DataSource.FullName,
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

/*
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
	using System.Data;

	public class DB_Worker : I_DB_Worker
	{
		private static DB_Worker instance;
		public static DB_Worker Instance
		{
			get
			{
				if ( instance == null )
				{
					instance = new DB_Worker ( );
				}
				return instance;
			}
		}
		private DB_Worker ( ) => sql = new ODBC_Worker ( );

		private readonly ODBC_Worker sql;
		public string FileName
		{
			get => sql.DataSource;
			set => sql.DataSource = value;
		}

		public void Dispose ( ) => sql.Dispose ( );
		public DataTable GetTable ( string sql ) => this.sql.GetTable ( sql );
		public object GetValue ( string sql ) => this.sql.GetValue ( sql );
		public object GetValue ( string sql, string name, object value ) => this.sql.GetValue ( sql, name, value );
		public object GetValue ( string sql, (string name, object value) par ) => this.sql.GetValue ( sql, par );
		public object GetValue ( string sql, IEnumerable<(string name, object value)> par ) => this.sql.GetValue ( sql, par );
		public object GetValue ( string sql, Dictionary<string, object> par ) => this.sql.GetValue ( sql, par );
		public void ExecuteQuery ( string sql ) => this.sql.ExecuteQuery ( sql );
		public void ExecuteQuery ( string sql, string name, object value ) => this.sql.ExecuteQuery ( sql, name, value );
		public void ExecuteQuery ( string sql, (string name, object value) par ) => this.sql.ExecuteQuery ( sql, par );
		public void ExecuteQuery ( string sql, IEnumerable<(string name, object value)> par ) => this.sql.ExecuteQuery ( sql, par );
		public void ExecuteQuery ( string sql, Dictionary<string, object> par ) => this.sql.ExecuteQuery ( sql, par );
		public void AddParameter ( string name, object value ) => sql.AddParameter ( name, value );
		public void AddParameter ( (string name, object value) par ) => sql.AddParameter ( par );
		public void AddParameter ( IEnumerable<(string name, object value)> par ) => sql.AddParameter ( par );
		public void AddParameter ( Dictionary<string, object> par ) => sql.AddParameter ( par );
	}
}

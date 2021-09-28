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
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public interface I_DB_Worker : IDisposable
	{
		DataTable GetTable ( string sql );
		#region GetValue functions
		object GetValue ( string sql );
		object GetValue ( string sql, string name, object value );
		object GetValue ( string sql, (string name, object value) par );
		object GetValue ( string sql, IEnumerable<(string name, object value)> par );
		object GetValue ( string sql, Dictionary<string, object> par );
		#endregion
		#region ExecuteQuery functions
		void ExecuteQuery ( string sql );
		void ExecuteQuery ( string sql, string name, object value );
		void ExecuteQuery ( string sql, (string name, object value) par );
		void ExecuteQuery ( string sql, IEnumerable<(string name, object value)> par );
		void ExecuteQuery ( string sql, Dictionary<string, object> par );
		#endregion
		#region Create Parameters Lists
		void AddParameter ( string name, object value );
		void AddParameter ( (string name, object value) par );
		void AddParameter ( IEnumerable<(string name, object value)> par );
		void AddParameter ( Dictionary<string, object> par );
		#endregion
	}
}

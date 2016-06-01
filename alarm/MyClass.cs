using System;
using System.Linq;

namespace alarm
{
	public class MyClass : Realms.RealmObject
	{
		[Realms.ObjectId]
		public Int64 Id { get; set; }
		// [Realms.Indexed]
		public string Name { get; set; }

		public static void Insert(Int64 id, string name)
		{
			var realm = Realms.Realm.GetInstance ();
			realm.Write (() => {
				var obj = realm.CreateObject<MyClass>();
				obj.Id = id;
				obj.Name = name;
			});
		}

		public static MyClass FindById(Int64 id)
		{
			var realm = Realms.Realm.GetInstance ();


			return realm.All<MyClass>().Where(d => d.Id == id).First();

		}

		public static void Init()
		{
			Insert (0, "todo");
			Insert (1, "todo");
			Insert (1, "todo");
		}


		public static async System.Threading.Tasks.Task<string> todo(string u)
		{

			System.Diagnostics.Debug.WriteLine ("todo call");

			using (var client = new System.Net.Http.HttpClient ()) {
				return await client.GetStringAsync (u);
			}

		}
	}
}


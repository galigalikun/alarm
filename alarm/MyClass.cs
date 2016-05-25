using System;
using System.Linq;

namespace alarm
{
	public class MyClass : Realms.RealmObject
	{
		[ObjectId]
		public Int64 Id { get; set; }
		// [Indexed]
		public string Name { get; set; }

		public static void insert()
		{
			var realm = Realms.Realm.GetInstance ();
			realm.Write (() => {
				var obj = realm.CreateObject<MyClass>();
				obj.Id = 0;
				obj.Name = "todo";
			});
		}

		public static MyClass findById(Int64 id)
		{
			var realm = Realms.Realm.GetInstance ();


			return realm.All<MyClass>().Where(d => d.Id == id).First();

		}

		public static void init()
		{
			
		}
	}
}


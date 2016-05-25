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

		public static void insert(Int64 id, string name)
		{
			var realm = Realms.Realm.GetInstance ();
			realm.Write (() => {
				var obj = realm.CreateObject<MyClass>();
				obj.Id = id;
				obj.Name = name;
			});
		}

		public static MyClass findById(Int64 id)
		{
			var realm = Realms.Realm.GetInstance ();


			return realm.All<MyClass>().Where(d => d.Id == id).First();

		}

		public static void init()
		{
			insert (0, "todo");
			insert (1, "todo");
			insert (1, "todo");
		}
	}
}


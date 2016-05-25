using System;

namespace alarm
{
	public class Rss : Realms.RealmObject
	{
		[Realms.ObjectId]
		public string Key { get; set; }
		public string Url { get; set; }



		static void init()
		{
			var realm = Realms.Realm.GetInstance ();

			using (var transaction = realm.BeginWrite ()) {
				var news = realm.CreateObject<Rss> ();
				news.Key = "news";
				news.Url = "http://todo";

				var train = realm.CreateObject<Rss> ();
				train.Key = "train";
				train.Url = "http://todo";

				transaction.Commit ();
			}
		}
	}
}


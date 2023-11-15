using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoApp
{
	public  class MongoRepo
	{
		private readonly MongoClient Mongoclient;
		private readonly IMongoDatabase Db;
		private readonly IMongoCollection<NbbBase> nbbCollection;

		public MongoRepo(string cnst)
        {
			//Création du client mongoClient
			 Mongoclient = new MongoClient(cnst);
			//Chercher la db pour travailler --> PLayzone
			 Db = Mongoclient.GetDatabase("PLayzone");
			//Chercher ma collection
			 nbbCollection = Db.GetCollection<NbbBase>("NBB");
		}
		public      NbbBase Get(string num)
		{
			NbbBase info = nbbCollection.Find((e) => e.cbe == num).FirstOrDefault();

			return info;

		}
		public async Task<bool> Insert(NbbBase? data)
		{

			try
			{
				//Y'a plus qu'à inserer
				await nbbCollection.InsertOneAsync(data);
				Console.WriteLine($"Insertion effectuée : {data.cbe}");
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Insertion non effectuée : {data.cbe} - {ex.Message}");
				return false;
			}
				 
		}
	 
	}
}

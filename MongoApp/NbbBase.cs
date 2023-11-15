using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoApp
{
	public  class NbbBase
	{
		public ObjectId Id { get; set; }
		public string language { get; set; }
		public string cbe { get; set; }
		public string name { get; set; }
		public string streetName { get; set; }
		public string streetNumber { get; set; }
		public string boxNumber { get; set; }
		public string postalCode { get; set; }
		public string town { get; set; }
		public string country { get; set; }
		public string countryCode { get; set; }
		public string email { get; set; }
		public string website { get; set; }
		public string legalForm { get; set; }
		public string legalFormCode { get; set; }
		public string legalSituation { get; set; }
		public string legalSituationCode { get; set; }
		public string languageRegime { get; set; }
		public string addressStructOffInfo { get; set; }
		public string juridicalFormStructOffInfo { get; set; }
	}
}

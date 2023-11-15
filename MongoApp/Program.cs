// See https://aka.ms/new-console-template for more information
using MongoApp;
using MongoDB.Driver;
using System.Text.Json;
 Console.WriteLine("Hello, World!");

List<string> CompanyNum = new List<string>() {
"0446.687.968",
"0463.261.607",
"0427.845.521",
"0453.048.792",
"0446.178.224",
"0421.078.582",
"0435.477.441",
"0401.397.777",
"0466.959.780",
"0407.704.262",
"0429.321.010",
"0343.412.025",
"0450.810.864",
"0457.082.311",
"0405.850.968",
"0420.826.283",
"0459.560.660",
"0430.123.635",
"0408.441.264",
"0442.596.845",
"0416.461.184",
"0466.169.132",
"0464.376.018",
"0860.273.697",
"0428.884.411",
"0844.471.310",
"0420.363.257",
"0415.777.137",
"0402.557.522",
"0404.364.294",
"0475.984.146",
"0452.846.181",
"0426.481.680",
"0402.035.009",
"0656.932.597",
"0422.875.458",
"0862.453.625",
"0414.506.437",
"0462.001.496",
"0432.759.956",
"0406.052.985",
"0404.379.340",
"0716.706.967",
"0716.706.968",
"0411.090.057",
"0405.141.072",
"0428.192.543",
"0472.226.880",
"0439.218.473",
"0441.544.988",
"0887.579.494",
"0861.101.761",
"0429.538.467",
"0418.560.146",
"0430.242.114",
"0861.579.635",
"0417.139.293",
"0455.515.661",
"0422.874.072",
"0425.087.949",
"0464.796.185",
"0461.559.652",
"0428.353.879",
"0461.534.413",
"0418.148.588",
"0451.821.842",
"0405.681.516",
"0464.933.272",
"0833.811.109",
"0899.865.535",
"0448.057.252",
"0527.920.421",
"0881.140.278",
"0554.697.666",
"0438.004.488",
"0874.244.271",
"0425.607.690",
"0606.973.936",
"0899.535.438",
"0435.273.246",
"0467.082.714",
"0424.585.529",
"0414.736.663",
"0458.517.218",
"0431.204.590",
"0633.780.083",
"0449.333.395",
"0418.104.345",
"0426.714.678",
"0454.827.357",
"0464.866.758",
"0412.594.250",
"0465.348.986",
"0441.831.931",
"0435.472.986",
"0472.349.319",
"0422.047.988",
"0433.284.647",

};



MongoRepo repo = new MongoRepo(@"mongodb://localhost:27017");
foreach (string item in CompanyNum)
{//se connecter à l'api

	string NumeroNettoye = item.Replace(".", "");
	using (HttpClient client = new HttpClient())
	{
		NbbBase local = repo.Get(NumeroNettoye);
		if (local==default(NbbBase))
		{
			// récupérer les données
			var reponse = await client.GetAsync($"https://consult.cbso.nbb.be/api/rs-consult/companies/{NumeroNettoye}/FR");
			if (reponse.IsSuccessStatusCode)
			{
				string json = await reponse.Content.ReadAsStringAsync();
				NbbBase data = JsonSerializer.Deserialize<NbbBase>(json);
				// envoyer tout dans mongo
				bool rep = await repo.Insert(data);
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Impossible de récupérer les données pour : {NumeroNettoye}");
				Console.ForegroundColor = ConsoleColor.White;
			} 
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"Données présentes pour : {NumeroNettoye}");
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
	
}


Console.ReadLine();

 


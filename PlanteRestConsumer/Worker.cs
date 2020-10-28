using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlanteShopService;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace PlanteRestConsumer
{
    class Worker        
    {
        private const string BaseURI = "https://localhost:44390/api/plants";

        public Worker()
        {
            
        }


        public async void Start()
        {
            IList<Plante> plantList =  GetAllPlants().Result;
            foreach (Plante plante in plantList)
            {
                Console.WriteLine(plante.ToString());
            }

            Plante p1 =  GetOnePlant(2).Result;
            Console.WriteLine(p1.ToString());

        }

        public async Task<IList<Plante>> GetAllPlants()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(BaseURI);
                IList<Plante> cList = JsonConvert.DeserializeObject<IList<Plante>>(content);
                return cList;
            }
        }


        public async Task<Plante> GetOnePlant(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(BaseURI +  $"/{id}");
                Plante plant = JsonConvert.DeserializeObject<Plante>(content);
                return plant;
            }
        }
    }
}

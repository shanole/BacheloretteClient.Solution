using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace BacheloretteClient.Models
{
    public class Contestant
    {
        public int ContestantId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public string Hometown { get; set; }
        public bool IsEliminated { get; set; } = false;
        public int Season { get; set; }
        public int BacheloretteId { get; set; }

        public static List<Contestant> GetAll(int bacheloretteId) 
        {
            var getAllResult = ApiHelper.GetAllContestant(bacheloretteId);
            var result = getAllResult.Result;
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Contestant> contenstantsList =JsonConvert.DeserializeObject<List<Contestant>>(jsonResponse.ToString());
            return contenstantsList;
        }
        public static Contestant GetDetails(int id, int bacheloretteId)
        {
            var apiCallTask = ApiHelper.GetContestant(id, bacheloretteId);
            var result = apiCallTask.Result;
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Contestant thisContestant = JsonConvert.DeserializeObject<Contestant>(jsonResponse.ToString());
            // thisContestant.BacheloretteId = bacheloretteId;
            return thisContestant;
        }

        public static void Post(Contestant newContestant)
        {
            string jsonContestant =JsonConvert.SerializeObject(newContestant);
            var apiCallTask = ApiHelper.PostContestant(jsonContestant, newContestant.BacheloretteId);
        }


    }
}


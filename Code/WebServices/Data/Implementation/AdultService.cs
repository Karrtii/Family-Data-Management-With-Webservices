using DNPHandin1.Models;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DNPHandin1.Data.Implementation
{
    public class AdultService : IAdultsService
    {
        private string adultsFile = "adults.json";
        private List<Adult> adults;
        //private FileContext fileContext;

        public AdultService()
        {
            //fileContext = new FileContext();
            if (!File.Exists(adultsFile))
            {
                //Populate
                WriteAdultsToFile();
            }
            else
            {
                string content = File.ReadAllText(adultsFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            //fileContext.Adults.Add(adult);
            //fileContext.SaveChanges();
            WriteAdultsToFile();
            return adult;
        }

        public async Task<IList<Adult>> GetAdults()
        {
            List<Adult> copy = new List<Adult>(adults);
            return copy;
        }

        public async Task RemoveAdult(int id)
        {
            Adult toRemove = adults.First(a => a.Id == id);
            adults.Remove(toRemove);
            //fileContext.Adults.Remove(toRemove);
            //fileContext.SaveChanges();
            WriteAdultsToFile();
        }

        public void WriteAdultsToFile() 
        {
            string productAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultsFile, productAsJson);
        }
    }
}

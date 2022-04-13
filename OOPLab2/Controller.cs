using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace OOPLab2
{
    public class Controller
    {
        public void Serialize(List<Accomodation> accomodations)
        {
            File.WriteAllText("accomodations.json", JsonSerializer.Serialize(accomodations.ConvertAll(model => model.MapModelToDto())));
        }

        public List<Accomodation> Deserialize()
        {
            string json = File.ReadAllText("accomodations.json");
            List<AccomodationDto>? accomodations = JsonSerializer.Deserialize<List<AccomodationDto>>(json);

            List<Accomodation> result = new List<Accomodation>();

            if (accomodations != null)
            {
                accomodations.ForEach(it => { result.Add(it.MapDtoToModel()); });
            }

            return result;
        }
    }
}

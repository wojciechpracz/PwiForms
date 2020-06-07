using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PwiForms.Helpers;
using PwiForms.Models;
using pwiforms2.Data;
using pwiforms2.Models;

namespace PwiForms.Services
{
    public class StationService : IStationService
    {
        private readonly DataContext _context;
        public StationService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Station>> GetStations()
        {
            var stations = new List<Station>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.gios.gov.pl/pjp-api/rest/");

                var response = await client.GetAsync("station/findAll");

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    stations = JsonConvert.DeserializeObject<List<Station>>(res, new StationConverter());
                }
            }
            return stations;
        }

        public IEnumerable<UserStation> GetUserStations(int userId) 
        {
            return _context.UserStations.Where(us => us.UserId == userId).ToList();
        }

        public async Task<IEnumerable<MeasurementPosition>> GetPositions(int stationId)
        {
            var positions = new List<MeasurementPosition>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.gios.gov.pl/pjp-api/rest/");

                string req = String.Format("station/sensors/{0}", stationId);

                var response = await client.GetAsync(req);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    positions = JsonConvert.DeserializeObject<List<MeasurementPosition>>(result);
                }

            }

            return positions;
        }

        public async Task<string> GetMeasuredValue(int sensorId)
        {
            var measuredValues = new ValuesFromSensor();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.gios.gov.pl/pjp-api/rest/");
                string req = String.Format("data/getData/{0}", sensorId);

                var response = await client.GetAsync(req);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    measuredValues = JsonConvert.DeserializeObject<ValuesFromSensor>(result);
                }
            }

            return measuredValues.Values.FirstOrDefault(x => x.Value != "null").Value;
        }

        public async Task<AirIndex> GetAirQualityIndex(int stationId)
        {
            AirIndex index = new AirIndex();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.gios.gov.pl/pjp-api/rest/");
                string req = String.Format("aqindex/getIndex/{0}", stationId);

                var response = await client.GetAsync(req);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    index = JsonConvert.DeserializeObject<AirIndex>(result, new IndexConverter());
                }

            }

            return index;
        }

        public async Task<bool> AddStationForUser(UserStation userStation)
        {
            var userStationFromDb = _context.UserStations
                .FirstOrDefault(us => us.StationId == userStation.StationId && us.UserId == userStation.UserId);

            if(userStationFromDb == null)
            {
                await _context.UserStations.AddAsync(userStation);
                return await _context.SaveChangesAsync() > 0;
            }    

            return false;
        }
    }

}
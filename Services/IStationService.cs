using System.Collections.Generic;
using System.Threading.Tasks;
using PwiForms.Models;
using pwiforms2.Models;

namespace PwiForms.Services
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetStations();
        Task<IEnumerable<MeasurementPosition>> GetPositions(int stationId);
        Task<string> GetMeasuredValue(int sensorId);
        Task<AirIndex> GetAirQualityIndex(int stationId);
        Task<bool> AddStationForUser(UserStation userStation);
        IEnumerable<UserStation> GetUserStations(int userId);

    }
}
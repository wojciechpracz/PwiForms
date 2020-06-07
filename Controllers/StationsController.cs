using System.Linq;
using System.Threading.Tasks;
using PwiForms.Services;
using PwiForms.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PwiForms.ViewModels;

namespace PwiForms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StationsController : ControllerBase
    {
        private readonly IStationService _service;
        public StationsController(IStationService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stations = await _service.GetStations();
            return Ok(stations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPositions(int id)
        {
            var stations = await _service.GetStations();
            var station = stations.FirstOrDefault(s => s.StationId == id);

            var positions = await _service.GetPositions(station.StationId);

            var viewModel = new PositionListViewModel();
            viewModel.StationName = station.StationName;
            viewModel.Positions = positions.ToList();

            var measures = new List<string>();

            foreach (var position in positions)
            {
                var value = await _service.GetMeasuredValue(position.Id);

                if (value == null)
                {
                    value = "Brak danych";
                }

                measures.Add(value);
            }

            viewModel.PositionValuse = measures;

            var airIndex = await _service.GetAirQualityIndex(station.StationId);

            viewModel.AirIndex = airIndex.Value;

            return Ok(viewModel);

        }

    }
}
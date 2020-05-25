using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pwiforms2.Data;
using pwiforms2.Models;

namespace pwiforms2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly DataContext _context;
        public CountryController(DataContext context)
        {
            this._context = context;           
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            return await _context.Countries.ToListAsync();
        }

    }
}
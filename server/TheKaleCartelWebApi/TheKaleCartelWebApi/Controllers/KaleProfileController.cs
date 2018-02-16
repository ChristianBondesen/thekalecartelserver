using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKaleCartelWebApi.DTO.Profile;
using TheKaleCartelWebApi.Models;
using TheKaleCartelWebApi.Repositories.Repository;

namespace TheKaleCartelWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class KaleProfileController : Controller
    {
        private readonly IRepository<KaleProfile> _repo;
        private readonly IMapper _mapper;

        public KaleProfileController(IRepository<KaleProfile> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var profiles = _mapper.Map<IEnumerable<KaleProfileDto>>(_repo.GetAll().OrderBy(p => p.KaleProfileId));

          if (profiles == null)
          {
            return BadRequest();
          }

            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          var profile = await _repo.GetAll().Include(i => i.KaleBeers).Include(i=>i.KaleRecipes).SingleOrDefaultAsync(i=>i.KaleProfileId == id);

          if (profile == null)
          {
          {
            return BadRequest();
          }

            return Ok(profile);
        }
    }
}

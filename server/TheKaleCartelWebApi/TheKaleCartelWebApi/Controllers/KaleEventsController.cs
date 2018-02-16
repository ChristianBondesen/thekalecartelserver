using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKaleCartelWebApi.DTO.Events;
using TheKaleCartelWebApi.Models;
using TheKaleCartelWebApi.Repositories.Repository;

namespace TheKaleCartelWebApi.Controllers
{
  [Produces("application/json")]
  [Route("api/KaleEvents")]
  public class KaleEventsController : Controller
  {
    private readonly IRepository<KaleEvent> _repo;
    private readonly IMapper _mapper;

    public KaleEventsController(IRepository<KaleEvent> repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
      var respone = await _repo.GetAll().Include(i=>i.KaleProfile)
        .Include(i=>i.KaleBeers)
        .Include(i=>i.KaleRecipes)
        .ProjectTo<GetEventDTO>().ToListAsync();

      return Ok(respone);
    }

    [HttpGet("{kaleevent}")]
    public async Task<ActionResult> GetById(int kaleevent)
    {
      var response = await this._repo.GetAll().FirstOrDefaultAsync(i => i.KaleEventId == kaleevent);
      if (response == null)
      {
        return BadRequest("error");
      }
      return Ok(_mapper.Map<GetEventDTO>(response) );
    }

    [HttpPost]
    public ActionResult Post([FromBody] KaleEventPostDto dankmemes)
    {
      if (ModelState.IsValid)
      {
        this._repo.Add(_mapper.Map<KaleEvent>(dankmemes));
        return Created("created", dankmemes);
      }
      else
      {
        return BadRequest("Input not validated");
      }
    }
  }
}

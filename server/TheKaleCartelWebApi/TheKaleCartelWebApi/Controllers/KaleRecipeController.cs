using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheKaleCartelWebApi.DTO.Recipies;
using TheKaleCartelWebApi.Models;
using TheKaleCartelWebApi.Repositories.Repository;

namespace TheKaleCartelWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/KaleRecipe")]
    public class KaleRecipeController : Controller
    {
      private readonly IMapper _mapper;
      private readonly IRepository<KaleRecipe> _repo;

      public KaleRecipeController(IMapper mapper, IRepository<KaleRecipe> repo)
      {
        _mapper = mapper;
        _repo = repo;
      }
      
      [HttpGet]
      public IActionResult Index()
      {
        var recipies = _mapper.Map<IEnumerable<KaleRecipeDto>>(_repo.GetAll());

        if (recipies == null)
        {
          return BadRequest();
        }

        return Ok(recipies);
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetByName(int id)
      {
        var orderedRecipe = await _repo.GetAll().ProjectTo<KaleRecipeDetailsDto>().SingleAsync(i => i.KaleRecipeId == id);

        if (orderedRecipe != null)
        {
          return Ok(orderedRecipe);
        }
        return NotFound(id);
      }

      [HttpPost]
      public IActionResult AddRecipe([FromBody] KaleRecipeDetailsDto recipe)
      {
        if (ModelState.IsValid)
        {
          var newRecipe = _mapper.Map<KaleRecipe>(recipe);
          newRecipe.CreationDate = DateTime.Now;
          _repo.Add(newRecipe);

          return Ok(recipe);
        }
        else
        {
          return BadRequest(recipe);
        }

      }
    }
}

using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

      [HttpGet("name/{name}")]
      public IActionResult GetByName(string name)
      {
        var orderedRecipe = _repo.Get(r => r.Name == name);

        if (orderedRecipe != null)
        {
          var recipe = _mapper.Map<KaleRecipeDetailsDto>(orderedRecipe);
          return Ok(recipe);
        }
        return NotFound(name);
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

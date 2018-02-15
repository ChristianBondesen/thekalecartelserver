using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TheKaleCartelWebApi.DTO.Beer;
using TheKaleCartelWebApi.DTO.Recipies;

namespace TheKaleCartelWebApi.DTO.Events
{
  public class KaleEventPostDto
  {
    public int KaleEventId { get; set; }
    [Required]
    public int KaleProfileId { get; set; }

    [Required]
    public DateTime EventDate { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public IEnumerable<KaleBeerPostDto> KaleBeers { get; set; }
    [Required]
    public IEnumerable<KaleRecipePostDto> KaleRecipes { get; set; }
  }
}

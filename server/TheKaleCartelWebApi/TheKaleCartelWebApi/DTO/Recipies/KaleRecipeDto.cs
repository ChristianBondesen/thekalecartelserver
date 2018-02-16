using System;
using System.ComponentModel.DataAnnotations;

namespace TheKaleCartelWebApi.DTO.Recipies
{
  public class KaleRecipeDto
  {
    public int KaleRecipeId { get; set; }

    [Required] public string Name { get; set; }

    [Required] public double Rating { get; set; }

    public DateTime CreationDate { get; set; }

    public int KaleProfileId { get; set; }
  }
}
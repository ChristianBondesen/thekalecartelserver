using System;
using System.ComponentModel.DataAnnotations;

namespace TheKaleCartelWebApi.DTO.Recipies
{
    public class KaleRecipeDetailsDto
    {
      public int KaleRecipeId { get; set; }

      [Required]
      public string Name { get; set; }

      [Required]
      public int Rating { get; set; }

      [Required]
      public string CourseOfAction { get; set; }

      public DateTime CreationDate { get; set; }

      [Required]
      public int KaleProfileId { get; set; }
      public string PictureUrl { get; set; }
  }
}

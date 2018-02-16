using System;
using System.ComponentModel.DataAnnotations;

namespace TheKaleCartelWebApi.DTO.Beer
{
  public class KaleBeerDetailsDto
  {
    public int KaleBeerId { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Description { get; set; }

    public string PictureUrl { get; set; }

    [Required] public double Rating { get; set; }

    [Required] public double VolPercentage { get; set; }
    public DateTime CreationDate { get; set; }
    public int KaleProfileId { get; set; }
  }
}
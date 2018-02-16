using System.ComponentModel.DataAnnotations;

namespace TheKaleCartelWebApi.DTO.Beer
{
    public class KaleBeerDto
    {
        public int KaleBeerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Rating { get; set; }

    }
}

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CebuaKnows.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Please enter the place.")]
        public string? Place { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please enter the image name.")]
        public IFormFile? ImageName { get; set; }

        public string? ImageFileName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Models.Dtos
{
    public class SentenceToAddDto
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Zdanie nie może być puste")]
        public string OryginalText { get; set; }
        [Required(ErrorMessage = "Tłumaczenie nie może być puste")]
        public string TranslateText { get; set; }
        public int CategoryId { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}

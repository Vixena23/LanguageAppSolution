using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Models.Dtos
{
    public class SentenceDto
    {
        public int Id { get; set; }
        public string OryginalText { get; set; }
        public string TranslateText { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}

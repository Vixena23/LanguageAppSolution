namespace LanguageApp.Api.Entity
{
    public class Sentence
    {
        public int Id { get; set; }
        public string OryginalText { get; set; }
        public string TranslateText { get; set; }
        public int CategoryId { get; set; }
    }
}

namespace LanguageApp.Api.Entity
{
    public class Word
    {
        public int Id { get; set; }
        public string OryginalText { get; set; }
        public string TranslateText { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }
    }
}

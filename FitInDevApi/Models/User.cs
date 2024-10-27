namespace FitInDevApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Lifestyle { get; set; } // Exemplo: "sedentary", "active"
        public string Goals { get; set; }     // Exemplo: "lose weight", "build muscle"
    }
}

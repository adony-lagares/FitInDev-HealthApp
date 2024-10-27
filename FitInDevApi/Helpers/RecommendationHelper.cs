namespace FitInDevApi.Helpers
{
    public static class RecommendationHelper
    {
        public static string GenerateExerciseTip(string lifestyle)
        {
            return lifestyle switch
            {
                "sedentary" => "Levante-se a cada 30 minutos e faça um alongamento rápido.",
                "active" => "Mantenha uma rotina de caminhadas para complementar sua atividade.",
                _ => "Tente incluir exercícios leves ao longo do seu dia."
            };
        }
    }
}

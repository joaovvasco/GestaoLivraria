namespace GestaoLivraria.Communication
{
    public class ErrorResponseJson
    {
        public int code { get; set; } = 400;
        public List<string> messages { get; set; } = new List<string>();

        
    }
}

using GestaoLivraria.Communication;
using GestaoLivraria.Core.Extensions;
using GestaoLivraria.Enumeration;
using System.Linq;

namespace GestaoLivraria.Validation
{
    public class BookValidator
    {
        private static readonly string REQUIRED = "O campo '{0}' é obrigatório!";

        private static readonly string MSG_MUST_BE_GREATER_THAN_ZERO = "O valor do campo '{0}' deve ser maior que 0!";

        private static readonly string MSG_INVALID_VALUE = "O valor do campo '{0}' é inválido!";

        private List<string> list = [];

        public List<string> Validate(BookRequestJson request) 
        {
            list.Clear();

            if (request.Title.IsBlank())
                list.Add(REQUIRED.Replace("{0}", "Title"));

            if (request.Author.IsBlank())
                list.Add(REQUIRED.Replace("{0}", "Author"));

            if (!Enum.IsDefined(typeof(Genre), request.Genre))
                list.Add(MSG_INVALID_VALUE.Replace("{0}", "Genre"));

            if (request.Quantity <= 0)
                list.Add(MSG_MUST_BE_GREATER_THAN_ZERO.Replace("{0}", "Amount"));

            if(request.Price <= 0)
                list.Add(MSG_MUST_BE_GREATER_THAN_ZERO.Replace("{0}", "Price"));

            return list;
        }

    }
}

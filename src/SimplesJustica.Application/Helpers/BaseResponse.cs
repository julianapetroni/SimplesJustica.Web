using System.Collections.Generic;

namespace SimplesJustica.Application.Helpers
{
    public class BaseResponse 
    {
        public StatusCode StatusCode { get; set; }
        public bool Successful { get; set; }
        public List<string> ErroMessages { get; set; }

        public BaseResponse()
        {
            ErroMessages = new List<string>();
        }
    }
}

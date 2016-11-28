using System.Collections.Generic;

namespace TKD.Emailer.Dtos
{
    internal class ResultDTO
    {
        public IList<ErrorDTO> Errors { get; set; }
    }
}

using Candidates.Models.DTO;
using System;
using System.Collections.Generic;

namespace Candidates.Responses
{
    public class Response
    {
        public int PageCount { get; set; }
        public int ItemCount { get; set; }
        public string Message { get; set; }
    }
}

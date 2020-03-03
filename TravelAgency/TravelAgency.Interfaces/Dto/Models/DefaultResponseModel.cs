using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgency.Interfaces.Dto.Models
{
    public class DefaultResponseModel
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }
    }
}

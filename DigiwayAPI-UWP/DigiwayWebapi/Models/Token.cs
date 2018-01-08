using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigiwayWebapi.Models
{
    [NotMapped]
    public class Token
    {
        [NotMapped]
        public string TokenValue { get; set; }
    }
}

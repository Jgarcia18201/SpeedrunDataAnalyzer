using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunDataAnalyzer
{
    public class RunManager
    {
        [Key]
        public int RunID { get; set; }
    }
}

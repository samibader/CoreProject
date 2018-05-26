using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Domain.Entities
{
    public class Language : IEntityBase
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        
    }
}

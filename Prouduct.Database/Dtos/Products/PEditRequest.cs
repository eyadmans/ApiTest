using production.Database.Dtos.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Database.Dtos.Products
{

        public class PEditRequest : AddProuductRequestDto
    {
            public int Id { get; set; }
        }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Requests.Contracts
{
    public class LookupTypeDto
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}

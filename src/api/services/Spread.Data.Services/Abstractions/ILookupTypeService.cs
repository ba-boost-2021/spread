﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Services.Abstractions
{
    public interface ILookupTypeService
    {
        Task<bool> CreateLookupType(NewLookupTypeRequestDto data, CancellationToken cancellationToken);
        Task<LookupTypeDto> LookupTypeGetById(Guid id, CancellationToken cancellationToken);
        Task<bool> LookupTypeDeleteById(Guid id, CancellationToken cancellationToken);
    }

}

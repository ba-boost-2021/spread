﻿using MediatR;
using Spread.Data.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Requests.Queries
{
    public class DeleteLookUpByIdRequest : IRequest<bool>
    {
        public DeleteLookUpByIdRequest(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}

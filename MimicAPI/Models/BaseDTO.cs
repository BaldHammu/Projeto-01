﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimicAPI.Models
{
    public abstract class BaseDTO
    {
        public List<LinkDTO> Links { get; set; }
    }
}

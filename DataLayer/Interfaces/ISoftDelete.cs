﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface ISoftDelete
    {
        bool SoftDeleted { get; set; }
    }
}

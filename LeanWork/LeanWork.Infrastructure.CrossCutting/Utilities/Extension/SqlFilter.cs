﻿using System;

namespace LeanWork.Infrastructure.CrossCutting.Utilities.Extension
{
    public class SqlFilter : Attribute
    {
        public string SequenceName { get; set; }
    }
}

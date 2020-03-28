﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models.ViewModels
{
    public class CastViewModel
    {
        public int Int { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
        public string Profile_Path { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class CastSelection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
        public string Profile_Path { get; set; }
    }
}

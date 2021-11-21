﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimaiHelper.Kimai.Model
{
    public class Activity
    {
        public Activity(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Visible { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace adonetdetails.model
{
        public class Student
        {
            public int StudentID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Gender { get; set; }
            [Required]
            public string Department { get; set; }
            [Required]
            public string City { get; set; }
        }


    }

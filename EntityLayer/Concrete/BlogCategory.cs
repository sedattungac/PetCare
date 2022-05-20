﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogCategory
    {
        [Key]
        public int BlogCategoryId { get; set; }
        public string Title { get; set; }
        //Connection
        public ICollection<Blog> Blogs { get; set; }

    }
}

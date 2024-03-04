using System;
using System.Collections.Generic;

namespace TestBlog.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Intro { get; set; }

    public string? Body { get; set; }


    public int CategoryId { get; set; } // for fk
    public Category Category { get; set; } // for np

}

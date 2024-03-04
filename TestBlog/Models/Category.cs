using System;

namespace TestBlog.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public ICollection<Blog> Blogs { get; set; } // for np

}

using System;
using System.Collections.Generic;

namespace EF_Lecture.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Content { get; set; }

    public DateTime? DatePosted { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}

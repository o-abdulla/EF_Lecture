using System;
using System.Collections.Generic;

namespace EF_Lecture.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;
}

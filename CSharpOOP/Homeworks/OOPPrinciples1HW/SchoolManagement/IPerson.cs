using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement
{
    public interface IPerson : ICommentable
    {
        string Name { get; set; }
    }
}

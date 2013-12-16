using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement
{
  public  interface ICommentable
    {
      string Comment { get; set; }
      void AddComment(string comment);
      void ShowComment();
    }
}

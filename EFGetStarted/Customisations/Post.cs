using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted
{
    public partial class Post
    {
        public override string ToString()
        {
            return $"Post: {Title}";
        }
    }
}

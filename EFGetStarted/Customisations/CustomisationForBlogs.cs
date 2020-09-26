using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted
{
    public partial class Blog
    {
        public override string ToString()
        {
            return $"Blog Number: {BlogId} Url: {Url}";
        }
    }
}

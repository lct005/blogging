using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogging.Core.Objects
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}

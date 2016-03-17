using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPL.Tokens
{
    public sealed class Identifier
    {
        public string Name { get; }

        public Identifier(string Name)
        {
            this.Name = Name;
        }
    }
}

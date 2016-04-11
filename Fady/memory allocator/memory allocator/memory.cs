using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace memory_allocator
{
    public class memory
    {
        public string name;
        public int BaseAddress;
        public int Size;
        public bool IsProcess;
        public memory()
        {

        }
        public memory(int b,int s)
        {
            BaseAddress = b;
            Size = s;
        }
    }
}

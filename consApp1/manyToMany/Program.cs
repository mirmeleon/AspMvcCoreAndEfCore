using System;

namespace manyToMany
{
    class Program
    {
        static void Main()
        {
            using (var ctx = new MyCtx())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    }
}

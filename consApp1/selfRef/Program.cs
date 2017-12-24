namespace selfRef
{
    using System;
    public  class Program
    {
       public static void Main()
        {
            using (var ctx = new MyCtx())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    }
}

namespace hw01
{
    using System;
   public class Program
    {
       public static void Main()
        {
            var ctx = new MyDbContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var dep = new Department { Name = "IT" };
            ctx.Add(dep);
            dep.Employees.Add(new Employee { Name = "deni" });
            ctx.SaveChanges();


          var first =  ctx.Departments.Find(1);
            Console.WriteLine(first.Name);
        }
    }
}

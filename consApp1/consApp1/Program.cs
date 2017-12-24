using System;
using System.Collections.Generic;

namespace consApp1
{
   public class Program
    {
       public static void Main()
        {

            var db = new MyDbContext();
            //ensureDeleted e ako iskame vseki put pri startirane da ni izprazva dbto i da ia presuzdava
            //dobro e za uprajnenja
             db.Database.EnsureDeleted();
             db.Database.EnsureCreated();

          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IREmbeddedApp;

namespace IRRSpec
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var er = new EmbeddedRuby();
                var resources = er.AddAssembly("IREmbeddedLibraries");
                resources.Mount("Files/ironruby");
                resources.Mount("Files/rspec-1.3.0/lib");
                resources.Mount("Files/site_ruby/1.8");
                resources.Mount("Files/1.8");

                er.Mount("Applications");
                er.Run("user_spec.rb", args);
            }
            catch (Exception)
            {
              // not sure why when rspec exits throws an exception
            }

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}

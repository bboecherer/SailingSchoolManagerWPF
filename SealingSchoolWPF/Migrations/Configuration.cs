namespace SailingSchoolWPF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SailingSchoolWPF.Data.SchoolDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SailingSchoolWPF.Data.SchoolDataContext context)
        {
           
        }
    }
}

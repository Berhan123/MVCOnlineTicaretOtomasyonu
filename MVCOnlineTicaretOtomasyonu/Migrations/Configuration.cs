namespace MVCOnlineTicaretOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCOnlineTicaretOtomasyonu.Models.Siniflar.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCOnlineTicaretOtomasyonu.Models.Siniflar.Context context)
        {

        }
    }
}

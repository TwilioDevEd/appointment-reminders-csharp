namespace AppointmentReminders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimezoneToAppointments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Timezone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Timezone");
        }
    }
}

namespace T04R.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numerodos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleadoes", "Nomina_ID", c => c.Int());
            AddColumn("dbo.Empleadoes", "Tipo_ID", c => c.Int());
            AddColumn("dbo.Empleadoes", "Departamento_ID", c => c.Int());
            CreateIndex("dbo.Empleadoes", "Nomina_ID");
            CreateIndex("dbo.Empleadoes", "Tipo_ID");
            CreateIndex("dbo.Empleadoes", "Departamento_ID");
            AddForeignKey("dbo.Empleadoes", "Nomina_ID", "dbo.Nominas", "ID");
            AddForeignKey("dbo.Empleadoes", "Tipo_ID", "dbo.Tipoes", "ID");
            AddForeignKey("dbo.Empleadoes", "Departamento_ID", "dbo.Departamentoes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "Departamento_ID", "dbo.Departamentoes");
            DropForeignKey("dbo.Empleadoes", "Tipo_ID", "dbo.Tipoes");
            DropForeignKey("dbo.Empleadoes", "Nomina_ID", "dbo.Nominas");
            DropIndex("dbo.Empleadoes", new[] { "Departamento_ID" });
            DropIndex("dbo.Empleadoes", new[] { "Tipo_ID" });
            DropIndex("dbo.Empleadoes", new[] { "Nomina_ID" });
            DropColumn("dbo.Empleadoes", "Departamento_ID");
            DropColumn("dbo.Empleadoes", "Tipo_ID");
            DropColumn("dbo.Empleadoes", "Nomina_ID");
        }
    }
}

namespace T04R.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Empleado_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empleadoes", t => t.Empleado_ID)
                .Index(t => t.Empleado_ID);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaDeNacimiento = c.String(),
                        IDTipo = c.Int(nullable: false),
                        IDDepartamento = c.Int(nullable: false),
                        IDNomina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departamentoes", t => t.IDDepartamento, cascadeDelete: true)
                .ForeignKey("dbo.Nominas", t => t.IDNomina, cascadeDelete: true)
                .ForeignKey("dbo.Tipoes", t => t.IDTipo, cascadeDelete: true)
                .Index(t => t.IDTipo)
                .Index(t => t.IDDepartamento)
                .Index(t => t.IDNomina);
            
            CreateTable(
                "dbo.Nominas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sueldo = c.Double(nullable: false),
                        TiempoTrabajo = c.String(),
                        Bono = c.Double(nullable: false),
                        IVA = c.Double(nullable: false),
                        Empleado_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empleadoes", t => t.Empleado_ID)
                .Index(t => t.Empleado_ID);
            
            CreateTable(
                "dbo.Tipoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Empleado_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empleadoes", t => t.Empleado_ID)
                .Index(t => t.Empleado_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tipoes", "Empleado_ID", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "IDTipo", "dbo.Tipoes");
            DropForeignKey("dbo.Nominas", "Empleado_ID", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "IDNomina", "dbo.Nominas");
            DropForeignKey("dbo.Departamentoes", "Empleado_ID", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "IDDepartamento", "dbo.Departamentoes");
            DropIndex("dbo.Tipoes", new[] { "Empleado_ID" });
            DropIndex("dbo.Nominas", new[] { "Empleado_ID" });
            DropIndex("dbo.Empleadoes", new[] { "IDNomina" });
            DropIndex("dbo.Empleadoes", new[] { "IDDepartamento" });
            DropIndex("dbo.Empleadoes", new[] { "IDTipo" });
            DropIndex("dbo.Departamentoes", new[] { "Empleado_ID" });
            DropTable("dbo.Tipoes");
            DropTable("dbo.Nominas");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Departamentoes");
        }
    }
}

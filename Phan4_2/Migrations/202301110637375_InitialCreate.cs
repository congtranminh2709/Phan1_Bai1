namespace Phan4_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Luong",
                c => new
                    {
                        ID_Luong = c.Int(nullable: false, identity: true),
                        Bac_Luong = c.Decimal(nullable: false, precision: 4, scale: 2),
                        Ten = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_Luong);
            
            CreateTable(
                "dbo.NhanSu",
                c => new
                    {
                        MaNV = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 50),
                        NgaySinh = c.DateTime(nullable: false),
                        QueQuan = c.String(nullable: false, maxLength: 50),
                        GioiTinh = c.Int(nullable: false),
                        Ngay_BD = c.DateTime(nullable: false),
                        MaPB = c.Int(nullable: false),
                        ID_Luong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNV)
                .ForeignKey("dbo.PhongBan", t => t.MaPB, cascadeDelete: true)
                .ForeignKey("dbo.Luong", t => t.ID_Luong, cascadeDelete: true)
                .Index(t => t.MaPB)
                .Index(t => t.ID_Luong);
            
            CreateTable(
                "dbo.PhongBan",
                c => new
                    {
                        MaPB = c.Int(nullable: false, identity: true),
                        TenPB = c.String(nullable: false, maxLength: 50),
                        MoTa = c.String(nullable: false, maxLength: 50),
                        STT_PB = c.Int(nullable: false),
                        Parent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.MaPB);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanSu", "ID_Luong", "dbo.Luong");
            DropForeignKey("dbo.NhanSu", "MaPB", "dbo.PhongBan");
            DropIndex("dbo.NhanSu", new[] { "ID_Luong" });
            DropIndex("dbo.NhanSu", new[] { "MaPB" });
            DropTable("dbo.PhongBan");
            DropTable("dbo.NhanSu");
            DropTable("dbo.Luong");
        }
    }
}

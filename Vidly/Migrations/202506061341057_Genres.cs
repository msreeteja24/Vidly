﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Action') ");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Thriller') ");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Family') ");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Romance') ");
            Sql("INSERT INTO Genres(Id, Name) VALUES (5, 'Comedy') ");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}

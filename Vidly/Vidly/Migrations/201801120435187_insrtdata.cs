namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insrtdata : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Sholay','2/2/2018','1/1/1975',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Mughal-e-Azam','2/2/2018','1/1/1960',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Mother India','2/2/2018','1/1/1957',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Dilwale Dulhania Le Jayenee','2/2/2018','1/1/1995',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Pyaasa','2/2/2018','1/1/1957',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Guide','2/2/2018','1/1/1965',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Deewaar','2/2/2018','1/1/1975',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Lagaan','2/2/2018','1/1/2001',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Pakeezah','2/2/2018','1/1/1972',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Amar Akbar Anthony','2/2/2018','1/1/1977',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Do Bigha Zamin','2/2/2018','1/1/1953',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Jaane Bhi Do Yaaro','2/2/2018','1/1/1983',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('3 Idiots','2/2/2018','1/1/2009',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Kaagaz Ke Phool','2/2/2018','1/1/1959',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Bombay','2/2/2018','1/1/1995',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Mr India','2/2/2018','1/1/1987',2,2)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Satya','2/2/2018','1/1/1998',2,2)");

        }

        public override void Down()
        {
        }
    }
}

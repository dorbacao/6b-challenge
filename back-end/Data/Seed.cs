using Microsoft.EntityFrameworkCore;

public static class Seed
{
    public static void Fill(ModelBuilder modelBuilder)
    {
        var userMarcus = new User();
        userMarcus.Id = Guid.Parse("4e60a6ed-fd98-44cf-ab03-f64bf55b210a");
        userMarcus.Name = "Marcus Vinícius Carreira Dorbação";
        userMarcus.Login = "marcus.carreira@gmail.com";
        userMarcus.Password = "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy";

        var userFabrice = new User();
        userFabrice.Id = Guid.Parse("1a60a6ed-fd98-44cf-ab03-f64bf55b210a");
        userFabrice.Name = "Fabrice Domingues";
        userFabrice.Login = "fabricedomingues7@gmail.com";
        userFabrice.Password = "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy";

        var userJack = new User();
        userJack.Id = Guid.Parse("1a40a6ed-fd98-44cf-ab03-f64bf55b100a");
        userJack.Name = "Jack";
        userJack.Login = "jack@javeloper.co.uk";
        userJack.Password = "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy";

        var userJosh = new User();
        userJosh.Id = Guid.Parse("1b41a6ed-fd98-44cf-ab03-f64bf55b100a");
        userJosh.Name = "Josh";
        userJosh.Login = "josh@joshwalshaw.com";
        userJosh.Password = "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy";

        var userAngelo = new User();
        userAngelo.Id = Guid.Parse("0a41a6ab-fd98-44cf-ab03-f64bf55b100a");
        userAngelo.Name = "Angelo";
        userAngelo.Login = "angelo@6bdigital.com";
        userAngelo.Password = "$2a$11$GO38rMrQhRQM0czSRZm2Oe.7J2JWe75a9.iuDiinGuWdaECA1G1Wy";

        modelBuilder.Entity<User>().HasData(userMarcus, userFabrice, userJack, userJosh, userAngelo);
    }

}

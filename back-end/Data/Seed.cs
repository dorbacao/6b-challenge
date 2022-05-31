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


        var booking1 = new Booking();
        booking1.Id = Guid.Parse("1a21a6ed-fd98-44cf-ab03-f64bf55b100a");
        booking1.CreatedOn = new DateTime(2022, 10, 10);
        booking1.BookingDate = new DateTime(2022, 5, 29);
        booking1.VehicleSize = VehicleSize.Small;
        booking1.Flexibility = Flexibility.OneDay;
        booking1.ContactNumber = "913336296";
        booking1.EmailAddress = "marcus.carreira@gmail.com";
        booking1.Approved = false;

        var booking2 = new Booking();
        booking2.Id = Guid.Parse("1c11a6ed-fd98-44cf-ab03-f64bf55b100b");
        booking2.CreatedOn = new DateTime(2022, 10, 10);
        booking2.BookingDate = new DateTime(2022, 5, 29);
        booking2.VehicleSize = VehicleSize.Van;
        booking2.Flexibility = Flexibility.OneDay;
        booking2.ContactNumber = "913336296";
        booking2.EmailAddress = "fabricedomingues7@gmail.com";
        booking2.Approved = false;

        var booking3 = new Booking();
        booking3.Id = Guid.Parse("1a44a6ed-fd98-44cf-ab03-f64bf55b100b");
        booking3.CreatedOn = new DateTime(2022, 10, 10);
        booking3.BookingDate = new DateTime(2022, 5, 29);
        booking3.VehicleSize = VehicleSize.Small;
        booking3.Flexibility = Flexibility.OneDay;
        booking3.ContactNumber = "913336296";
        booking3.EmailAddress = "jack@javeloper.co.uk";
        booking3.Approved = false;

        var booking4 = new Booking();
        booking4.Id = Guid.Parse("0ac2a6ed-fd98-44cf-ab03-f64bf55b100b");
        booking4.CreatedOn = new DateTime(2022, 10, 10);
        booking4.BookingDate = new DateTime(2022, 5, 29);
        booking4.VehicleSize = VehicleSize.Large;
        booking4.Flexibility = Flexibility.ThreeDays;
        booking4.ContactNumber = "913336296";
        booking4.EmailAddress = "josh@joshwalshaw.com";
        booking4.Approved = false;

        var booking5 = new Booking();
        booking5.Id = Guid.Parse("0ac2a6ed-ab12-44cf-ab03-f64bf55b100b");
        booking5.CreatedOn = new DateTime(2022, 10, 10);
        booking5.BookingDate = new DateTime(2022, 5, 29);
        booking5.VehicleSize = VehicleSize.Small;
        booking5.Flexibility = Flexibility.ThowDays;
        booking5.ContactNumber = "913336296";
        booking5.EmailAddress = "angelo@6bdigital.com";
        booking5.Approved = false;

        modelBuilder.Entity<Booking>().HasData(booking1, booking2, booking3, booking4, booking5);
    }

}

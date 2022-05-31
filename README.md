# 6b-Challenge
Challenge for interview at 6b company

# The Problem » DJ Valeting
DJ Valeting is a car valeting service which tours the business parks of Wakefield valeting cars on 
the go. DJ Valeting has approached us to solve a simple problem in an easy-to-use way, the 
problem being, bookings. Currently, all bookings are done over the phone and are written down 
manually and tracked this way, we are going to make this automated.

# The Sollution

To solve this problem I used the following stack.
On the front-end, I used vannila javascript without any dependency on external packages, just the static-server node package to raise a simple static web server.

On the back end i use aspnet core latest version with EF Core for persistence.
Below are some aspects that I consider important in the backend api.

I tried to organize the code valuing some aspects of the DDD that I consider important, such as creating folders that represent the aggregator roots (example BookingAgg) in the aggregator folder.
In addition to the main entity (Root aggregate) there are enumerators that are under your responsibility in this same directory.

The aspnet core pipeline settings have been implemented in the form of extensions methods and are invoked in the Program.cs file

# Running front end
To run the front end follow the steps below:

* CMD: git clone https://github.com/dorbacao/6b-challenge
* CMD: open root repository folder
* CMD: cd front-end
* CMD: npm install
* CMD: static-server
* go to the browser and run the link http://localhost:9080/

# Running back end
To run the API follow the steps below:
* CMD: git clone https://github.com/dorbacao/6b-challenge (ignore this step if you get the front end before)
* CMD: Open Developer Command Prompt for VS
* CMD: open root repository folder
* CMD: cd back-end
* Change a connection string to your preference (in the file appsettings.json)
* CMD: dotnet ef database update 
* CMD: dotnet run




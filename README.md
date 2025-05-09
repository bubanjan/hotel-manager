# Hotel manager API

## Project plan

I chose the standard Controller + Repository pattern for this Web API. I personally prefer this approach because it's commonly recommended by   
Microsoft and widely adopted in the .NET ecosystem. It's also well-tested by large teams of professionals and tends to require  
less boilerplate code compared to some other architectural patterns. Additionally, it integrates well with Swagger out of the box.  

I decided not to use a service layer between the controller and repository, as I believe that in the context of this project,  
it would be an unnecessary complication.  

I chose SQLite as the database since it's well-suited for small projects.  

My plan includes:

- Mapping between entity classes and DTOs
- Adding try/catch blocks in controller action methods 
- Implementing logging
- Adding authentication and authorization with Admin and Receptionist roles

For authentication, I plan to use HTTP-only cookies, as they offer good security.

I like to divide projects into small, trackable tasks, in addition to using a GitHub repository for version control.

When I think about the next version of this API, it might be a good idea to add a Booking entity.  
It would contain data such as: GuestId, Id, number of guests, check-in and check-out dates, price, room number.  
The relationship between Guest and Booking would be one-to-many, meaning a single guest could have multiple bookings.  
He can come with friends or family in the room, but only his id would be saved in booking as booking creator.    


To log in use roles:

admin:
{
  "userName": "Admin1",
  "email": "admin1@gmail.com",
  "password": "admin555",
  "role": "Admin"
}

receptionist:
{
  "userName": "Receptionist1",
  "email": "johnreception@gmail.com",
  "password": "reception333",
  "role": "Receptionist"
}


### tasks:

- [x] install serielog package
- [x] install sqlite packages
- [x] add Guest entity class 
- [x] add DbContext
- [x] Configure DbContext and Serilog in Program.cs
- [x] add first migration and run database-update  
- [x] add Controller
- [x] add Repository
- [x] register Repository in DI container
- [x] add DTOs
- [x] add Mapper

- [x] add full name to dto

- [x] get Guest
- [x] create Guest
- [x] delete Guest
- [x] update Guest
- [x] get Guests collection

- [x] try/ catch + logging
- [x] pagination
- [x] text search by full name
- [x] order by full name

- [x] add Authentication/authorization
- [x] add role based authorization on controller actions
- [x] try/catch + logging in auth.controller

- [x] Test everything with swagger
- [x] fix comments.md code
- [x] Test if the zipped project works correctly after unzipping

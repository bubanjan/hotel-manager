## Project plan

I chose the standard pattern of Controllers + Repository. I personally like this approach the most because it is commonly recommended by Microsoft.   
So I think that it is more tested than other patterns.  
It also gives you more control and results in less boilerplate code compared to some other patterns.  
I chosed to not use service between controller and repository, becasue I think that in case of this project,  
it would be just uneccesary complication.

I chose sqlite because it suits good for small project.

My plan is to add:

- mapping between entity classes and DTOs
- try/catch in controller action methods 
- logging
- authentication/authorisation with Admin and Receptionist permission role

For authentication I chose http only cookie like option with good security. 

I like to devide projects in small tasks, to follow what is done beside github repo.

### tasks:

- [ ] fix comments.md formating code
- [x] install serielog package
- [x] install sqlite packages
- [x] add entity class Guest
- [x] add DbContext
- [x] add DbContext and Serielog configurations in Program.cs
- [x] add first migration and run database-update  
- [x] add Controller
- [x] add Repository
- [x] register Repository in DI
- [x] add DTOs
- [x] add Mapper

- [ ] add full name in dto, and searching by full name.. fname + lname..  

- [x] get Guest
- [x] create Guest
- [ ] delete Guest
- [x] update Guest
- [ ] get Guests

- [ ] try/ catch + logging
- [ ] paggination
- [ ] text search
- [ ] order by name (ascending, descending)

- [ ] Authentication/authorization
- [ ] add authorization on controller actions

- [ ] Test all with swagger
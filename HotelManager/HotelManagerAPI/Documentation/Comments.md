# Project plan

I chose the standard pattern of Controllers + Repository. I personally like this approach the most because it is commonly recommended by Microsoft. So I think that it is more tested than other patterns.
It also gives you more control and results in less boilerplate code compared to some other patterns.
I chosed to not use service between controller and repository, becasue I think that in case of this project,
it would be just uneccesary complication.

I chose sqlite because it suits good for small project.

I think that this API should have some important parts:

- logging
- authentication/authorisation
- mapping between entity classes and DTOs
- try/catch in controller action methods 

For authentication I chose http only cookie like option with good security. 

I like to devide projects in small tasks, that I do step by step and push code on git repo.

## Tasks:

- [x] install serielog package
- [ ] install sqlite packages
- [ ] add entity class Guest
- [ ] add DbContext
- [ ] add DbContext and Serielog configurations in Program.cs
- [ ] add first migration and run database-update

## CRUD operations

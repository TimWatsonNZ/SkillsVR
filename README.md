# SkillsVR

Backend service in dot net core for SkillsVR

To run you will need to first run a database migration. Run the below lines in the CLI from the project folder:

dotnet ef migrations add InitialCreate -o './Data'
dotnet ef database update

I've added a test project that runs integration tests against an in-memory database.

Remarks:

I modelled height and weight as integers instead of floats because I think it's cleaner. 
Established year could also be an int but I thought it made sense to extend it to a date to model the date of establishment.
I thought about creating other tables - for grounds and coach but in the interest of time didn't pursue this.
Likewise the relationship of player to team, in a real app I would create a linking table as otherwise the history
of a player's teams gets erased.


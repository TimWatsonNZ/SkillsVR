# SkillsVR

Backend service in dot net core for SkillsVR

dotnet ef migrations add InitialCreate -o './Data'
dotnet ef database update

Remarks:

Decided on int for weight and height instead of float and to model each as grams and centimetres.
Floats are probably fine for these fields, the real danger with floats is when you are doing operations on them.
Place of birth I decided on string for simplicity, in a real app you might want to have an object with
city, country etc.
Player-Team connection, in a real app I would separate this into another table, this then lets you have a history of 
players-teams. Having a foreign key on the table itself erases this history any time a player changes team. Having a 
separate table also lets you model states such as, player just signed on, player injured.


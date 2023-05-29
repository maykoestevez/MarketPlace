# Marketplace-Docker

This application is an CRUD where we can create new products in DB.

Make sure to have Marketplace-Web in the same folder you have API like:
  Marketplace
  Marketplace-Web

Docker compose sould be run from API project (MarketPlace)

To start the application using docker run this commands in teh console:
Run docker build
Run docker up 

After it run this command from API project to create DB and add some seed data
Change config to target DB from API Project to SQL server in container by changing server from "db" to "127.0.0.1" then run:
dotnet ef database update --startup-project ./MarketPlace.api  
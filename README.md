# GameMicroService
### A Team Bobby Project
### Members:
> Isaac Camacho, Richard Cashion, Dylan Cowell, Thomas Foreman,
> Dionte Jones, Matt Justis, Jacob Klucher, Dylan Lynch, 
> Caleb Rains, Chris Seals, Kyle Wittman
#### CSCI 4350
#### Fall 2023, East Tennessee State University

### Overview:
This is a microservice that returns game info in JSON format to the [BOBBY Project](https://github.com/chrisseals98/BOBBY).

### Project Structure:
* The application handles HTTP calls in the microController.cs file in the /GameMicroServer/Controllers directory.
* It only handles an HTTP Get call to the path /Micro. So if the application was running locally, you would call [http://localhost/Micro](http://localhost/Micro).
* This application is deployed alongside the BucStop project with docker compose, see [BOBBY Project](https://github.com/chrisseals98/BOBBY) for more details.

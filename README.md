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

### Help
For more documentation on how to run locally and how to set up deployments, see the google docs below:
* [Running Locally](https://docs.google.com/document/d/1gfUpjZNfqWyv1ohUW1IaS8fOhXp0hOx6tFQVXBADa8Q/edit?usp=sharing)
* [How to Deploy](https://docs.google.com/document/d/1i0edcmvZm_j0zQLYiigNliW39FJuJbmhkxOCCb2NbVs/edit?usp=sharing)

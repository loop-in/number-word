# number-to-word

## Link
- [Code Approach](doc/CODE.md)
- [Test Plan](doc/TESTPLAN.md)

## Backend
1. To start the backend, just open the solution file **src/NumberToWord.sln** with Visual Studio
2. Set **NumberToWord.Api** as startup project, build and run it, it will automatically open the swagger page in the browser
3. Can be tested directly from swagger
4. To use bash script for testing, run the following command and follow the instructions, make sure above steps are run first
>`sh test_script.sh` 

## Deployment
**NOTE:** Depending on how it is being hosted and where, the approach will be different.

<ins>Azure App Service</ins>
This deployment approach is a simple approach based on Azure App Service Kudu API.
1. Go to the specific Azure App Service that you want to deploy to, navigate to Deployment Center, go to FTPS credentials tab
2. Copy the username and password from the "Application Scope"
3. Set the environment variables in your CICD for $Username, $Password and $AppName, AppName will be the App Service name you created in Azure
4. Run the following command in root directory
>`sh deploy.sh`
5. Open browser and go to https://<AppName>.azurewebsites.net/swagger

<ins>Docker</ins>
This deployment approach will run the application locally in docker container
1. Open terminal or command prompt, go to `src` folder
2. Run the following command to build the image
>`docker build -t numberword-api:1.0 .`
3. Next run the container based on the image created
>`docker run -p 80:80 --name numberword -it ——rm numberword-api:1.0`
4. Open browser and go to http://localhost/swagger

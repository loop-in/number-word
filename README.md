# number-to-word

### Link
- [Code Approach](doc/CODE.md)
- [Test Plan](doc/TESTPLAN.md)

### Backend
1. To start the backend, just open the solution file **src/NumberToWord.sln** with Visual Studio
2. Set **NumberToWord.Api** as startup project, build and run it, it will automatically open the swagger page in the browser
3. Can be tested directly from swagger
4. To use bash script for testing, run the following command and follow the instructions
`sh test_script.sh` 

### Deployment
**NOTE:** Depending on how it is being hosted and where, the approaches will be different. This deployment approach is a simple approach based on Azure App Service Kudu API.

1. Go to the specific Azure App Service that you want to deploy to, navigate to Deployment Center, go to FTPS credentials tab
2. Copy the username and password from the "Application Scope"
3. Set the environment variables in your CICD for $Username, $Password and $AppName
4. Run the following command in root directory `sh deploy.sh`

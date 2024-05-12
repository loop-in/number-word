#!/bin/bash

# Publish the output
dotnet publish "src/NumberToWord.Api/NumberToWord.Api.csproj" --configuration Release --output ./publish

# Navigate to publish folder
cd ./publish

# Zip the content
zip -r number-to-word.zip .

# Basic authentication
curl -X POST \
     -u "$Username:$Password" \
     -T "number-to-word.zip" \
     "https://$AppName.scm.azurewebsites.net/api/publish?type=zip"

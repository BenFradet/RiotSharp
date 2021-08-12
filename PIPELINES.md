# Nuget Action

## Description
This action provides a pipeline to create and publish new nuget packages on new github releases / tag creations.  
The created nuget package can be published on nuget.org and within the github repository.

## Repository Requirements
In order for the pipeline to run there need to be some secrets in place.  
Secrets can be added in the repository -> Settings -> Secrets -> (top right) New repository secret  
Secrets required for the pipeline:  
- NUGET_API_KEY being an api key for nuget.org [nuget api key](https://www.nuget.org/account/apikeys)

## Usage
Create a Github Release with a tag in the format of versioning (eg 5.0.0 or 5.0.0-alpha).  
Checkout the Actions tab to figure out whether the pipe ran smoothly or errors occurred.  

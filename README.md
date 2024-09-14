# Sauce Lab Project

## Description

This project aims to automate and validate the main flows on Sauce Demo application using Selenium with SpecFlow in C#. The project was created to ensure the quality and proper functioning of critical functionalities of the application.

## Project Structure

```plaintext
├── Features               
│   ├── Login.feature    
│   └── Logout.feature 
|   └── ProductPage.feature       
│
├── Steps Definitions                 
│   ├── LoginStepsDefinitions.cs    
│   └── LogoutStepDefinitions.cs
│   └── ProductPageStepDefinitions.cs    
│
├── Utils                
│   ├── Common.cs    
│   

## Requirements
To run this automation, make sure you have the following installed:

Visual Studio 2022
.NET 6 SDK
Selenium WebDriver
SpecFlow for BDD testing

# Installing Dependencies
Install-Package Selenium.WebDriver
Install-Package SpecFlow.NUnit
Install-Package ExtentReports

## Running Tests
In Visual Studio, right-click the solution and select "Run Tests" or use the "Test Explorer."

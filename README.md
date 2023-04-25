# WebTestBDD
# Web Test Solution

This is a C# solution for automating the testing of a web application using the BDD approach. The target website for this test is the dummy website https://cms.demo.katalon.com/.

# Prerequisites

To run this solution, you need to have the following installed on your machine:

Visual Studio/Rider/ Visual Code
SpecFlow
Selenium.WebDriver
Selenium Webdriver manager

# How to Run

To run this solution, follow these steps:

Clone the repository to your local machine
Open the solution in Visual Studio
Build the solution
Open the Test Explorer window in Visual Studio
Run the tests in the Test Explorer window

Alternatively, you can run the tests from the command line using the following command:

dotnet test

# Test Scenarios

This solution includes a single feature file, "WebTestScenario.feature", which includes the following scenario:

Feature: WebTest
As a user
I want to add and remove items from my cart
So that I can verify the correct number of items in my cart

    Scenario: Add and remove items from cart
        Given I add four random items to my cart
        When I view my cart
        Then I should see four items in my cart
        When I search for the lowest price item
        And I remove the lowest price item from my cart
        Then I should see three items in my cart
        
This scenario tests the ability to add and remove items from a cart on the target website.

# Test Results
![image](https://user-images.githubusercontent.com/20572453/234194642-d497dadc-ffd0-4fb0-bcb0-20f396959e0c.png)

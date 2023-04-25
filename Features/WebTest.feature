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
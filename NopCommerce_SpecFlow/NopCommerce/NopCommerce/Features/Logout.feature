@Logout
Feature: Logout
    As a user logged into the website, I want to log out

    @LogoutSuccessfully
    Scenario: Logout successfully
        Given I already have an account with information
            | Firstname | Lastname | Email          | Password | ConfirmPassword |
            | Loan      | Nguyen   | loan@gmail.com | 123123   | 123123          |
        And I log in with "loan@gmail.com" and "123123"
        When I click Logout button
        Then I logged out the website successfully
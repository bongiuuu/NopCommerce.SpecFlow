@DeleteAddress
Feature: Delete address
    As a user, I would like to delete an address

    Background: Precondition
        Given I already have an account with information
            | Firstname | Lastname | Email          | Password | ConfirmPassword |
            | Loan      | Nguyen   | loan@gmail.com | 123123   | 123123          |
        And I log in with "loan@gmail.com" and "123123"
        And I already have an address with information
            | Field      | Value             |
            | First Name | Loan              |
            | Last Name  | Nguyen            |
            | Email      | loanntb@gmail.com |
            | Company    | NashSquared       |
            | Country    | Viet Nam          |
            | State      |                   |
            | City       | Hanoi             |
            | Address1   | Thai Ha Str       |
            | Address2   | Duy Tan Str       |
            | Zipcode    | 700000            |
            | Phone      | 011283767         |
            | Fax        | CODEN16           |

    Scenario: Verify that the system displays a confirmation notification when clicking on Delete button
        When I click Delete button
        Then the system displays an alert message "Are you sure?"

    @DeleteAddressSuccessfully
    Scenario: Delete address successfully
        When I click Delete button
        And the system displays an alert message "Are you sure?"
        And I click OK button on alert
        Then the Address page is empty

    @DeleteAddressUnsuccessfully
    Scenario: Delete address unsuccessfully - click Cancel on alert
        When I click Delete button
        And the system displays an alert message "Are you sure?"
        And I click Cancel button on alert
        Then the added address is showed on the page
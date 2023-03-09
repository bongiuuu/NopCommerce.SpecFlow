@EditCustomerInformation
Feature: Edit customer information
    As an user, I would like to edit my account information

    Background: Prcondition
        Given I already have an account with information
            | Firstname | Lastname | Birthday   | Email          | CompanyName | Password | ConfirmPassword |
            | Loan      | Nguyen   | 06/10/2000 | loan@gmail.com | NashTech    | 123123   | 123123          |

    @EditCustomerInformationSuccessfully
    Scenario: Edit information successfully - no field change
        Given I log in with "loan@gmail.com" and "123123"
        And I am in Edit customer page
        When I click Save button
        Then the notification shows a message "The customer info has been updated successfully."

    Scenario Outline: Edit infomation successfully - input new values
        Given I log in with "loan@gmail.com" and "123123"
        And I am in Edit customer page
        When I input values to address fields
            | Field        | Value       |
            | Gender       | <gender>    |
            | First Name   | <firstname> |
            | Last Name    | <lastname>  |
            | Birthday     | <birthday>  |
            | Email        | <email>     |
            | Company Name | <company>   |
        And I click Save button
        Then the notification shows a message "The customer info has been updated successfully."

        Examples:
            | gender | firstname | lastname | birthday   | email          | company      |
            | Female | Loan      | Le       | 01/08/2000 | loan@gmail.com | nash squared |
            | Male   | Hai       | Le       |            | hai@gmail.com  |              |

    @EditCustomerInformationUnsuccessfully
    Scenario Outline: Edit information unsuccessfully
        Given I log in with "loan@gmail.com" and "123123"
        And I am in Edit customer page
        When I input values to address fields
            | Field        | Value       |
            | Gender       | <gender>    |
            | First Name   | <firstname> |
            | Last Name    | <lastname>  |
            | Birthday     | <birthday>  |
            | Email        | <email>     |
            | Company Name | <company>   |
        And I click Save button
        Then the system displays error message on fields "<errorFirstname>", "<errorLastname>", "<errorEmail>"

        Examples:
            | Scenario              | gender | firstname | lastname | birthday   | email         | company      | errorFirstname          | errorLastname          | errorEmail         |
            | Empty All Fields      |        |           |          |            |               |              | First name is required. | Last name is required. | Email is required. |
            | Empty Required fields |        |           |          | 01/08/2000 |               | nash squared | First name is required. | Last name is required. | Email is required. |
            | Empty Firstname       | Male   |           | Le       | 01/08/2000 | hai@gmail.com | nash squared | First name is required. |                        |                    |
            | Empty Lastname        | Male   | Hai       |          | 01/08/2000 | hai@gmail.com | nash squared |                         | Last name is required. |                    |
            | Empty Email           | Male   | Hai       | Le       | 01/08/2000 |               | nash squared |                         |                        | Email is required. |
            | Wrong Email format    | Male   | Hai       | Le       | 01/08/2000 | hai           | nash squared |                         |                        | Wrong email        |

    @EditCustomerInformationUnsuccessfully
    Scenario: Edit information unsuccessfully - existed email
        Given the system already had an account with information
            | Firstname | Lastname | Birthday   | Email            | CompanyName | Password | ConfirmPassword |
            | Hai       | Le       | 01/08/1993 | hailpt@gmail.com | Tanchong    | 123123   | 123123          |
        And I log in with "loan@gmail.com" and "123123"
        And I am in Edit customer page
        When I input an existed email "hailpt@gmail.com" to email field
        And I click Save button
        Then the Edit information page displays error "The e-mail address is already in use"
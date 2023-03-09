@Register
Feature: Register
    As a user, I want to register an account

    @RegisterSuccessfully
    Scenario Outline: Register successfully
        Given I am in Register page
        When I fill account information
            | Field            | Value             |
            | Gender           | <gender>          |
            | First Name       | <firstname>       |
            | Last Name        | <lastname>        |
            | Birthday         | <birthday>        |
            | Email            | <email>           |
            | Company Name     | <companyName>     |
            | Password         | <password>        |
            | Confirm password | <confirmPassword> |
        And I click Register button
        Then the system displays "Your registration completed"

        Examples:
            | Scenario        | gender | firstname | lastname | birthday   | email          | companyName | password | confirmPassword |
            | Full fields     | Female | loan      | nguyen   | 06/10/2000 | loan@gmail.com | nashtech    | 123123   | 123123          |
            | Required fields |        | hai       | le       |            | hai@gmail.com  |             | 123123   | 123123          |

    @RegisterUnsuccessfully @RegisterUnsuccessfully_InvalidInput
    Scenario Outline: Register unsuccessfully
        Given I am in Register page
        When I fill account information
            | Field            | Value             |
            | Gender           | <gender>          |
            | First Name       | <firstname>       |
            | Last Name        | <lastname>        |
            | Birthday         | <birthday>        |
            | Email            | <email>           |
            | Company Name     | <companyName>     |
            | Password         | <password>        |
            | Confirm password | <confirmPassword> |
        And I click Register button
        Then the system displays error message on fields "<errorFirstname>", "<errorLastname>", "<errorEmail>", "<errorPassword>", "<errorConfirmPassword>"

        Examples:
            | Scenario                        | gender | firstname | lastname | email             | birthday   | companyName | password | confirmPassword | errorFirstname          | errorLastname          | errorEmail         | errorPassword                                                          | errorConfirmPassword                                 |
            | Empty all required fields       |        |           |          |                   |            |             |          |                 | First name is required. | Last name is required. | Email is required. | Password is required.                                                  | Password is required.                                |
            | Fill optional fields only       | Female |           |          |                   | 06/10/2000 | nashtech    |          |                 | First name is required. | Last name is required. | Email is required. | Password is required.                                                  | Password is required.                                |
            | Empty one of required fields    | Female |           | Nguyen   | loan@gmail.com    | 06/10/2000 | nashtech    | 123123   | 123123          | First name is required. |                        |                    |                                                                        |                                                      |
            | Wrong email format              | Male   | Hai       | Le       | haigmail.com      | 01/08/1993 | nashtech    | 123123   | 123123          |                         |                        | Wrong email        |                                                                        |                                                      |
            | Password length less than 6     | Male   | Hai       | Nguyen   | hailoan@gmail.com | 06/08/1990 |             | 12312    | 12312           |                         |                        |                    | Password must meet the following rules:must have at least 6 characters |                                                      |
            | Confirm password does not match | Male   | Hai       | Nguyen   | loanhai@gmail.com | 01/10/2000 | nashtech    | 123123   | 123124          |                         |                        |                    |                                                                        | The password and confirmation password do not match. |

    @RegisterUnsuccessfully @RegisterUnsuccessfully_AccountExisted
    Scenario Outline: Register unsuccessfully - account existed
        Given I already have an account with information
            | Gender | Firstname | Lastname | Birthday   | Email          | CompanyName | Password | ConfirmPassword |
            | Female | Loan      | Nguyen   | 06/10/2000 | loan@gmail.com | nashtech    | 123123   | 123123          |
        And I am in Register page
        When I register an account with email existed in the system
            | Field            | Value             |
            | Gender           | <gender>          |
            | First Name       | <firstname>       |
            | Last Name        | <lastname>        |
            | Birthday         | <birthday>        |
            | Email            | <email>           |
            | Company Name     | <companyName>     |
            | Password         | <password>        |
            | Confirm password | <confirmPassword> |
        Then the Register page displays error "The specified email already exists"

        Examples:
            | Scenario        | gender | firstname | lastname | birthday   | email          | companyName | password | confirmPassword |
            | Full fields     | Female | Loan      | Nguyen   | 06/10/2000 | loan@gmail.com | nashtech    | 123123   | 123123          |
            | Required fields | Female | Loan      | Nguyen   |            | loan@gmail.com |             | 123123   | 123123          |

    @RegisterUnsuccessfully @RegisterUnsuccessfully_CustomerRegistered
    Scenario Outline: Register unsuccessfully - customer registered
        Given I already have an account with information
            | Gender | Firstname | Lastname | Birthday   | Email          | CompanyName | Password | ConfirmPassword |
            | Female | Loan      | Nguyen   | 06/10/2000 | loan@gmail.com | nashtech    | 123123   | 123123          |
        And I log in with "loan@gmail.com" and "123123"
        And I am in Register page
        When I fill account information
            | Field            | Value             |
            | Gender           | <gender>          |
            | First Name       | <firstname>       |
            | Last Name        | <lastname>        |
            | Birthday         | <birthday>        |
            | Email            | <email>           |
            | Company Name     | <companyName>     |
            | Password         | <password>        |
            | Confirm password | <confirmPassword> |
        And I click Register button
        Then the Register page displays error "Current customer is already registered"
        Examples:
            | Scenario        | gender | firstname | lastname | birthday   | email             | companyName | password | confirmPassword |
            | Full fields     | Male   | Hai       | Nguyen   | 06/08/2000 | haing@gmail.com   | nashtech    | 123123   | 123123          |
            | Required fields | Female | Loan      | Nguyen   |            | loanntb@gmail.com |             | 123123   | 123123          |
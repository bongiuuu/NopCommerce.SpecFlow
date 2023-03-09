@EditAddress
Feature: Edit address

    As a user I want to edit address
    Background: Precondition
        Given I already have an account with information
            | Firstname | Lastname | Email          | Password | ConfirmPassword |
            | Loan      | Nguyen   | loan@gmail.com | 123123   | 123123          |
        And I log in with "loan@gmail.com" and "123123"
        And I am in Add new address page
        And I click Add new address button
        And I fill address information to fields
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
        And I click Save new address button

    @EditAddressSuccessfully
    Scenario Outline: Edit address successfully
        When I click Edit button
        And I update address information
            | Field      | Value       |
            | First Name | <firstname> |
            | Last Name  | <lastname>  |
            | Email      | <email>     |
            | Company    | <company>   |
            | Country    | <country>   |
            | State      | <state>     |
            | City       | <city>      |
            | Address1   | <address1>  |
            | Address2   | <address2>  |
            | Zipcode    | <zipCode>   |
            | Phone      | <phone>     |
            | Fax        | <fax>       |
        And I click Save new address button
        Then the notification shows a message "The address has been updated successfully."
        And the address is displayed with new information
        Examples:
            | Scenario             | firstname | lastname | email            | company  | country  | state | city     | address1       | address2 | zipCode | phone      | fax    |
            | Full Fields          | Hai       | Nguyen   | haintb@gmail.com | Tanchong | Viet Nam |       | HCM city | ADV Street     | St.90    | 700000  | 0123456789 | COMO68 |
            | Required fields only | Hai       | Le       | hailpt@gmail.com |          | Viet Nam |       | Hanoi    | Duy Tan Street |          | 700000  | 0192837465 |        |

    @EditAddressUnsuccessfully
    Scenario Outline: Edit address unsuccessfully
        When I click Edit button
        And I update address information
            | Field      | Value       |
            | First Name | <firstname> |
            | Last Name  | <lastname>  |
            | Email      | <email>     |
            | Company    | <company>   |
            | Country    | <country>   |
            | State      | <state>     |
            | City       | <city>      |
            | Address1   | <address1>  |
            | Address2   | <address2>  |
            | Zipcode    | <zipCode>   |
            | Phone      | <phone>     |
            | Fax        | <fax>       |
        And I click Save new address button
        Then the Add new address page displays error message of "<eFirstName>", "<eLastName>", "<eEmail>", "<eCountry>", "<eCity>", "<eAddress1>", "<eZipCode>", "<ePhone>"
        Examples:
            | Scenario              | firstname | lastname | email            | company   | country  | state | city  | address1 | address2      | zipCode | phone      | fax      | eFirstName              | eLastName              | eEmail             | eCountry            | eCity            | eAddress1                  | eZipCode                      | ePhone            |
            | Empty all fields      |           |          |                  |           |          |       |       |          |               |         |            |          | First name is required. | Last name is required. | Email is required. | Country is required | City is required | Street address is required | Zip / postal code is required | Phone is required |
            | Empty required fields |           |          |                  | WorldLine |          |       |       |          | hung Vuong st |         |            | AIDEN012 | First name is required. | Last name is required. | Email is required. | Country is required | City is required | Street address is required | Zip / postal code is required | Phone is required |
            | Empty first name      |           | Le       | hailpt@gmail.com | WorldLine | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 | First name is required. |                        |                    |                     |                  |                            |                               |                   |
            | Empty last name       | Hai       |          | hailpt@gmail.com | WorldLine | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         | Last name is required. |                    |                     |                  |                            |                               |                   |
            | Empty email           | Hai       | Le       |                  | WorldLine | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        | Email is required. |                     |                  |                            |                               |                   |
            | Empty country         | Hai       | Le       | hailpt@gmail.com | WorldLine |          |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        |                    | Country is required |                  |                            |                               |                   |
            | Empty city            | Hai       | Le       | hailpt@gmail.com | WorldLine | Viet Nam |       |       | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        |                    |                     | City is required |                            |                               |                   |
            | Empty address 1       | Hai       | Le       | hailpt@gmail.com | WorldLine | Viet Nam |       | Hanoi |          | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        |                    |                     |                  | Street address is required |                               |                   |
            | Empty zipcode         | Hai       | Le       | hailpt@gmail.com | WorldLine | Viet Nam |       | Hanoi | ADV st   | hung Vuong st |         | 0192837466 | AIDEN012 |                         |                        |                    |                     |                  |                            | Zip / postal code is required |                   |
            | Empty phone           | Hai       | Le       | hailpt@gmail.com | WorldLine | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  |            | AIDEN012 |                         |                        |                    |                     |                  |                            |                               | Phone is required |
            | Wrong email format    | Hai       | Le       | hailptgmail.com  | WorldLine | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        | Wrong email        |                     |                  |                            |                               |                   |

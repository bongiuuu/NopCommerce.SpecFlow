@AddNewAddress
Feature: Add new address
    As a user, I would like to add new address

    Background: Precondition
        Given I already have an account with information
            | Firstname | Lastname | Email          | Password | ConfirmPassword |
            | Loan      | Nguyen   | loan@gmail.com | 123123   | 123123          |
        And I log in with "loan@gmail.com" and "123123"
        And I am in Add new address page

    @AddNewAddressSuccessfully
    Scenario Outline: Add new address successfully
        When I click Add new address button
        And I fill address information to fields
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
        Then the notification shows a message "The new address has been added successfully."
        And the added address is showed on the page
        Examples:
            | Scenario             | firstname | lastname | email             | company     | country  | state | city     | address1       | address2 | zipCode | phone      | fax    |
            | Full Fields          | Loan      | Nguyen   | loanntb@gmail.com | NashSquared | Viet Nam |       | HCM city | ADV Street     | St.90    | 700000  | 0123456789 | COMO68 |
            | Required fields only | Hai       | Le       | hailpt@gmail.com  |             | Viet Nam |       | Hanoi    | Thai Ha Street |          | 700000  | 0192837465 |        |

    @AddNewAddressUnsuccessfully
    Scenario Outline: Add new address unsuccessfully
        When I click Add new address button
        And I fill address information to fields
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
            | Scenario              | firstname | lastname | email            | company  | country  | state | city  | address1 | address2      | zipCode | phone      | fax      | eFirstName              | eLastName              | eEmail             | eCountry            | eCity            | eAddress1                  | eZipCode                      | ePhone            |
            | Empty all fields      |           |          |                  |          |          |       |       |          |               |         |            |          | First name is required. | Last name is required. | Email is required. | Country is required | City is required | Street address is required | Zip / postal code is required | Phone is required |
            | Empty required fields |           |          |                  | nashtech |          |       |       |          | hung Vuong st |         |            | AIDEN012 | First name is required. | Last name is required. | Email is required. | Country is required | City is required | Street address is required | Zip / postal code is required | Phone is required |
            | Empty first name      |           | Le       | hailpt@gmail.com | nashtech | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 | First name is required. |                        |                    |                     |                  |                            |                               |                   |
            | Empty last name       | Hai       |          | hailpt@gmail.com | nashtech | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         | Last name is required. |                    |                     |                  |                            |                               |                   |
            | Empty email           | Hai       | Le       |                  | nashtech | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        | Email is required. |                     |                  |                            |                               |                   |
            | Empty country         | Hai       | Le       | hailpt@gmail.com | nashtech |          |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        |                    | Country is required |                  |                            |                               |                   |
            | Empty city            | Hai       | Le       | hailpt@gmail.com | nashtech | Viet Nam |       |       | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        |                    |                     | City is required |                            |                               |                   |
            | Empty address 1       | Hai       | Le       | hailpt@gmail.com | nashtech | Viet Nam |       | Hanoi |          | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        |                    |                     |                  | Street address is required |                               |                   |
            | Empty zipcode         | Hai       | Le       | hailpt@gmail.com | nashtech | Viet Nam |       | Hanoi | ADV st   | hung Vuong st |         | 0192837466 | AIDEN012 |                         |                        |                    |                     |                  |                            | Zip / postal code is required |                   |
            | Empty phone           | Hai       | Le       | hailpt@gmail.com | nashtech | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  |            | AIDEN012 |                         |                        |                    |                     |                  |                            |                               | Phone is required |
            | Wrong email format    | Hai       | Le       | hailptgmail.com  | nashtech | Viet Nam |       | Hanoi | ADV st   | hung Vuong st | 700000  | 0192837466 | AIDEN012 |                         |                        | Wrong email        |                     |                  |                            |                               |                   |
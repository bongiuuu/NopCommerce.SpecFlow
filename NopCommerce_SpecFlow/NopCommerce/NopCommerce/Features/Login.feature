@Login
Feature: Login
    As an user, I want to log in to a website

    Background: Prcondition
        Given I already have an account with information
            | Firstname | Lastname | Email          | Password | ConfirmPassword |
            | Loan      | Nguyen   | loan@gmail.com | 123123   | 123123          |
        And I am in Login page

    @LoginSuccessfully
    Scenario: Login successfully
        When I login with email "loan@gmail.com" and password "123123"
        Then I logged in to the website successfully

    @LoginUnsuccessfully
    Scenario Outline: Login unsuccessfully
        When I login with email "<email>" and password "<password>"
        Then the Login page displays error "<message>"

        Examples:
            | Scenario          | email           | password | message                                                                                                |
            | Blank email       |                 | 123123   | Please enter your email                                                                                |
            | Blank password    | loan@gmail.com  |          | Login was unsuccessful. Please correct the errors and try again.The credentials provided are incorrect |
            | Blank all fields  |                 |          | Please enter your email                                                                                |
            | Error email       | loan1@gmail.com | 123123   | Login was unsuccessful. Please correct the errors and try again.No customer account found              |
            | Error password    | loan@gmail.com  | 123124   | Login was unsuccessful. Please correct the errors and try again.The credentials provided are incorrect |
            | Error email form  | loan            | 123123   | Wrong email                                                                                            |
            | Unexisted account | haha@gmail.com  | abcdef   | Login was unsuccessful. Please correct the errors and try again.No customer account found              |
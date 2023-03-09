@ChangePassword
Feature: Change password
    As a user, I want to change my password
    Background:
        Given I already have an account with information
            | Firstname | Lastname | Email          | Password | ConfirmPassword |
            | Loan      | Nguyen   | loan@gmail.com | 123123   | 123123          |
        And I log in with "loan@gmail.com" and "123123"
        And I am in Change Password page

    @ChangePasswordSuccessfully
    Scenario Outline: Change password successfully
        When I change old password "<oldPassword>" with new password "<newPassword>" and confirm password "<newPassword>"
        Then the Change password page displays "Password was changed"

        Examples:
            | oldPassword | newPassword |
            | 123123      | 111111      |
            | 123123      | 000000000   |

    @ChangePasswordSuccessfully @ChangePasswordSuccessfully_LoginWithNewPassword
    Scenario Outline: Change password successfully - login successfully with new password
        When I change old password "<oldPassword>" with new password "<newPassword>" and confirm password "<newPassword>"
        And the Change password page displays "Password was changed"
        And I log in with "loan@gmail.com" and "<newPassword>"
        Then I logged in to the website successfully
        Examples:
            | oldPassword | newPassword  |
            | 123123      | AbCdeF       |
            | 123123      | New password |

    @ChangePasswordSuccessfully @ChangePasswordSuccessfully_LoginWithOldPassword
    Scenario Outline: Change password successfully - login unsuccessfully with old password
        When I change old password "<oldPassword>" with new password "<newPassword>" and confirm password "<newPassword>"
        And the Change password page displays "Password was changed"
        And I log in with "loan@gmail.com" and "<oldPassword>"
        Then the Login page displays error "Login was unsuccessful. Please correct the errors and try again.The credentials provided are incorrect"
        Examples:
            | oldPassword | newPassword  |
            | 123123      | AbCdeF       |
            | 123123      | New password |

    @ChangePasswordUnsuccessfully
    Scenario Outline: Change password unsuccessfully
        When I change old password "<oldPassword>" with new password "<newPassword>" and confirm password "<confirmNewPassword>"
        Then the Change password page displays error message of "<errorOldPassword>", "<errorNewPassword>", "<errorConfirmNewPassword>" or "<errorChangePassword>"

        Examples:
            | Scenario                        | oldPassword   | newPassword | confirmNewPassword | errorOldPassword          | errorNewPassword                                                       | errorConfirmNewPassword                                  | errorChangePassword                                                                                            |
            | Empty all fields                |               |             |                    | Old password is required. | Password is required.                                                  | Password is required.                                    |                                                                                                                |
            | Only spaces all fields          |               |             |                    | Old password is required. | Password is required.                                                  | Password is required.                                    |                                                                                                                |
            | Empty old password              |               | abcdef      | abcdef             | Old password is required. |                                                                        |                                                          |                                                                                                                |
            | Empty new password              | 123123        |             | 000000             |                           | Password is required.                                                  | The new password and confirmation password do not match. |                                                                                                                |
            | Empty confirm password          | 123123        | hailept     |                    |                           |                                                                        | Password is required.                                    |                                                                                                                |
            | Wrong old password              | wrongpassword | hailpt      | hailpt             |                           |                                                                        |                                                          | Old password doesn't match                                                                                     |
            | Invalid new password            | 123123        | 12345       | 12345              |                           | Password must meet the following rules:must have at least 6 characters |                                                          |                                                                                                                |
            | Confirm password does not match | 123123        | abcdef      | hailpt             |                           |                                                                        | The new password and confirmation password do not match. |                                                                                                                |
            | Password unchanged              | 123123        | 123123      | 123123             |                           |                                                                        |                                                          | You entered the password that is the same as one of the last passwords you used. Please create a new password. |
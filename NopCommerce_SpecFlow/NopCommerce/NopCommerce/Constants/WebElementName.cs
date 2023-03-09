namespace NopCommerce.Constants
{
    public static class WebElementName
    {
        public static class UserAddressField
        {
            public static string NoAddress = " No address";
            public static string Table = "Table address";

            // ADDRESS AND USER
            public static string FirstName = "First Name";
            public static string LastName = "Last Name";
            public static string Name = "Name";
            public static string Email = "Email";
            public static string Phone = "Phone";
            public static string Company = "Company";

            // ADDRESS FIELDS AND LABELS
            public static string Fax = "Fax";
            public static string Address1 = "Address 1";
            public static string Address2 = "Address 2";
            public static string Country = "Country";
            public static string City = "City";
            public static string State = "State";
            public static string ZipCode = "ZipCode";
            public static string CityStateZipCode = "City State ZipCode";

            // USER FIELDS AND LABELS
            public static string Day = "Day";
            public static string Month = "Month";
            public static string Year = "Year";
            public static string Password = "Password";
            public static string ConfirmPassword = "Confirm password";

            // ADDRESS ERROR
            public static string ErrorFirstName = "First name error message";
            public static string ErrorLastName = "Last name error message";
            public static string ErrorEmail = "Email error message";
            public static string ErrorCountry = "Country error message";
            public static string ErrorCity = "City error message";
            public static string ErrorAddress1 = "Address 1 error message";
            public static string ErrorZipCode = "ZipCode error message";
            public static string ErrorPhone = "Phone error message";

            // USER ERROR
            public static string ErrorRegister = "Register error message";
            public static string ErrorLogin = "Login Error Message";
            public static string ErrorPassword = "Password error message";
            public static string ErrorPasswordLine1 = "Password error message line 1";
            public static string ErrorPasswordLine2 = "Password error message line 2";
            public static string ErrorConfirmPassword = "Confirm password error message";
            
            // ADDRESS BUTTON
            public static string ButtonAddNew = "Button add new address";
            public static string ButtonEdit = "Button Edit address";
            public static string ButtonDelete = "Button delete address";
            public static string ButtonSave = "Button Save address";

            // USER BUTTON
            public static string RadioButtonGender = "Radio button Gender";
            public static string ButtonRegister = "Button register";
            public static string ButtonLogin = "Button Login";
        }

        public static class ChangePassword
        {
            // INPUT FIELDS
            public static string OldPassword = "Old password";
            public static string NewPassword = "New password";
            public static string ConfirmNewPassword = "Confirm new password";

            // ERROR
            public static string ErrorMessage = "Change password error message";
            public static string ErrorOldPassword = "Old password error message";
            public static string ErrorNewPassword = "New password error message";
            public static string ErrorNewPasswordLine1 =  "New password error line 1 message";
            public static string ErrorNewPasswordLine2 =  "New password error line 2 message";
            public static string ErrorConfirmNewPassword = "Confirm new password error message";

            // BUTTON
            public static string ButtonChangePassword = "Button change password";
        }

        public static class Header
        {
            public static string MyAccount = "My Account link";
            public static string Logout = "Logout link";
            public static string Register = "Register link";
            public static string Login = "Login link";
            public static string ShoppingCart = "Shopping cart link";
            public static string LinkName = @"Link on order {0}";
        }

        public static class CompleteResult 
        {
            public static string Message = "Complete message";
        }

        public static class Notification 
        {
            public static string Message = "Notification message";
        }

        public static class Search 
        {
            public static string AdvancedSearchTable = "Advanced Search";
            // TEXTFIELD AND LABEL
            public static string SearchBox = "Search text box";
            public static string Warning = "Error Warning";
            public static string NoResult = "No result";
            
            // DROPDOWN LIST
            public static string DropdownCategory = "Category";
            public static string DropdownManufacturer = "Manufacturer";
            
            // BUTTON
            public static string CheckboxAdvancedSearch = "Checkbox advanced search";
            public static string SearchDescription = "Checkbox search description";
            public static string SearchSubcategory = "Checkbox search sub categories";
            public static string SearchButton = "Search";
        }

        public static class ProductDetail 
        {
            // TEXTFIELD AND LABEL
            public static string Category = "Category of Product";
            public static string CategoryByOrder = "Category by order {0}";
            public static string Name = "Product name";
            public static string ShortDescription = "Product short description";
            public static string SKU = "Prouct SKU";
            public static string Manufacturer = "Product manufacturer";
            public static string Price = "Product price";
            public static string FullDescription = "Full Description";
            public static string FullDescriptionByOrder = "Full description by order {0}";
            public static string Quantity = "Quantity";

            // BUTTON
            public static string Add = "Add";
            public static string CloseAddSuccessfully = "Close add successfully notification";
        }

        public static class ProductContainer 
        {
            public static string UpdatingContainer = "Update Container: Block";
            public static string NoUpdatingContainer = "Update Container: None";
            public static string DropdownSort = "Sort";
            public static string SortOption = "Sort Option: {0}";
            public static string DropdownPageSize = "Page size";
            public static string ItemProduct = "Item product";
            public static string ProductNameByOrder = "Product name by order: {0}";
            public static string ProductPicByOrder = "Product picture by order: {0}";
            public static string ProductPriceByOrder = "Product price by order: {0}";
        }
    }
}
# Virtual Velocity Banking Application

VVBA is a simple banking application that allows to operate banking tasks and view a history of their transactions. 

## Project Definition

This project attempts to solve the problem of budgeting expenses for the busy everyday professional. We plan to accomplish this though the use of charts and data visualization (A pie chart that shows a % of all expenses split by category over a time period)

## Admin

This project has an active [Trello Board](https://trello.com/b/322c1Wa2).

This project has an active [Figma Page](https://www.figma.com/file/6il3fCmu5tSvtvRl3hgCAY/Banking-Application?node-id=0%3A1).

## Installation and Required Packages

Note the required versions for each of the packages:

```bash
Microsoft.AspNetCore.Mvc.NewtonsoftJson - Version 3.1.9

Microsoft.AspNetCore.SpaServices.Extensions - Version 3.1.9

Microsoft.EntityFrameworkCore.Design - Version 3.1.9

Microsoft.EntityFrameworkCore.SqlServer - Version 3.1.9

Pomelo.EntityFrameworkCore.MySql - Version 3.2.4
```


Connect to XAMPP and ensure you have a MySQL server database active. Update your local database with our prepared seed data using the following command:
```bash
dotnet ef database update
```

Install the lastest npx packages by travelling to the ClientApp folder. 
```bash
cd .\ClientApp
npx install
```

## Entity Relationship Diagram

This diagram outlines the relationships between the various tables in the database. 
[Link to ERD](https://i.imgur.com/W7lWkzs.png)

## Page Flow Diagram

This diagram outlines the expected flow of the user throughout the website.
[Link to Page Flow Diagram](https://i.imgur.com/1vtVDdh.png)


## Application Scope
- [x] User can Login with their email address and password.
- [x] User can Create a new Client.
- [x] User can Create new Accounts.
- [x] User can Create new Transactions:
- [x] User can Create a new 'Deposit' Transaction.
- [x] User can Create a new 'Withdraw' Transaction.
- [x] User can Create a new 'Pay Bills' Transaction.
- [x] User can access a 'Landing' Page with all their Active Accounts and their Account Balances.
- [x] User can access a 'View Transactions' Page which will show their transactions tabulated in table format filtered for a given time period. 
- [x] User can access a 'View Expenses' Page which will show their expenses tabulated in pie chart format filtered for a given time period. 
- [x] User can Close an Account, which will disable the account from being viewed and any associated transactions will be disabled. 

## Challenge Goals (Extended Scope)
- [ ] User can access a 'Contact Us' page.
- [x] User can access a 'FAQs' page.
- [ ] User can access a 'Careers' page.
- [x] User can access a 'Transaction Details' page, which will allow them to view their transactions in a graphical chart format.

## Testing Plan
- This section outlines how to accurately test each Page and identifies what is a valid input for the page and what would cause exceptions. 
### Login Page
- In order to login you must pass a valid email and a valid password. 
- A valid email includes an @ symbol
- A valid password is at least 8 characters long, includes uppercase letters, lowercase letters, numbers, and must have at least one special character. 
### Create Client Page
- In order to create a Client you must pass a valid email, a valid password, a valid phone number, a valid first and last name, a valid date of birth, a valid address, a valid city, a valid province, and a valid postal code. 
- A valid email includes an @ symbol
- A valid password is at least 8 characters long, includes uppercase letters, lowercase letters, numbers, and must have at least one special character. 
- A valid phone number must be only numeric characters, and must be exactly 10 characters long. (Ex. 7805428888, 780-502-8888, 780 502 8888 are all valid entries)
- A valid name (both first and last) is any string of characters that does include numbers.
- A valid address can be any combination of characters with a limit of 150 characters (to give flexibility for unique address locations)
- A valid city is any string of alphabetical characters and cannot include numbers or special characters. 
- Provinces are selected by a drop down list, and no user input is given beyond selecting from a list of valid provinces.
- A valid postal code must be 6 characters in length with alternating alphabetical and numerical characters (Ex. R2W8X5, T8N 1A5 are both valid Postal codes.) NOTE: Entering a US postal code (5 numerical characters) will result in an error. Only Canadian postal codes are valid. 
### Deposit Page
- In order to create a deposit you must pass a valid Account, Source, and Value
- A valid Account is selected from a drop down list of accounts associated with the logged in Client. User input is required to select the account, and if left unselected will cause an exception.
- A valid Source is selected from a drop down list of valid sources. User input is required to select the source, and if left unselected will cause an exception.
- A valid Value is a numerical character. Alphabetical characters or special characters will cause an exception. 
### Withdraw Page
- In order to create a withdraw you must pass a valid Account, Source, and Value
- A valid Account is selected from a drop down list of accounts associated with the logged in Client. User input is required to select the account, and if left unselected will cause an exception.
- A valid Source is selected from a drop down list of valid sources. User input is required to select the source, and if left unselected will cause an exception.
- A valid Value is a numerical character. Alphabetical characters or special characters will cause an exception. 
### Pay Bills Page
- In order to create a deposit you must pass a valid Account, Category, Value, and Date.
- A valid Account is selected from a drop down list of accounts associated with the logged in Client. User input is required to select the account, and if left unselected will cause an exception.
- A valid Category is selected from a drop down list of valid categories. User input is required to select the source, and if left unselected will cause an exception.
- A valid Value is a numerical character. Alphabetical characters or special characters will cause an exception. 
- A valid Date is selected from a date field table. Dates prior to today's date are considered invalid and will cause an exception. 
### Create Account Page
- In order to Create an Account you must pass a valid AccountType. If you already have an account of that type (Trying to open a Chequing account when you have one), an exception will be caused. 
- If you press the Create Account Button without an account selected, an exception will be caused. 
### Close Account Page
- In order to Close an Account you must pass a valid AccountType.
- A valid AccountType is selected from a drop down list of Active Accounts (Acccounts with the property isActive = 1). If you do not have any active accounts, you cannot select anything from this dropdown. 
- If you press the Close Account Button without an account selected, an exception will be caused. 

## Citations Summary

### Random String NPM Package
- Used to generate a random string of characters. Used in TransactionNotification page. 
- https://www.npmjs.com/package/random-string

## License
[MIT](https://choosealicense.com/licenses/mit/)

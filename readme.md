# Virtual Velocity Banking Application

VVBA is a simple banking application that allows to operate banking tasks and view a history of their transactions. 

## Project Definition

This project attempts to solve the problem of budgeting expenses for the busy everyday professional. We plan to accomplish this though the use of charts and data visualization (A pie chart that shows a % of all expenses split by category over a time period)

## Admin

This project has an active [Trello Board](https://trello.com/b/322c1Wa2).

This project has an active [Figma Page](https://www.figma.com/file/6il3fCmu5tSvtvRl3hgCAY/Banking-Application?node-id=0%3A1).

## Installation and Required Packages

Use the NuGet package manager to install the required packages. Note the required versions for each of the packages:

```bash
Microsoft.AspNetCore.Mvc.NewtonsoftJson - Version 3.1.9

Microsoft.AspNetCore.SpaServices.Extensions - Version 3.1.9

Microsoft.EntityFrameworkCore.Design - Version 3.1.9

Microsoft.EntityFrameworkCore.SqlServer - Version 3.1.9

Pomelo.EntityFrameworkCore.MySql - Version 3.2.4
```

Use npm to install axios:
```bash
npm install axios
```
Connect to XAMPP and ensure you have a MySQL server database active. Update your local database with our prepared seed data using the following command:
```bash
dotnet ef database update
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


## License
[MIT](https://choosealicense.com/licenses/mit/)

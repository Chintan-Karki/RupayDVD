# RupayDVD Management System

## Overview
RupayDVD is a comprehensive DVD rental management system built with ASP.NET Web Forms. This enterprise-level application provides a robust solution for managing DVD rentals, member information, and inventory tracking.

## Features
- **User Authentication & Authorization**
  - Secure login system
  - Role-based access control
  - Password management functionality

- **DVD Management**
  - Add and manage DVD details
  - Track DVD copies and availability
  - Search and filter DVD inventory
  - Monitor DVD loan status

- **Member Services**
  - Member registration and management
  - Track member loan history
  - Handle member status (active/inactive)
  - Static member reporting

- **Loan Operations**
  - Issue DVDs to members
  - Process DVD returns
  - Track overdue items
  - Generate loan reports

- **Administrative Functions**
  - Dashboard for system overview
  - Data cleanup and maintenance
  - System configuration management
  - User activity monitoring

## Technologies Used
- **Backend Framework**
  - ASP.NET Web Forms (.NET Framework 4.7.2)
  - C# Programming Language
  - ADO.NET for data access

- **Frontend Technologies**
  - HTML5/CSS3
  - JavaScript
  - jQuery 3.3.1
  - Bootstrap 4.1.0
  - Font Awesome 5.0.13

- **Database**
  - Microsoft SQL Server Express
  - SQL Server Management Studio

- **Development Tools**
  - Visual Studio 2017/2019
  - Microsoft.CodeDom.Providers.DotNetCompilerPlatform 2.0.1
  - Roslyn Compiler Platform

## Project Structure

```
RupayDVD/
├── Master/                     # Master page templates and styling
│   ├── Site1.Master           # Main layout template with navigation
│   ├── MasterPageStyle.css    # Master page styling
│   └── SignInStyles.css       # Authentication pages styling
│
├── Models/                     # Business logic and data models
│   ├── DatabaseController.cs  # Database operations handler
│   ├── ResponseWrite.cs       # Response handling utilities
│   └── User.cs               # User model and authentication
│
├── View/                      # ASP.NET Web Forms pages
│   ├── Authentication/
│   │   ├── signin.aspx       # User login
│   │   ├── Signout.aspx     # User logout
│   │   └── Password.aspx     # Password management
│   │
│   ├── DVD Management/
│   │   ├── AddADvd.aspx     # Add new DVDs
│   │   ├── DvdDetails.aspx  # View/edit DVD details
│   │   ├── DvdCopies.aspx   # Manage DVD copies
│   │   └── SearchADvd.aspx  # Search functionality
│   │
│   ├── Loan Management/
│   │   ├── IssueADvd.aspx   # Issue DVDs to members
│   │   ├── ReturnADvd.aspx  # Process returns
│   │   ├── DvdOnLoan.aspx   # View loaned DVDs
│   │   └── LoanedDvd.aspx   # Loan history
│   │
│   └── Administration/
│       ├── AdminPage.aspx    # Admin dashboard
│       ├── DeleteOldData.aspx # Data cleanup
│       └── StaticMembers.aspx # Member statistics
│
├── App_Data/                  # Application data storage
├── Properties/                # Assembly information
├── Web.config                # Application configuration
└── Global.asax              # Application lifecycle events
```

## Setup and Installation

### Prerequisites
- Visual Studio 2017/2019
- .NET Framework 4.7.2
- SQL Server Express
- IIS Express (included with Visual Studio)

### Database Setup
1. Open SQL Server Management Studio
2. Create a new database named 'GroupCourseWork'
3. Update connection string in Web.config if needed:
```xml
<connectionStrings>
    <add name="MyConnection" 
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=GroupCourseWork;Integrated Security=TRUE" 
         providerName="System.Data.SqlClient"/>
</connectionStrings>
```

### Build and Run
1. Clone the repository
2. Open RupayDVD.sln in Visual Studio
3. Restore NuGet packages
4. Build the solution (Ctrl + Shift + B)
5. Run using IIS Express (F5)

## Development Guidelines
- Follow C# coding conventions
- Use master page (Site1.Master) for consistent layout
- Place business logic in Models folder
- Keep UI code in View folder
- Use DatabaseController for database operations
- Implement proper error handling using ResponseWrite

## Security Features
- Windows Authentication
- Role-based access control
- Secure password management
- SQL injection prevention
- Session management

## Contributing
1. Fork the repository
2. Create a feature branch
3. Commit changes
4. Push to the branch
5. Create a Pull Request

## Version
Current Version: 1.0.0.0

## License
Copyright © 2022. All rights reserved.
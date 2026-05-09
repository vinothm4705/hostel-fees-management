# Hostel Fees Management System

A web-based admin application built with ASP.NET WebForms and SQL Server
to manage and calculate hostel fees for students.

## Features

- Calculate hostel fees based on room type, mess charges, and electricity charges
- Automatic 5% service charge applied on subtotal
- Full CRUD operations — Add, View, Edit, and Delete student fee records
- GridView display for all hostel fee records
- SQL Server database integration using ADO.NET

## Fee Structure

| Component | Amount |
|---|---|
| Single Room | ₹4,000/month |
| Double Sharing | ₹3,000/month |
| Triple Sharing | ₹2,500/month |
| Mess Charges | ₹2,000/month |
| Electricity Charges | ₹500/month |
| Service Charge | 5% of subtotal |

## Technologies Used

- ASP.NET WebForms (C#)
- SQL Server
- ADO.NET
- HTML
- CSS
- jQuery

## Project Structure
WebApplication2/
│
├── WebApplication2.sln              ← Open this in Visual Studio to run the project
│
└── WebApplication2/                 ← Main project folder
│
├── WebForm1.aspx                ← Main UI page (frontend of hostel fees management)
├── WebForm1.aspx.cs             ← Main logic (backend of hostel fees management — C# CRUD operations)
├── WebForm1.aspx.designer.cs    ← Auto-generated UI connections
│
├── Web.config                   ← Database connection settings
├── Default.aspx                 ← Home/landing page
├── Site.Master                  ← Master layout/template
├── Global.asax                  ← Application startup file
│
├── Account/                     ← Login & registration pages
│   ├── Login.aspx               ← Login page
│   ├── Register.aspx            ← Register page
│   └── ChangePassword.aspx      ← Password change page
│
├── Styles/
│   └── Site.css                 ← Stylesheet
│
└── Scripts/
└── jquery-1.4.1.js          ← jQuery library

## Project Setup

1. Install Visual Studio with ASP.NET support
2. Install SQL Server Express
3. Clone this repository
4. Open `WebApplication2.sln` in Visual Studio
5. Create a database named `Database1` in SQL Server
6. Create the `HostelFees` table with these columns:
   - StudentID
   - StudentName
   - RoomType
   - MonthsStayed
   - RoomCharges
   - MessCharges
   - ElectricityCharges
   - Subtotal
   - ServiceCharge
   - TotalFee
7. Update the connection string in `Web.config` if needed
8. Run the project in Visual Studio

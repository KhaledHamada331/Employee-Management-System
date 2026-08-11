
# Employee Management System

A **project-based learning and practice project** built with C# to apply
Object-Oriented Programming (OOP), Collections, interfaces, inheritance,
abstraction, exception handling, and basic problem-solving concepts.

> **Important:** This is an **educational and practical training
> project**, not a production-ready employee management system.\
> The goal is to learn and practice C# and Collections by building a
> small application from scratch.

------------------------------------------------------------------------

## 📚 Project Purpose

This project was created as part of a project-based learning approach.

Instead of studying C# Collections and OOP concepts separately, the
concepts are applied together in a small console application.

The project focuses especially on:

-   `List<T>`
-   `Dictionary<TKey, TValue>`
-   `Queue<T>`
-   `Stack<T>`
-   Abstract classes
-   Inheritance
-   Polymorphism
-   Encapsulation
-   Exception handling
-   Input validation
-   Basic separation between models and services
-   Git and GitHub workflow

The project intentionally uses different collection types according to
the behavior required by each feature.

------------------------------------------------------------------------

# 🎯 Learning Objectives

The main objectives of this project are to practice:

### C# Fundamentals

-   Classes and objects
-   Properties
-   Methods
-   Constructors
-   Access modifiers
-   `static` members
-   Constants
-   Nullable references
-   String handling
-   Parsing user input

### Object-Oriented Programming

-   Abstraction
-   Inheritance
-   Polymorphism
-   Encapsulation
-   Method overriding

### Collections

  Collection                   Usage in the Project
  ---------------------------- -------------------------------------------
  `List<T>`                    Storing active employees
  `Dictionary<TKey, TValue>`   Storing departments by ID
  `Queue<T>`                   Managing employees waiting for onboarding
  `Stack<T>`                   Maintaining action history
  `HashSet<T>`                 Storing unique company skills

This is one of the main reasons for building the project: to understand
**why and when different collections should be used**, rather than
simply memorizing their syntax.

------------------------------------------------------------------------

# 🏗️ Project Structure

The project is organized into models, services, and the console entry
point.

``` text
EmployeeManagementSystem/
│
├── Models/
│   ├── Employee.cs
│   ├── Department.cs
│   └── Manager.cs
│
├── Services/
│   └── Company.cs
│
├── Program.cs
│
└── EmployeeManagementSystem.csproj
```

The exact structure may evolve as the project develops.

------------------------------------------------------------------------

# 🧩 Main Components

## Employee

Represents an employee in the company.

An employee contains information such as:

-   ID
-   Name
-   Salary
-   Department ID
-   HireDate

Employees initially enter the onboarding queue and can later become
active employees.

------------------------------------------------------------------------

## Department

Represents a company department.

A department contains:

-   ID
-   Name

Departments are stored using a `Dictionary<int, Department>` so that
they can be retrieved efficiently by ID.
------------------------------------------------------------------------

## Manager


A department contains:

-   ID
-   Name
-   Salary
-   Department ID
-   HireDate



------------------------------------------------------------------------

## Company

The `Company` class acts as the main service/business component of the
application.

It manages:

-   Employees
-   Departments
-   Onboarding
-   Company skills
-   Action history
-   Searching
-   Salary calculations
-   Department-based queries

It also performs validation before modifying the collections.

------------------------------------------------------------------------

# 📦 Collections in Detail

## 1. List`<Employee>`

Active employees are stored in a list.

``` csharp
List<Employee> activeEmployees;
```

A list is useful here because the application needs to:

-   Add active employees
-   Iterate through employees
-   Search/filter employees
-   Calculate statistics

------------------------------------------------------------------------

## 2. Dictionary\<int, Department\>

Departments are stored using their IDs as keys.

``` csharp
Dictionary<int, Department> departments;
```

Example:

``` text
1 → IT
2 → HR
3 → Finance
```

This allows the application to quickly check whether a department exists
and retrieve it by ID.

------------------------------------------------------------------------

## 3. Queue`<Employee>`

Employees waiting for onboarding are stored in a queue.

``` csharp
Queue<Employee> onboarding;
```

The queue follows **FIFO**:

> First In, First Out

For example:

``` text
Khaled → Ahmed → Sara → Omar
   ↓
First employee to complete onboarding
```

When onboarding is completed:

``` csharp
var employee = onboarding.Dequeue();
activeEmployees.Add(employee);
```

This is a practical example of using a Queue rather than simply choosing
a collection arbitrarily.

------------------------------------------------------------------------

## 4. Stack`<string>`

The application keeps track of actions using a stack.

``` csharp
Stack<string> actionHistory;
```

A stack follows **LIFO**:

> Last In, First Out

Every important action can be pushed into the stack:

``` csharp
actionHistory.Push($"Added Skill: {skill}");
```

The history can then be displayed starting from the most recent action.

A temporary stack was also experimented with while learning how stack
ordering works.

------------------------------------------------------------------------

## 5. HashSet`<string>`

Company skills are stored using a `HashSet<string>`.

``` csharp
HashSet<string> companySkills;
```

This is useful because company skills should be unique.

For example:

``` text
C#
SQL
ASP.NET Core
```

Adding `C#` again should not create a duplicate.

The implementation uses:

``` csharp
companySkills.Add(skill.ToLowerInvariant())
```

so that skill comparison can be handled consistently.

------------------------------------------------------------------------

# 🔢 ID Generation

IDs are generated by the `Company` class rather than being manually
assigned from `Program.cs`.

For example:

``` csharp
employee.Id = ++employeeId;
```

and:

``` csharp
department.Id = ++departmentId;
```

The important design idea is that ID generation belongs to the component
responsible for managing the entities.

This also keeps `Program.cs` focused on user interaction rather than
internal entity management.

------------------------------------------------------------------------

# 🖥️ Console Interface

The application provides a simple interactive console menu.

``` text
Employee Management System

1. Add Employee
2. Complete Onboarding
3. Add Department
4. Get Employee Details
5. Get Employees Salary Average
6. Get Employees Count by Department
7. Get Employees by Department
8. Add New Skill
9. Get Company Skills
10. Get Action History
0. Exit
```

The user selects an operation and enters the required information.

------------------------------------------------------------------------

# ✨ Features

## Add Employee

The user can add an employee by entering:

-   Name
-   Salary
-   Department ID

The employee is then added to the onboarding queue.

------------------------------------------------------------------------

## Complete Onboarding

Moves the first employee from the onboarding queue to the active
employees collection.

This demonstrates the behavior of a `Queue<T>`.

------------------------------------------------------------------------

## Add Department

Creates a new department and stores it in the department dictionary.

------------------------------------------------------------------------

## Get Employee Details

Employees can be searched using:

-   Employee ID
-   Employee name

The employee's information is then displayed.

------------------------------------------------------------------------

## Calculate Average Salary

Calculates the average salary of active employees.

Example:

``` text
Average Salary of Employees: $9,600.00
```

The feature provides practice with collection operations.

------------------------------------------------------------------------

## Get Employee Count by Department

Displays the number of employees belonging to each department.


------------------------------------------------------------------------

## Get Employees by Department

Retrieves employees belonging to a specific department.

The user provides the department ID, and the matching employees are
displayed.

------------------------------------------------------------------------

## Add Company Skill

Adds a new skill to the company.

Duplicate skills are rejected.

------------------------------------------------------------------------

## Get Company Skills

Displays all skills currently registered for the company.

------------------------------------------------------------------------

## Get Action History

Displays the actions performed by the user.

The history is maintained using a `Stack<string>`.

------------------------------------------------------------------------

# 🌱 Seed Data

The project contains optional seed data for easier testing and
demonstration.

The seed data creates example:

### Departments

-   IT
-   HR
-   Finance

### Employees

-   Khaled
-   Ahmed
-   Sara
-   Omar
-   Mona

### Skills

-   C#
-   SQL
-   ASP.NET Core

The seeded employees are also processed through onboarding.

The seed data exists purely to make testing the application easier. It
does not represent real company data.

------------------------------------------------------------------------

# 🛡️ Validation and Error Handling

The project includes basic validation for user input and business rules.

Examples include:

-   Invalid employee name
-   Invalid salary
-   Invalid department ID
-   Invalid department name
-   Invalid skill
-   Duplicate skills
-   Searching for a non-existing employee
-   Searching for a non-existing department
-   Empty onboarding queue

The console application also uses exception handling where appropriate:

``` csharp
try
{
    // operation
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

------------------------------------------------------------------------

# 🔍 Search and Querying

The project includes employee searching and collection-based queries.

Examples:

``` text
Get employee by ID
Get employee by name
Get employees by department
Calculate average salary
Count employees by department
```

These operations provide practical exercises with collection
manipulation.

------------------------------------------------------------------------

# 🧠 Design Decisions

The project intentionally uses different collections based on the
behavior required.

For example:

### Why Queue for onboarding?

Because onboarding should follow:

``` text
First employee added
        ↓
First employee processed
```

### Why Stack for action history?

Because the most recent action should be displayed first.

### Why Dictionary for departments?

Because departments are naturally identified by an ID and can be
retrieved using that ID.

### Why HashSet for skills?

Because duplicate skills should not be stored.

### Why List for active employees?

Because the application frequently iterates over and queries active
employees.

The goal is not just to make the application work, but to understand the
reasoning behind choosing each collection.

------------------------------------------------------------------------

# 🧪 Testing the Application

Run the application and use the console menu to test each operation.

A typical testing sequence can be:

``` text
1. Add Department
2. Add Employee
3. Add Employee
4. Complete Onboarding
5. Get Employee Details
6. Get Employees by Department
7. Calculate Average Salary
8. Add Skill
9. Get Company Skills
10. Get Action History
```

Seed data can also be used to start with an already populated company.

------------------------------------------------------------------------

# 🚀 Running the Project

## Requirements

-   .NET SDK
-   Visual Studio, Visual Studio Code, or JetBrains Rider
-   Basic knowledge of C#

## Run

From the project directory:

``` bash
dotnet run
```

------------------------------------------------------------------------

# 🌿 Git Workflow

Git and GitHub are also part of the learning process.

The project is developed using feature-based branches rather than doing
all development directly on `main`.

Examples of branches used during development:

``` text
feature/add-employee
feature/add-department
feature/add-skill
feature/employee-search
feature/get-employee-department
feature/calculate-average-salary
feature/display-action-history
feature/display-company-skills
feature/employee-count-by-department
feature/console-interface
refactor/company-id-generation
```

The general workflow is:

``` text
Create branch
     ↓
Implement feature
     ↓
Test feature
     ↓
Commit changes
     ↓
Push branch
     ↓
Create Pull Request
     ↓
Merge into main
```

This project is also being used to practice writing meaningful commit
messages and organizing changes into logical pull requests.

------------------------------------------------------------------------

# 📝 Commit Convention

Commits generally follow a simple convention such as:

``` text
feat: add employee management
feat: add company skill management
feat: add employee search
fix: validate employee salary
refactor: add ID generation to company
```

The purpose is to keep the project history understandable and organized.

------------------------------------------------------------------------

# 📌 Educational Scope

This project deliberately does **not** try to solve all the problems of
a real employee management system.

It does not currently focus on:

-   Databases
-   Authentication
-   Authorization
-   APIs
-   Web UI
-   Multi-user access
-   Persistence
-   Production security
-   Distributed systems
-   Deployment
-   Real company workflows

Those concerns are outside the main learning objective.

The application is primarily a **C# console application for practicing
OOP and Collections**.

------------------------------------------------------------------------

# 🎓 What This Project Demonstrates

By completing this project, the main concepts practiced include:

-   C# syntax and fundamentals
-   Classes and objects
-   Properties and methods
-   Abstraction
-   Inheritance
-   Interfaces
-   Polymorphism
-   Collections
-   `List<T>`
-   `Dictionary<TKey,TValue>`
-   `Queue<T>`
-   `Stack<T>`
-   `HashSet<T>`
-   Input validation
-   Exception handling
-   Basic service organization
-   Git branching
-   Commits
-   Pull Requests
-   Seed data
-   Console application design

------------------------------------------------------------------------

# 🔮 Possible Future Improvements

Possible future exercises include:

-   Refactoring large methods in `Program.cs`
-   Moving console input/output into dedicated components
-   Adding more employee operations
-   Adding employee removal
-   Adding employee transfer between departments
-   Adding more advanced LINQ queries
-   Improving validation
-   Adding unit tests
-   Adding more collection-based exercises
-   Comparing different collection implementations
-   Measuring the performance characteristics of different approaches

These are optional learning extensions rather than requirements for the
current project.

------------------------------------------------------------------------

# 📖 Final Note

This repository represents a **learning journey**, not a finished
commercial product.

The application was built incrementally, feature by feature, with the
goal of turning theoretical C# concepts into practical code.

The most important part of the project is not the final console
application itself, but understanding:

> **Which concept should I use, why should I use it, and what behavior
> does it give me?**

That is the main purpose of this project.

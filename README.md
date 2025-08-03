# Library Management System

This is my first ever Real C# Project.

A **console-based Library Management System** written in **C#**, demonstrating core OOP concepts, exception handling, and collection management.  
Manage members and books, perform borrow/return operations, and enforce input validation.

---

## ⚙️ Features

1. **Member Management**  
   - Add / Remove / List library members  
   - Each `Member` has a **Name**, **Type** (e.g. Student, Teacher) and a list of borrowed books  

2. **Book Management**  
   - Add / Remove / List books in the library  
   - Each `Book` has a **Title**, **Author**, **Page count**, and tracks its borrowed status  

3. **Borrow & Return**  
   - Members can borrow available books  
   - Members can return borrowed books  
   - Membership & book availability checks  

4. **Robust Validation**  
   - String fields (`Name`, `Type`, `Title`, `Author`) are never null or empty  
   - Page count must be non-negative  
   - Invalid inputs throw and catch appropriate exceptions  

5. **Console-Driven Menu**  
   - Simple numeric menu loop  
   - Input parsing with `int.TryParse` and range checks  

---

# Finance Manager

**Finance Manager** is a high-performance, cross-platform financial application built with **.NET 10** and **Blazor**. It is designed to provide professional-grade control over personal finances, with a specialized focus on tracking **loans made to third parties**.

By leveraging **Blazor Hybrid** and **WebAssembly**, this project shares 95%+ of its UI and business logic across web, mobile, and desktop environments.

## 🚀 Supported Platforms

Built on the cutting edge of **.NET 10**, this application targets:

* **Web:** High-performance SPA using **Blazor WebAssembly**.
* **Mobile:** Native **Android** app via **.NET MAUI Blazor Hybrid**.
* **Desktop:** Native binaries for **Windows** (WinUI 3) and **Linux** (.deb via MAUI/Photino).

## ✨ Key Features

* **Expense Tracking:** Advanced categorization and real-time monitoring of personal spending.
* **Loan Management:** A dedicated system for money lent to others. Track borrowers, interest (optional), due dates, and repayment status.
* **Offline-First & Sync:** Local persistence using **Entity Framework Core** with background synchronization to a centralized API.
* **Unified Dashboard:** A consolidated view of available balance plus outstanding receivables (loans to be collected).

## 🛠 Tech Stack

* **Framework:** .NET 10
* **UI:** Blazor (Razor Components)
* **Database:** SQLite via **Entity Framework Core**
* **Communication:** HttpClient / Refit for REST API interaction

## 🏗 Architecture (CQRS)

This project implements the **CQRS (Command Query Responsibility Segregation)** pattern to ensure a clear separation between data display and financial transactions, providing a robust audit trail and conflict-free synchronization.

## 📦 Getting Started

### Prerequisites

* .NET 10 SDK
* Visual Studio 2022 (v17.12+), VS Code with C# Dev Kit or JetBrains Rider

### Installation

1. Clone the repository:
```bash
git clone https://github.com/elitonluiz1989/finance-manager.git

```


2. Navigate to the solution folder:
```bash
cd finance-manager

```


3. Restore and build:
```bash
dotnet restore
dotnet build

```



---

*Developed with the power of .NET 10.*

---
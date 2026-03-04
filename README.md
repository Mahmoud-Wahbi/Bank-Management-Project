# 🏦 Integrated Bank Management System (IBMS)

An advanced, enterprise-level desktop application designed to streamline banking operations. Built with a robust Layered Architecture and featuring an AI-powered assistant, this system ensures secure, efficient, and scalable financial management.

---

## 🌟 Key Features

### Comprehensive Management

* Full CRUD operations for clients, users, and personnel
* Granular permission control

### Secure Transactions

* Execute deposits, withdrawals, and transfers
* Real-time balance validation
* Automated fee calculation

### AI Smart Assistant

* Integrated Gemini Pro API ChatBot
* Handles banking inquiries
* Provides real-time currency/crypto exchange rates

### Multi-Currency Support

* Automated currency conversion using live exchange rate APIs

### Financial Analytics

* Dynamic dashboards
* Charts for balance distribution
* Top-tier client analytics

### Audit Logging

* Detailed transaction and transfer logs
* Transparency and security auditing

---

## 🏗 System Architecture

The project follows a **Three-Tier (Layered) Architecture** to ensure *Separation of Concerns* and high maintainability:

### User Interface (UI)

* Modern and responsive GUI
* Built with WinForms and Guna UI Framework

### Business Logic Layer (BLL)

* Handles calculations
* Validation rules
* AI service integrations

### Data Access Layer (DAL)

* Direct communication with SQL Server
* Uses ADO.NET and stored procedures

---

## 🛠 Tech Stack

* **Language:** C# (.NET Framework)
* **Database:** Microsoft SQL Server
* **UI Components:** Guna UI Framework
* **AI Integration:** Google Gemini Pro API
* **External APIs:** Real-time Exchange Rate APIs

---

## 📸 Screen Previews

<img width="1339" height="752" alt="Bank Dashboard" src="https://github.com/user-attachments/assets/48685812-719c-4568-936e-1b13daaf1c3f" />

<img width="1340" height="753" alt="Total Balances" src="https://github.com/user-attachments/assets/6b4beae2-434c-430a-82ac-fc870ff1f6c2" />
<img width="1344" height="765" alt="FIND CLIENT" src="https://github.com/user-attachments/assets/c0c33f5e-576b-416b-b304-51d4aec42a54" />
<img width="1343" height="758" alt="LIST CLIENTS" src="https://github.com/user-attachments/assets/6bca597a-874a-4dd1-a3ea-b42d2945bb1b" />
<img width="2856" height="849" alt="Bank System Reletional schema مخطط البنك" src="https://github.com/user-attachments/assets/c036dc69-1f0f-4c9e-95be-6917c88dea52" />
---

## 🚀 Getting Started

### Prerequisites

* Visual Studio 2022 or later
* SQL Server Management Studio (SSMS)
* .NET Framework 4.7.2+

### Installation

#### 1️⃣ Clone the Repo

```bash
git clone https://github.com/Relax-2001/Bank-Management-Project.git
```

#### 2️⃣ Setup Database

Execute the provided SQL script in the `Database/` folder to generate tables and stored procedures.

#### 3️⃣ Configure Connection

Update the connection string in the DataAccessLayer or `App.config`.

#### 4️⃣ Run

Open the `.sln` file in Visual Studio and press **F5**.

---

## 📜 Future Roadmap

* [ ] Developing a Web/Mobile version
* [ ] Implementing Two-Factor Authentication (2FA)
* [ ] Extending AI capabilities to perform direct transactions

---

## 👨‍💻 Author

**Mahmoud Wahbi**

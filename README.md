🏦 Integrated Bank Management System (IBMS)
An advanced, enterprise-level desktop application designed to streamline banking operations. Built with a robust Layered Architecture and featuring an AI-powered assistant, this system ensures secure, efficient, and scalable financial management.
🌟 Key Features
•	Comprehensive Management: Full CRUD operations for clients, users, and personnel with granular permission control.
•	Secure Transactions: Execute deposits, withdrawals, and transfers with real-time balance validation and automated fee calculation.
•	AI Smart Assistant: Integrated Gemini Pro API ChatBot to handle banking inquiries and real-time currency/crypto exchange rates.
•	Multi-Currency Support: Automated currency conversion using live exchange rate APIs.
•	Financial Analytics: Dynamic dashboards featuring charts for balance distribution and top-tier client analytics.
•	Audit Logging: Detailed transaction and transfer logs for transparency and security auditing.
🏗 System Architecture
The project follows a Three-Tier (Layered) Architecture to ensure "Separation of Concerns" and high maintainability:
1.	User Interface (UI): Modern and responsive GUI built with WinForms and Guna UI Framework.
2.	Business Logic Layer (BLL): Handles all calculations, validation rules, and AI service integrations.
3.	Data Access Layer (DAL): Manages direct communication with SQL Server using ADO.NET and stored procedures.
🛠 Tech Stack
•	Language: C# (.NET Framework) 
•	Database: Microsoft SQL Server 
•	UI Components: Guna UI Framework 
•	AI Integration: Google Gemini Pro API 
•	External APIs: Real-time Exchange Rate APIs 
📸 Screen Previews
<img width="1339" height="752" alt="Bank Dashboard" src="https://github.com/user-attachments/assets/4384bef2-ba55-46fc-abbb-828cc935e78b" />
<img width="1342" height="755" alt="Transfer Form" src="https://github.com/user-attachments/assets/3b8c3f18-1259-4031-9293-d2e12921bc78" />
<img width="1340" height="754" alt="Transfer Form2" src="https://github.com/user-attachments/assets/709191bc-4a2d-41b8-999d-7cb15e803dea" />
<img width="1340" height="753" alt="Total Balances" src="https://github.com/user-attachments/assets/59923011-0812-40f4-811c-b22f408ebc91" />
•	AI ChatBot: Interactive terminal for financial assistance.
🚀 Getting Started
Prerequisites
•	Visual Studio 2022 or later.
•	SQL Server Management Studio (SSMS).
•	.NET Framework 4.7.2+.
Installation
1.	Clone the Repo:
Bash
git clone https://github.com/Relax-2001/Bank-Management-Project.git
2.	Setup Database: Execute the provided SQL script in the Database/ folder to generate tables and stored procedures.
3.	Configure Connection: Update the connection string in the DataAccessLayer or App.config.
4.	Run: Open the .sln file in Visual Studio and press F5.
📜 Future Roadmap![Uploading Bank Dashboard.png…]()

•	[ ] Developing a Web version.
•	[ ] Implementing Two-Factor Authentication (2FA).
•	[ ] Extending AI capabilities to perform direct transactions.
👨‍💻 Author
Mahmoud Wahbi


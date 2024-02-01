# Queue Management System
TOOLS AND TECHNOLOGIES USED
- ASP.NET Core
- PostgreSQL
- FastReport.Net
- Npgsq

The system has the following pages:
1. Check-In page. This page allow customers to select the kind of service they're receiving. It has these fetures:
   - Texts are descriptive.
   - Buttons are large enough.
   - Ability to print tickets. Design the ticket using FastReport.Net.
2. Waiting page. This page simply display the called customer's ticket number and the service point they should head to.
3. Service point. This page allows the service provider to:
   - Authenticate and select their service point.
   - Get next number.
   - Recall number.
   - Mark number as no show.
   - Mark number as finished.
   - Transfer number.
   - View their queue.
4. Admin dashboard. This page allows the system admin to perform these tasks:
   - Configure service points.
   - Configure service providers.
   - Generate Analytical reports.

# Gumani_AAPD7112w_POE

A Windows Forms application designed to streamline municipal service tracking, issue reporting, and local event management.

---

##  Getting Started

Follow these instructions to set up and run the application on your local machine for development and testing.

### Prerequisites

Before you begin, ensure you have the following installed:
* **Visual Studio** (2022 or later recommended) with the **.NET Desktop Development** workload.
* **.NET Framework** matching the project configuration.

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/gumani-38/Gumani_AAPD7112w_POE.git
   ```

2. **Navigate to the project directory:**
   ```bash
   cd Gumani_AAPD7112w_POE
   ```

3. **Open the solution:**
   * Open Visual Studio.
   * Choose **Open a project or solution**.
   * Select the `Gumani_AAPD7112w_POE.slnx` or `.csproj` file.

4. **Restore NuGet Packages:**
   * In Visual Studio, go to **Tools** > **NuGet Package Manager** > **Package Manager Console**.
   * Run the following command to restore packages:
     ```powershell
     Update-Package -reinstall
     ```

### Run the Application

1. Set the build configuration to `Debug` or `Release`.
2. Press **F5** or click the **Start** button in Visual Studio to compile and launch the application interface.

---

## Application Navigation Guide

The application uses a centralized **Main Menu** window as its core dashboard. Follow these instructions to interact with the different administrative modules:

### 1. Main Dashboard Functions
* **Select Menu Dropdown:** Click the menu toggle element in the upper-left section of the dashboard form to open the primary service navigation listing.
* **Language Selection:** Use the dropdown element on the top-right side of the form to change the displayed interface language dynamically.
* **Suggestion/Feedback Button:** Click the dedicated blue button located at the bottom-right corner to open submission forms for leaving user recommendations.

### 2. Available Feature Modules
From the **Select Menu** listing, you can load three main windows:
* **Report Issues:** Open this interface to log a new service failure, attach media references, choose categories, and track basic descriptions.
* **Local Events and Announcements:** Load this panel to view general announcements, find event cards, search by dates, or trigger tailored recommendation criteria based on search habits.
* **Service Request Status:** Select this view to inspect logged requests and evaluate service graph dependencies using the status tracking systems.



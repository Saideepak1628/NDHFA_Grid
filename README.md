# NDHFA_Grid (CSV Grid Viewer)

This is a simple CSV Grid Viewer application built as part of the coding test.

## 📌 Overview
- The application reads values from a **CSV file** (`data.csv`).
- It displays them in a **grid (CollectionView)**.
- When the user **selects a row**, a popup dialog shows the values from that row.
- Any errors during execution are logged into a file named `error_log.txt` on the **Desktop**.

## ⚡ Why .NET MAUI instead of WinForms?
The original test instructions mentioned **WinForms or comparable application**.  
Since **WinForms is Windows-only**, and I am developing on macOS, I chose **.NET MAUI** with **Mac Catalyst**.  
This allows the same functionality with a cross-platform UI while meeting the requirements.

## 🔹 Features Implemented
1. **CSV Reader**  
   - Loads rows from `data.csv`.  
   - If the file does not exist, a sample CSV file is created automatically.

2. **Grid Display**  
   - Data is displayed in a `CollectionView` with three columns (`Col1`, `Col2`, `Col3`).

3. **Popup on Selection**  
   - When the user selects a row, the selected values are displayed in a popup alert.

4. **Error Logging**  
   - Any exceptions are logged to `~/Desktop/error_log.txt` with a timestamp.

##  Tech Stack
- **Language:** C# (.NET 8)  
- **Framework:** .NET MAUI (Mac Catalyst target)  
- **IDE:** Visual Studio 2022 for Mac  

##  How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/Saideepak1628/NDHFA_Grid.git
   cd NDHFA_Grid

# Weather Data Application

This project is a full-stack application that fetches weather data from a public API, stores it in a SQL database, and displays it on a React frontend with charts. The application periodically updates the weather data every minute.

## Technologies Used

- **Backend**: ASP.NET Core MVC, C#
- **Frontend**: React, JavaScript
- **Database**: SQL Server, Entity Framework Core
- **Charts**: `react-chartjs-2`, Chart.js
- **HTTP Client**: Axios

## Features

- Fetch weather data from a public API for multiple cities in different countries.
- Store weather data in a SQL database.
- Periodically update weather data every minute.
- Display min and max temperatures with the last update time in graphs using React and Chart.js.

### Project Structure

- **Backend**: ASP.NET Core MVC
  - `Controllers/WeatherController.cs`: API endpoints for fetching weather data.
  - `Data/WeatherDbContext.cs`: Entity Framework Core DbContext for weather data.
  - `Models/WeatherData.cs`: Weather data model.
  - `Services/WeatherService.cs`: Service for fetching weather data from the API.
  - `Services/WeatherUpdateService.cs`: Background service for periodic data updates.

- **Frontend**: React
  - `src/components/WeatherChart.jsx`: React component for displaying weather data in charts.
  - `src/components/WeatherChart.css`: CSS for styling the weather charts.
  - `src/index.css`: Global styles for the React application.
  - `src/App.css`: Styles for the main application container.

### Usage

- The application fetches weather data for multiple cities and stores it in the database.
- The data is updated every minute by the background service.
- The frontend displays min and max temperatures along with the last update time in graphs.

### Screenshots

![image](https://github.com/user-attachments/assets/958cb0a5-ea0c-4e65-b76d-4010ef3835c0)

![image](https://github.com/user-attachments/assets/da5723f8-a7de-4a16-b975-4ce2d0952e12)





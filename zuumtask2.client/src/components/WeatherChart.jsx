import React, { useEffect, useState } from 'react';
import { Line } from 'react-chartjs-2';
import axios from 'axios';
import 'chart.js/auto';
import './WeatherChart.css';

axios.defaults.baseURL = 'https://localhost:5266'; // Ensure this matches your backend URL

const WeatherChart = () => {
    const [weatherData, setWeatherData] = useState({});

    useEffect(() => {
        axios.get('/api/weather/history')
            .then(response => {
                if (Array.isArray(response.data)) {
                    // Group data by city
                    const groupedData = response.data.reduce((acc, item) => {
                        const cityKey = `${item.country}/${item.city}`;
                        if (!acc[cityKey]) {
                            acc[cityKey] = [];
                        }
                        acc[cityKey].push(item);
                        return acc;
                    }, {});
                    setWeatherData(groupedData);
                } else {
                    console.error("Unexpected response format:", response.data);
                }
            })
            .catch(error => {
                console.error("Error fetching weather data:", error);
                if (error.response) {
                    console.error("Response data:", error.response.data);
                    console.error("Response status:", error.response.status);
                    console.error("Response headers:", error.response.headers);
                } else if (error.request) {
                    console.error("Request data:", error.request);
                } else {
                    console.error("Error message:", error.message);
                }
                console.error("Error config:", error.config);
            });
    }, []);

    const renderCharts = () => {
        return Object.keys(weatherData).map((cityKey) => {
            const cityData = weatherData[cityKey];
            const sortedData = cityData.sort((a, b) => new Date(a.lastUpdated) - new Date(b.lastUpdated));
            const labels = sortedData.map(data => new Date(data.lastUpdated).toLocaleTimeString());
            const temperatures = sortedData.map(data => data.temperature);
            const minTemperature = Math.min(...temperatures).toFixed(1);
            const maxTemperature = Math.max(...temperatures).toFixed(1);

            const data = {
                labels: labels,
                datasets: [
                    {
                        label: 'Temperature',
                        data: temperatures,
                        fill: false,
                        backgroundColor: 'rgba(75,192,192,0.2)',
                        borderColor: 'rgba(75,192,192,1)',
                    }
                ],
            };

            return (
                <div key={cityKey} className="chart-container">
                    <h2 className="chart-title">{cityKey}</h2>
                    <Line data={data} />
                    <p>Min Temperature: {minTemperature}&deg;C</p>
                    <p>Max Temperature: {maxTemperature}&deg;C</p>
                    <p>Last Update: {labels[labels.length - 1]}</p>
                </div>
            );
        });
    };

    return (
        <div className="container">
            <h1>Weather Data</h1>
            {renderCharts()}
        </div>
    );
};

export default WeatherChart;

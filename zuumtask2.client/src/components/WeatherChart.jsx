import React, { useEffect, useState } from 'react';
import { Line } from 'react-chartjs-2';
import axios from 'axios';
import 'chart.js/auto';

const WeatherChart = () => {
    const [weatherData, setWeatherData] = useState([]);

    useEffect(() => {
        axios.get('/api/weather/history')
            .then(response => {
                setWeatherData(response.data);
            });
    }, []);

    const data = {
        labels: weatherData.map(data => new Date(data.lastUpdated).toLocaleTimeString()),
        datasets: [
            {
                label: 'Temperature',
                data: weatherData.map(data => data.temperature),
                fill: false,
                backgroundColor: 'rgba(75,192,192,0.2)',
                borderColor: 'rgba(75,192,192,1)',
            },
        ],
    };

    return (
        <div>
            <h2>Weather Data</h2>
            <Line data={data} />
        </div>
    );
};

export default WeatherChart;

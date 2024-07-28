﻿CREATE TABLE WeatherData (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    City NVARCHAR(100) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    Temperature FLOAT NOT NULL,
    LastUpdated DATETIME NOT NULL
);

SELECT * FROM dbo.WeatherData
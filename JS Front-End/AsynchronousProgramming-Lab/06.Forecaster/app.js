const locationInpulEl = document.getElementById('location');
const submitInputEl = document.getElementById('submit');
const forecastDivEl = document.getElementById('forecast');
const currentDivEl = document.getElementById('current');
const upcomingDivEl = document.getElementById('upcoming');

function attachEvents() {
    submitInputEl.addEventListener('click', handleWeatherReport);
}

const symbolsMap = {
    'Sunny' : '&#x2600;',
    'Partly sunny' : '&#x26C5;',
    'Overcast' : '&#x2601;',
    'Rain' : '&#x2614;',
    'Degrees' : '&#176;'
}

async function handleWeatherReport() {
    try {
        const allLocationsRes = await fetch('http://localhost:3030/jsonstore/forecaster/locations');
        const allLocationData = await allLocationsRes.json();

        const search = locationInpulEl.value.trim();
        const locationObj = allLocationData.find(loc => loc.name === search);

        const currentConditionsRes = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationObj.code}`);
        const currentConditionsData = await currentConditionsRes.json();

        const threeDayForecastRes = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationObj.code}`);
        const threeDayForecastData = await threeDayForecastRes.json();

        loadCurrentForecast();
        loadThreeDayForecast();

        function loadCurrentForecast() {
            const forecastsDivEl = document.createElement('div');
            forecastsDivEl.classList.add('forecasts');

            const symbolSpanEl = document.createElement('span');
            symbolSpanEl.classList.add('condition', 'symbol');
            symbolSpanEl.innerHTML = symbolsMap[currentConditionsData.forecast.condition];

            const conditionSpanEl = document.createElement('span');
            conditionSpanEl.classList.add('condition');

            const locationSpanEl = document.createElement('span');
            locationSpanEl.classList.add('forecast-data');
            locationSpanEl.textContent = currentConditionsData.name;

            const degreesSpanEl = document.createElement('span');
            degreesSpanEl.classList.add('forecast-data');
            degreesSpanEl.innerHTML = `${currentConditionsData.forecast.low}${symbolsMap.Degrees}/${currentConditionsData.forecast.high}${symbolsMap.Degrees}`;

            const conditionEl = document.createElement('span');
            conditionEl.classList.add('forecast-data');
            conditionEl.textContent = currentConditionsData.forecast.condition;

            conditionSpanEl.appendChild(locationSpanEl);
            conditionSpanEl.appendChild(degreesSpanEl);
            conditionSpanEl.appendChild(conditionEl);

            forecastsDivEl.appendChild(symbolSpanEl);
            forecastsDivEl.appendChild(conditionSpanEl);

            currentDivEl.appendChild(forecastsDivEl);
        }

        function loadThreeDayForecast() {
            const forecastInfoDivEl = document.createElement('div');
            forecastInfoDivEl.classList.add('forecast-info');

            for (const { condition, high, low } of threeDayForecastData.forecast) {
                const upcomingSpanEl = document.createElement('span');
                upcomingSpanEl.classList.add('upcoming');

                const symbolSpanEl = document.createElement('span');
                symbolSpanEl.classList.add('symbol');
                symbolSpanEl.innerHTML = symbolsMap[condition];

                const degreesSpanEl = document.createElement('span');
                degreesSpanEl.classList.add('forecast-data');
                degreesSpanEl.innerHTML = `${low}${symbolsMap.Degrees}/${high}${symbolsMap.Degrees}`;

                const conditionEl = document.createElement('span');
                conditionEl.classList.add('forecast-data');
                conditionEl.textContent = condition;

                upcomingSpanEl.appendChild(symbolSpanEl);
                upcomingSpanEl.appendChild(degreesSpanEl);
                upcomingSpanEl.appendChild(conditionEl);

                forecastInfoDivEl.appendChild(upcomingSpanEl);

                upcomingDivEl.appendChild(forecastInfoDivEl);
            }
        }
    } catch {
        forecastDivEl.textContent = 'Error';
    }
    forecastDivEl.style.display = 'block';
}

attachEvents();
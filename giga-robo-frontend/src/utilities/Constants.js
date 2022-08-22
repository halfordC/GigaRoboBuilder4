const API_BASE_URL_DEVELOPMENT = 'https://localhost:44354';
const API_BASE_URL_PRODUCTION = 'https://gigarobobuilder4.azurewebsites.net';

const ENDPOINTS =
{
    GET_ALL_ROBOTS: 'getAllRobots'
};

const development = 
{
    API_URL_GET_ALL_ROBOTS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_ROBOTS}`
};

const production = 
{
    API_URL_GET_ALL_ROBOTS: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_ROBOTS}`

};

const Constants = process.env.NODE_ENV === 'development' ? development : production;

export default Constants;
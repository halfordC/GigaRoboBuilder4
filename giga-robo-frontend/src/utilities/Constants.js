const API_BASE_URL_DEVELOPMENT = 'https://localhost:44354';
const API_BASE_URL_PRODUCTION = 'https://gigarobobuilder4.azurewebsites.net';

const ENDPOINTS =
{
    GET_ALL_ROBOTS: 'getAllRobots',
    GET_ALL_PILOTS: 'getAllPilots',
    GET_ALL_PILOT_ABILITIES: 'getAllPilotAbilities',
    GET_PILOT_ABILITY_BY_PILOT: 'getPilotAbilitiesByPilot'
};

const development = 
{
    API_URL_GET_ALL_ROBOTS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_ROBOTS}`,
    API_URL_GET_ALL_PILOTS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_PILOTS}`,
    API_URL_GET_ALL_PILOT_ABILITIES: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_PILOT_ABILITIES}`,
    API_URL_GET_PILOT_ABILITIES_BY_PILOT: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_PILOT_ABILITY_BY_PILOT}`
};

const production = 
{
    API_URL_GET_ALL_ROBOTS: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_ROBOTS}`,
    API_URL_GET_ALL_PILOTS: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_PILOTS}`,
    API_URL_GET_ALL_PILOT_ABILITIES: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_PILOT_ABILITIES}`,
    API_URL_GET_PILOT_ABILITIES_BY_PILOT: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_PILOT_ABILITY_BY_PILOT}`
};

const Constants = process.env.NODE_ENV === 'development' ? development : production;

export default Constants;
import axios from 'axios';

const API_URL = 'http://localhost:5240/api/aircrafts';

export const getAircrafts = async () => {
    return await axios.get(API_URL);
};

export const getAircraftById = async (id) => {
    return await axios.get(`${API_URL}/${id}`);
};

export const createAircraft = async (aircraft) => {
    return await axios.post(API_URL, aircraft);
};

export const updateAircraft = async (id, aircraft) => {
    return await axios.put(`${API_URL}/${id}`, aircraft);
};

export const deleteAircraft = async (id) => {
    return await axios.delete(`${API_URL}/${id}`);
};

export const getMaintenanceRecordsByAircraftId = async (id) => {
    return await axios.get(`${API_URL}/${id}/maintenance-records`);
};


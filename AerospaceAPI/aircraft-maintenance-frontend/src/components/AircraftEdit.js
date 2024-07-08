import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getAircraftById, updateAircraft } from '../services/api';

const AircraftEdit = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [aircraft, setAircraft] = useState({
        model: '',
        serialNumber: '',
        lastMaintenanceDate: ''
    });

    useEffect(() => {
        const fetchAircraftDetails = async () => {
            const response = await getAircraftById(id);
            setAircraft(response.data);
        };
        fetchAircraftDetails();
    }, [id]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setAircraft({ ...aircraft, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await updateAircraft(id, aircraft);
        navigate('/'); // Navigate back to the aircraft list
    };

    return (
        <div>
            <h1>Edit Aircraft</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Model</label>
                    <input type="text" name="model" value={aircraft.model} onChange={handleChange} required />
                </div>
                <div>
                    <label>Serial Number</label>
                    <input type="text" name="serialNumber" value={aircraft.serialNumber} onChange={handleChange} required />
                </div>
                <div>
                    <label>Last Maintenance Date</label>
                    <input type="date" name="lastMaintenanceDate" value={aircraft.lastMaintenanceDate.split('T')[0]} onChange={handleChange} required />
                </div>
                <button type="submit">Update Aircraft</button>
            </form>
        </div>
    );
};

export default AircraftEdit;

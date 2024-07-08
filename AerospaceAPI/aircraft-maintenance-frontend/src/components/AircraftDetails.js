import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getAircraftById } from '../services/api';

const AircraftDetails = () => {
    const { id } = useParams();
    const [aircraft, setAircraft] = useState(null);

    useEffect(() => {
        fetchAircraftDetails();
    }, [id]);

    const fetchAircraftDetails = async () => {
        const response = await getAircraftById(id);
        setAircraft(response.data);
    };

    if (!aircraft) return <div>Loading...</div>;

    return (
        <div>
            <h1>Aircraft Details</h1>
            <p>Model: {aircraft.model}</p>
            <p>Serial Number: {aircraft.serialNumber}</p>
            <p>Last Maintenance Date: {new Date(aircraft.lastMaintenanceDate).toLocaleDateString()}</p>
        </div>
    );
};

export default AircraftDetails;

import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getAircrafts, deleteAircraft } from '../services/api';

const AircraftList = () => {
    const [aircrafts, setAircrafts] = useState([]);

    useEffect(() => {
        fetchAircrafts();
    }, []);

    const fetchAircrafts = async () => {
        const response = await getAircrafts();
        setAircrafts(response.data);
    };

    const handleDelete = async (id) => {
        await deleteAircraft(id);
        fetchAircrafts(); // Refresh the list after deletion
    };

    return (
        <div>
            <h1>Aircraft List</h1>
            <table>
                <thead>
                    <tr>
                        <th>Model</th>
                        <th>Serial Number</th>
                        <th>Last Maintenance Date</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {aircrafts.map(aircraft => (
                        <tr key={aircraft.id}>
                            <td>{aircraft.model}</td>
                            <td>{aircraft.serialNumber}</td>
                            <td>{new Date(aircraft.lastMaintenanceDate).toLocaleDateString()}</td>
                            <td>
                                <button onClick={() => handleDelete(aircraft.id)}>Delete</button>
                                <Link to={`/aircrafts/edit/${aircraft.id}`}>
                                    <button>Edit</button>
                                </Link>
                                <Link to={`/aircrafts/${aircraft.id}`}>
                                    <button>View</button>
                                </Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default AircraftList;

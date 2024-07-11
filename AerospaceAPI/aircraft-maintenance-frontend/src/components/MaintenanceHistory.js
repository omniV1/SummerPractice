import React, { useEffect, useState } from 'react';
import { getMaintenanceRecordsByAircraftId } from '../services/api';

const MaintenanceHistory = ({ aircraftId }) => {
    const [records, setRecords] = useState([]);

    useEffect(() => {
        const fetchMaintenanceRecords = async () => {
            const response = await getMaintenanceRecordsByAircraftId(aircraftId);
            setRecords(response.data);
        };

        fetchMaintenanceRecords();
    }, [aircraftId]);

    if (records.length === 0) return <div>No maintenance records found.</div>;

    return (
        <div>
            <h2>Maintenance History</h2>
            <ul>
                {records.map(record => (
                    <li key={record.id}>
                        <p>Date: {new Date(record.maintenanceDate).toLocaleDateString()}</p>
                        <p>Details: {record.details}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default MaintenanceHistory;

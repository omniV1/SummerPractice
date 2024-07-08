import React, { useState } from 'react';
import { createAircraft } from '../services/api';

const AircraftForm = () => {
    const [model, setModel] = useState('');
    const [serialNumber, setSerialNumber] = useState('');
    const [lastMaintenanceDate, setLastMaintenanceDate] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newAircraft = {
            model,
            serialNumber,
            lastMaintenanceDate,
        };
        await createAircraft(newAircraft);
        // Reset form fields after successful submission
        setModel('');
        setSerialNumber('');
        setLastMaintenanceDate('');
    };

    return (
        <div className="form-container">
            <h2>Add Aircraft</h2>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="model">Model</label>
                    <input
                        type="text"
                        id="model"
                        value={model}
                        onChange={(e) => setModel(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="serialNumber">Serial Number</label>
                    <input
                        type="text"
                        id="serialNumber"
                        value={serialNumber}
                        onChange={(e) => setSerialNumber(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="lastMaintenanceDate">Last Maintenance Date</label>
                    <input
                        type="date"
                        id="lastMaintenanceDate"
                        value={lastMaintenanceDate}
                        onChange={(e) => setLastMaintenanceDate(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Add Aircraft</button>
            </form>
        </div>
    );
};

export default AircraftForm;

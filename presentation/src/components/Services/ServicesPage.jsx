import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import ServiceList from './ServiceList';

const ServicePage = () => {
  const [formData, setFormData] = useState({
    serviceName: '',
    price: 0,
    unitId: 1,
    unitName: ''
  });

  const [services, setServices] = useState([]);
  const [loading, setLoading] = useState(true);

  const apiUrl = 'https://localhost:7181/api/services'; 

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const newService = { 
      ...formData,
      unitId: formData.unitId,
      unitName: formData.unitName,
    };

    try {
      const response = await axios.post(apiUrl, newService, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Service added:', response.data);
      setFormData({ serviceName: '', price: 0, unitId: 1, unitName: '' });
      fetchServices();
    } catch (error) {
      console.error('Error adding service:', error.response ? error.response.data : error.message);
    }
  };

  const fetchServices = async () => {
    setLoading(true);
    try {
      const response = await axios.get(apiUrl);
      setServices(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching services:', error);
      setLoading(false);
    }
  };

  const handleDelete = async (id) => {
    const deleteService = window.confirm('Är du säker att du vill ta bort den här tjänsten?');
    if (deleteService) {
      try {
        const response = await axios.delete(`${apiUrl}/${id}`);
        console.log('Service deleted:', response.data);
        fetchServices(); 
      } catch (error) {
        console.error('Error deleting service:', error.response ? error.response.data : error.message);
      }
    }
  };

  useEffect(() => {
    fetchServices();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }
// De kommer från databasen
  const unitOptions = [
    { id: 1, unitName: 'dagar' },
    { id: 3, unitName: 'timme' },
    { id: 4, unitName: 'timmar' },
  ];

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Lägg till tjänst</h2>
          <Link to="/" className="btn btn-dark">Home</Link>
        </div>
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label htmlFor="serviceName" className="form-label">Tjänstnamn</label>
            <input
              type="text"
              className="form-control"
              id="serviceName"
              name="serviceName"
              value={formData.serviceName}
              onChange={handleChange}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="price" className="form-label">Pris</label>
            <input
              type="number"
              className="form-control"
              id="price"
              name="price"
              value={formData.price}
              onChange={handleChange}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="unitId" className="form-label">Enhet</label>
            <select
              id="unitId"
              name="unitId"
              className="form-select"
              value={formData.unitId}
              onChange={(e) => {
                const selectedUnit = unitOptions.find(unit => unit.id === parseInt(e.target.value));
                setFormData({
                  ...formData,
                  unitId: selectedUnit.id,
                  unitName: selectedUnit.unitName
                });
              }}
              required
            >
              {unitOptions.map((unit) => (
                <option key={unit.id} value={unit.id}>
                  {unit.unitName}
                </option>
              ))}
            </select>
          </div>
          <button type="submit" className="btn btn-primary w-100">Spara</button>
        </form>

        <ServiceList services={services} onDelete={handleDelete} />
      </div>
    </div>
  );
};

export default ServicePage;

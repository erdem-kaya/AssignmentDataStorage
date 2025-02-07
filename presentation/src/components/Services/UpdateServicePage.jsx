import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const UpdateServicePage = () => {
  const { id } = useParams();
  const [formData, setFormData] = useState({
    serviceName: '',
    price: 0,
    unitId: 1,
    unitName: '',
  });
  const [loading, setLoading] = useState(true);

  const apiUrl = `https://localhost:7181/api/services/${id}`;
  const unitOptions = [
    { id: 1, unitName: 'dagar' },
    { id: 3, unitName: 'timme' },
    { id: 4, unitName: 'timmar' },
  ];

  const navigate = useNavigate();
  const fetchServiceData = async () => {
    try {
      const response = await axios.get(apiUrl);
      setFormData({
        ...response.data,
        unitName: response.data.unitName, 
      });
      setLoading(false);
    } catch (error) {
      console.error('Error fetching service data:', error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const updatedService = {
      ...formData,
      unitId: formData.unitId,
      unitName: formData.unitName,
    };

    try {
      const response = await axios.put(apiUrl, updatedService, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Service updated:', response.data);
      navigate('/services'); 
    } catch (error) {
      console.error('Error updating service:', error);
    }
  };

  useEffect(() => {
    fetchServiceData();
  }, [id]);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Update Service</h2>
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
                  unitName: selectedUnit.unitName,
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
      </div>
    </div>
  );
};

export default UpdateServicePage;

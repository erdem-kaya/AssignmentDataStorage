import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const UpdateCustomerPage = () => {
  const { id } = useParams();
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    customerType: 'Privat',
    customerTypeId: 1,
  });

  const apiUrl = `https://localhost:7181/api/customers/${id}`;
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCustomerData = async () => {
      try {
        const response = await axios.get(apiUrl);
        setFormData({
          ...response.data,
          customerType: response.data.isCompany ? 'Företag' : 'Privat',
          customerTypeId: response.data.isCompany ? 2 : 1,
        });
      } catch (error) {
        console.error('Error fetching customer data:', error);
      }
    };

    fetchCustomerData();
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    if (name === 'customerType') {
      setFormData({
        ...formData,
        [name]: value,
        customerTypeId: value === 'Privat' ? 1 : 2,
      });
    } else {
      setFormData({
        ...formData,
        [name]: value,
      });
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const updatedCustomer = {
      ...formData,
      isCompany: formData.customerType === 'Företag',
    };

    try {
      const response = await axios.put(apiUrl, updatedCustomer, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Customer updated:', response.data);
      navigate('/customer');
    } catch (error) {
      console.error('Error updating customer:', error);
    }
  };

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Uppdatera Kund</h2>
        </div>
        <form onSubmit={handleSubmit}>
          <div className="row">
            <div className="col-md-6 mb-3">
              <label htmlFor="firstName" className="form-label">Förnamn</label>
              <input
                type="text"
                className="form-control"
                id="firstName"
                name="firstName"
                value={formData.firstName}
                onChange={handleChange}
                required
              />
            </div>
            <div className="col-md-6 mb-3">
              <label htmlFor="lastName" className="form-label">Efternamn</label>
              <input
                type="text"
                className="form-control"
                id="lastName"
                name="lastName"
                value={formData.lastName}
                onChange={handleChange}
                required
              />
            </div>
          </div>
          <div className="row">
            <div className="col-md-6 mb-3">
              <label htmlFor="email" className="form-label">E-Mail</label>
              <input
                type="email"
                className="form-control"
                id="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                required
              />
            </div>
            <div className="col-md-6 mb-3">
              <label htmlFor="phoneNumber" className="form-label">Telefonnummer</label>
              <input
                type="text"
                className="form-control"
                id="phoneNumber"
                name="phoneNumber"
                value={formData.phoneNumber}
                onChange={handleChange}
                required
              />
            </div>
          </div>
          <div className="mb-3">
            <label htmlFor="customerType" className="form-label">Vänligen välj företag eller privat</label>
            <select
              id="customerType"
              name="customerType"
              className="form-select"
              value={formData.customerType}
              onChange={handleChange}
              required
            >
              <option value="Privat">Privat</option>
              <option value="Företag">Företag</option>
            </select>
          </div>
          <button type="submit" className="btn btn-primary w-100">Spara</button>
        </form>
      </div>
    </div>
  );
};

export default UpdateCustomerPage;

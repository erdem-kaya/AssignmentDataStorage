import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import CustomerList from './CustomerList';

const CustomerPage = () => {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    customerType: 'Privat',
  });

  const [customers, setCustomers] = useState([]);
  const [loading, setLoading] = useState(true);

  const apiUrl = 'https://localhost:7181/api/customers';

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    const customerTypeId = formData.customerType === 'Privat' ? 1 : 2;
    const isCompany = formData.customerType === 'Företag';

    const newCustomer = { 
      ...formData,
      customerTypeId,
      IsCompany: isCompany,
    };
  
    try {
      const response = await axios.post(apiUrl, newCustomer, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Kunden har lagts till i systemet:', response.data);
      setFormData({ firstName: '', lastName: '', email: '', phoneNumber: '', customerType: 'Privat' });
      fetchCustomers();
    } catch (error) {
      console.error('Det uppstod ett fel när kunden lades till i systemet:', error.response ? error.response.data : error.message);
    }
  };

  const fetchCustomers = async () => {
    setLoading(true);
    try {
      const response = await axios.get(apiUrl);
      setCustomers(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Ett fel uppstod när kundlistan hämtades:', error);
      setLoading(false);
    }
  };

  const handleEdit = (id) => {
    console.log(`Edit customer with ID: ${id}`);
  };
  
  const handleDelete = async (id) => {
    console.log(`Delete customer with ID: ${id}`);
    const deleteCustomer = window.confirm('Är du säker på att du vill radera kunden?');
    if (deleteCustomer) {
      try {
        const response = await axios.delete(`${apiUrl}/${id}`);
        console.log('Kunden har raderats:', response.data);
        fetchCustomers();
      } catch (error) {
        console.error('Det uppstod ett fel när kunden raderades:', error.response ? error.response.data : error.message);
      }
    }
  };

  useEffect(() => {
    fetchCustomers();
  }, []);

  if (loading) {
    return <div>Loading... </div>;
  }

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Lägg till kund</h2>
          <Link to="/" className="btn btn-dark">Home</Link>
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
          <button type="submit" className="btn btn-primary w-100">Lägg till kund</button>
        </form>
        <CustomerList customers={customers} onEdit={handleEdit} onDelete={handleDelete}/>
      </div>
    </div>
  );
};

export default CustomerPage;

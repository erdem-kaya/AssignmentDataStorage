import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import CompanyList from './CompanyList';

const CompanyPage = () => {
  const [formData, setFormData] = useState({
    companyName: '',
    address: '',
    companyPhone: '',
  });

  const [companies, setCompanies] = useState([]);
  const [loading, setLoading] = useState(true);

  const apiUrl = 'https://localhost:7181/api/companies';

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const newCompany = { 
      ...formData,
    };

    try {
      const response = await axios.post(apiUrl, newCompany, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Company added:', response.data);
      setFormData({ companyName: '', address: '', companyPhone: '' });
      fetchCompanies();
    } catch (error) {
      console.error('Error adding company:', error.response ? error.response.data : error.message);
    }
  };

  const fetchCompanies = async () => {
    setLoading(true);
    try {
      const response = await axios.get(apiUrl);
      setCompanies(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching companies:', error);
      setLoading(false);
    }
  };

  const handleDelete = async (id) => {
    const deleteCompany = window.confirm('Are you sure you want to delete this company?');
    if (deleteCompany) {
      try {
        const response = await axios.delete(`${apiUrl}/${id}`);
        console.log('Company deleted:', response.data);
        fetchCompanies();
      } catch (error) {
        console.error('Error deleting company:', error.response ? error.response.data : error.message);
      }
    }
  };

  useEffect(() => {
    fetchCompanies();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Lägg till företag</h2>
          <Link to="/" className="btn btn-dark">Home</Link>
        </div>
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label htmlFor="companyName" className="form-label">Företagsnamn</label>
            <input
              type="text"
              className="form-control"
              id="companyName"
              name="companyName"
              value={formData.companyName}
              onChange={handleChange}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="address" className="form-label">Address</label>
            <input
              type="text"
              className="form-control"
              id="address"
              name="address"
              value={formData.address}
              onChange={handleChange}
              required
            />
          </div>
          <div className="mb-3">
            <label htmlFor="companyPhone" className="form-label">Telefon</label>
            <input
              type="text"
              className="form-control"
              id="companyPhone"
              name="companyPhone"
              value={formData.companyPhone}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="btn btn-primary w-100">Spara</button>
        </form>

        <CompanyList companies={companies} onDelete={handleDelete} />
      </div>
    </div>
  );
};

export default CompanyPage;

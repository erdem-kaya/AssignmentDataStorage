import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const UpdateCompanyPage = () => {
  const { id } = useParams();
  const [formData, setFormData] = useState({
    companyName: '',
    address: '',
    companyPhone: '',
  });

  const navigate = useNavigate();
  const apiUrl = `https://localhost:7181/api/companies/${id}`;

  const fetchCompanyData = async () => {
    try {
      const response = await axios.get(apiUrl);
      setFormData({
        ...response.data,
      });
    } catch (error) {
      console.error('Error fetching company data:', error);
    }
  };

  useEffect(() => {
    fetchCompanyData();
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const updatedCompany = {
      ...formData,
    };

    try {
      const response = await axios.put(apiUrl, updatedCompany, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Company updated:', response.data);
      navigate('/company');
    } catch (error) {
      console.error('Error updating company:', error);
    }
  };

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Updatera Företag</h2>
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
      </div>
    </div>
  );
};

export default UpdateCompanyPage;

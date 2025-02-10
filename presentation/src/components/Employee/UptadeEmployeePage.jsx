import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const UpdateEmployeePage = () => {
  const { id } = useParams();
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    roleId: 1,
  });
  const [roles, setRoles] = useState([]);
  const navigate = useNavigate();

  const apiUrl = `https://localhost:7181/api/employees/${id}`; 
  const rolesApiUrl = 'https://localhost:7181/api/roles'; 

  const fetchRoles = async () => {
    try {
      const response = await axios.get(rolesApiUrl);
      setRoles(response.data);
    } catch (error) {
      console.error('Error fetching roles:', error);
    }
  };

  useEffect(() => {
    const fetchEmployeeData = async () => {
      try {
        const response = await axios.get(apiUrl);
        setFormData({
          ...response.data,
          roleId: response.data.roleId,
        });
      } catch (error) {
        console.error('Error fetching employee data:', error);
      }
    };

    fetchEmployeeData();
    fetchRoles();
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

    const updatedEmployee = {
      ...formData,
    };

    try {
      const response = await axios.put(apiUrl, updatedEmployee, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Employee updated:', response.data);
      navigate('/employee');
    } catch (error) {
      console.error('Error updating employee:', error);
    }
  };

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Uppdatera anställda</h2>
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

          <div className="mb-3">
            <label htmlFor="roleId" className="form-label">Välj Role</label>
            <select
              id="roleId"
              name="roleId"
              className="form-select"
              value={formData.roleId}
              onChange={handleChange}
              required
            >
              {roles.map((role) => (
                <option key={role.id} value={role.id}>
                  {role.department} - {role.roleName}
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

export default UpdateEmployeePage;

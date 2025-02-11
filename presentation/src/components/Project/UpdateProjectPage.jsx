import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const UpdateProjectPage = () => {
  const { id } = useParams();
  const [formData, setFormData] = useState({
    title: '',
    description: '',
    startDate: '',
    endDate: '',
    customerId: '',
    leadEmployeeId: '',
    statusTypeId: '',
    serviceId: ''
  });
  const [customers, setCustomers] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [services, setServices] = useState([]);
  const navigate = useNavigate();

  const apiUrl = `https://localhost:7181/api/projects/${id}`;

  useEffect(() => {
    const fetchProjectData = async () => {
      try {
        const response = await axios.get(apiUrl);
        setFormData({
          ...response.data,
          startDate: response.data.startDate.split('T')[0],
          endDate: response.data.endDate ? response.data.endDate.split('T')[0] : '' 
        });
      } catch (error) {
        console.error('Error fetching project data:', error);
      }
    };

    const fetchDropdownData = async () => {
      try {
        const customerResponse = await axios.get('https://localhost:7181/api/customers');
        const employeeResponse = await axios.get('https://localhost:7181/api/employees');
        const serviceResponse = await axios.get('https://localhost:7181/api/services');
        setCustomers(customerResponse.data);
        setEmployees(employeeResponse.data);
        setServices(serviceResponse.data);
      } catch (error) {
        console.error('Error fetching dropdown data:', error);
      }
    };

    fetchProjectData();
    fetchDropdownData();
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const updatedProject = {
      ...formData,
      startDate: formData.startDate,
      endDate: formData.endDate,
      leadEmployeeId: formData.leadEmployeeId 
    };

    try {
      const response = await axios.put(apiUrl, updatedProject, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Project updated:', response.data);
      navigate('/projects'); 
    } catch (error) {
      console.error('Error updating project:', error);
    }
  };

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Uppdatera Projekt</h2>
          <div>
            <button
              className="btn btn-dark mx-2"
              onClick={() => navigate('/projects')}
            >
              Alla Projekt
            </button>
            <button
              className="btn btn-dark"
              onClick={() => navigate('/')}
            >
              Home
            </button>
          </div>
        </div>
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label htmlFor="title" className="form-label">Titel</label>
            <input
              type="text"
              className="form-control"
              id="title"
              name="title"
              value={formData.title}
              onChange={handleChange}
              required
            />
          </div>

          <div className="mb-3">
            <label htmlFor="description" className="form-label">Beskrivning</label>
            <textarea
              className="form-control"
              id="description"
              name="description"
              value={formData.description}
              onChange={handleChange}
              required
            />
          </div>

          <div className="mb-3">
            <label htmlFor="startDate" className="form-label">Startdatum</label>
            <input
              type="date"
              className="form-control"
              id="startDate"
              name="startDate"
              value={formData.startDate}
              onChange={handleChange}
              required
            />
          </div>

          <div className="mb-3">
            <label htmlFor="endDate" className="form-label">Slutdatum</label>
            <input
              type="date"
              className="form-control"
              id="endDate"
              name="endDate"
              value={formData.endDate}
              onChange={handleChange}
              required
            />
          </div>

          <div className="mb-3">
            <label htmlFor="customerId" className="form-label">Kund</label>
            <select
              id="customerId"
              name="customerId"
              className="form-select"
              value={formData.customerId}
              onChange={handleChange}
              required
            >
              <option value="">Välj</option>
              {customers.map((customer) => (
                <option key={customer.id} value={customer.id}>
                  {customer.firstName} {customer.lastName}
                </option>
              ))}
            </select>
          </div>

          <div className="mb-3">
            <label htmlFor="leadEmployeeId" className="form-label">Ledande Anställd</label>
            <select
              id="leadEmployeeId"
              name="leadEmployeeId"
              className="form-select"
              value={formData.leadEmployeeId}
              onChange={handleChange}
              required
            >
              <option value="">Välj</option>
              {employees.map((employee) => (
                <option key={employee.id} value={employee.id}>
                  {employee.firstName} {employee.lastName}
                </option>
              ))}
            </select>
          </div>

          <div className="mb-3">
            <label htmlFor="serviceId" className="form-label">Tjänst</label>
            <select
              id="serviceId"
              name="serviceId"
              className="form-select"
              value={formData.serviceId}
              onChange={handleChange}
              required
            >
              <option value="">Välj</option>
              {services.map((service) => (
                <option key={service.id} value={service.id}>
                  {service.serviceName}
                </option>
              ))}
            </select>
          </div>

          <div className="mb-3">
            <label htmlFor="statusTypeId" className="form-label">Status</label>
            <select
              id="statusTypeId"
              name="statusTypeId"
              className="form-select"
              value={formData.statusTypeId}
              onChange={handleChange}
              required
            >
              <option value="">Välj</option>
              <option value="1">Ej Påbörjad</option>
              <option value="2">Påbörjad</option>
              <option value="3">Avslutat</option>
            </select>
          </div>

          <button type="submit" className="btn btn-primary w-100">Spara</button>
        </form>
      </div>
    </div>
  );
};

export default UpdateProjectPage;

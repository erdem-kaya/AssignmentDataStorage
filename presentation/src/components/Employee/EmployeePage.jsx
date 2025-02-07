import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import EmployeeList from './EmployeeList';

const EmployeePage = () => {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    roleId: 1,  // Varsayılan roleId
  });

  const [employees, setEmployees] = useState([]);
  const [roles, setRoles] = useState([]);
  const [loading, setLoading] = useState(true);
  const [showRoleModal, setShowRoleModal] = useState(false); // Modal için state
  const [newRole, setNewRole] = useState({ department: '', roleName: '' }); // Yeni role bilgisi

  const apiUrl = 'https://localhost:7181/api/employees'; // API URL for employees
  const rolesApiUrl = 'https://localhost:7181/api/roles'; // API URL for roles

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleRoleChange = (e) => {
    const { name, value } = e.target;
    setNewRole({
      ...newRole,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const newEmployee = { 
      ...formData,
    };

    try {
      const response = await axios.post(apiUrl, newEmployee, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Employee added:', response.data);
      setFormData({ firstName: '', lastName: '', roleId: 1 });
      fetchEmployees();  // Listeyi yenile
    } catch (error) {
      console.error('Error adding employee:', error.response ? error.response.data : error.message);
    }
  };

  const fetchEmployees = async () => {
    setLoading(true);
    try {
      const response = await axios.get(apiUrl);
      setEmployees(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching employee list:', error);
      setLoading(false);
    }
  };

  const fetchRoles = async () => {
    try {
      const response = await axios.get(rolesApiUrl);
      setRoles(response.data);
    } catch (error) {
      console.error('Error fetching roles:', error);
    }
  };

  const handleRoleSubmit = async () => {
    try {
      const response = await axios.post(rolesApiUrl, newRole, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log('Role added:', response.data);
      setRoles([...roles, response.data]); // Yeni role'yi listeye ekle
      setShowRoleModal(false); // Modal'ı kapat
      setNewRole({ department: '', roleName: '' }); // Yeni role formunu sıfırla
    } catch (error) {
      console.error('Error adding role:', error);
    }
  };

  const handleDelete = async (id) => {
    const deleteEmployee = window.confirm('Are you sure you want to delete this employee?');
    if (deleteEmployee) {
      try {
        const response = await axios.delete(`${apiUrl}/${id}`);
        console.log('Employee deleted:', response.data);
        fetchEmployees();  // Listeyi yenile
      } catch (error) {
        console.error('Error deleting employee:', error.response ? error.response.data : error.message);
      }
    }
  };

  useEffect(() => {
    fetchEmployees();
    fetchRoles();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="container d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6">
        <div className="d-flex justify-content-between align-items-center mb-4">
          <h2>Add Employee</h2>
          <Link to="/" className="btn btn-dark">Home</Link>
        </div>
        <form onSubmit={handleSubmit}>
          <div className="row">
            <div className="col-md-6 mb-3">
              <label htmlFor="firstName" className="form-label">First Name</label>
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
              <label htmlFor="lastName" className="form-label">Last Name</label>
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
            <label htmlFor="roleId" className="form-label">Role</label>
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
            <button
              type="button"
              className="btn btn-dark mt-2"
              onClick={() => setShowRoleModal(true)}
            >
              + Add New Role
            </button>
          </div>
          <button type="submit" className="btn btn-primary w-100">Add Employee</button>
        </form>
        {showRoleModal && (
          <div className="modal show" style={{ display: 'block' }}>
            <div className="modal-dialog">
              <div className="modal-content">
                <div className="modal-header">
                  <h5 className="modal-title">Add New Role</h5>
                  <button type="button" className="btn-close" onClick={() => setShowRoleModal(false)}>
                    
                  </button>
                </div>
                <div className="modal-body">
                  <div className="mb-3">
                    <label htmlFor="department" className="form-label">Department</label>
                    <input
                      type="text"
                      className="form-control"
                      id="department"
                      name="department"
                      value={newRole.department}
                      onChange={handleRoleChange}
                      required
                    />
                  </div>
                  <div className="mb-3">
                    <label htmlFor="roleName" className="form-label">Role Name</label>
                    <input
                      type="text"
                      className="form-control"
                      id="roleName"
                      name="roleName"
                      value={newRole.roleName}
                      onChange={handleRoleChange}
                      required
                    />
                  </div>
                  <button type="button" className="btn btn-primary" onClick={handleRoleSubmit}>
                    Save Role
                  </button>
                </div>
              </div>
            </div>
          </div>
        )}

        <EmployeeList employees={employees} roles={roles} onDelete={handleDelete} />
      </div>
    </div>
  );
};

export default EmployeePage;

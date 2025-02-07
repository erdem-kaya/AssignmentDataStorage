import React from 'react';
import { FaEdit, FaTrash } from 'react-icons/fa';
import { Link } from 'react-router-dom';

const EmployeeList = ({ employees, roles, onDelete }) => {
  return (
    <div className="container mt-3">
      <h3>Employee List</h3>
      <ul className="list-group">
        {employees.map((employee) => {
          // RoleId'ye karşılık gelen Role bilgisini bulma
          const employeeRole = roles ? roles.find(role => role.id === employee.roleId) : null;

          return (
            <li key={employee.id} className="list-group-item d-flex justify-content-between align-items-center">
              <div>
                <strong>{employee.firstName} {employee.lastName}</strong><br />
                {employeeRole ? (
                  <span className="d-flex align-items-center">
                    <span className="mr-2">Department: {employeeRole.department}</span>
                    <span className="mx-2">|</span>
                    <span className="mr-2">Title: {employeeRole.roleName}</span>
                  </span>
                ) : (
                  <span>No Role</span>
                )}
              </div>
              <div>
                <Link 
                  to={`/update-employee/${employee.id}`} 
                  className="btn btn-info btn-sm mx-1" 
                  title="Update"
                >
                  <FaEdit />
                </Link>
                <button 
                  className="btn btn-danger btn-sm mx-1" 
                  onClick={() => onDelete(employee.id)} 
                  title="Delete"
                >
                  <FaTrash />
                </button>
              </div>
            </li>
          );
        })}
      </ul>
    </div>
  );
};

export default EmployeeList;

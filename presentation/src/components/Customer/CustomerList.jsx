import React from 'react';
import { FaEdit, FaTrash } from 'react-icons/fa';



const CustomerList = ({ customers, onEdit, onDelete }) => {
  return (
    <div className="container mt-3">
      <h3>Kunder</h3>
      <ul className="list-group">
        {customers.map((customer) => (
          <li key={customer.id} className="list-group-item d-flex justify-content-between align-items-center">
            <div>
              <strong>{customer.firstName} {customer.lastName}</strong><br />
              {customer.email} - {customer.phoneNumber}
            </div>
            <div>
              <button 
                className="btn btn-info btn-sm mx-1" 
                onClick={() => onEdit(customer.id)} 
                title="Uppdatera">
                <FaEdit />
              </button>
              <button 
                className="btn btn-danger btn-sm mx-1" 
                onClick={() => onDelete(customer.id)} 
                title="Radera">
                <FaTrash />
              </button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default CustomerList;
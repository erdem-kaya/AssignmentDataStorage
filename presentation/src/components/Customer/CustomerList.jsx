import React, { useState, useEffect } from 'react';
import { FaEdit, FaTrash } from 'react-icons/fa';
import { Link } from 'react-router-dom';
import axios from 'axios';

const CustomerList = ({ customers, onDelete }) => {
  const [loadingList, setLoadingList] = useState(true);
  const [customersState, setCustomers] = useState([]);
  const apiUrl = 'https://localhost:7181/api/customers';

  const fetchCustomers = async () => {
    setLoadingList(true);
    try {
      const response = await axios.get(apiUrl);
      setCustomers(response.data);
      setLoadingList(false);
    } catch (error) {
      console.error('Error fetching customers:', error);
      setLoadingList(false);
    }
  };

  useEffect(() => {
    fetchCustomers();
  }, []);

  if (loadingList) {
    return <div>Om du inte kan se kundlistan efter att sidan har laddats, kontrollera att WebApi-appen körs!</div>;
  }

  return (
    <div className="container mt-3">
      <h3>Kunder</h3>
      <ul className="list-group">
        {customersState.map((customer) => (
          <li key={customer.id} className="list-group-item d-flex justify-content-between align-items-center">
            <div>
              <strong>{customer.firstName} {customer.lastName}</strong><br />
              {customer.email} - {customer.phoneNumber}
            </div>
            <div>
              <Link 
                to={`/update-customer/${customer.id}`} 
                className="btn btn-info btn-sm mx-1" 
                title="Uppdatera"
              >
                <FaEdit />
              </Link>
              <button 
                className="btn btn-danger btn-sm mx-1" 
                onClick={() => onDelete(customer.id)} 
                title="Radera"
              >
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

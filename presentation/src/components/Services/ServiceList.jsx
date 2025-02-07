import React from 'react';
import { FaEdit, FaTrash } from 'react-icons/fa';
import { Link } from 'react-router-dom';

const ServiceList = ({ services, onDelete }) => {
  return (
    <div className="container mt-3">
      <h3>Tjänster</h3>
      <ul className="list-group">
        {services.map((service) => 
          <li key={service.id} className="list-group-item d-flex justify-content-between align-items-center">
            <div>
              <strong>{service.serviceName}</strong><br />
              <span>Price: {service.price} SEK</span><br />
              
            </div>
            <div>
              <Link
                to={`/update-service/${service.id}`}
                className="btn btn-info btn-sm mx-1"
                title="Update"
              >
                <FaEdit />
              </Link>
              <button
                className="btn btn-danger btn-sm mx-1"
                onClick={() => onDelete(service.id)}
                title="Delete"
              >
                <FaTrash />
              </button>
            </div>
          </li>
        )}
      </ul>
    </div>
  );
};

export default ServiceList;

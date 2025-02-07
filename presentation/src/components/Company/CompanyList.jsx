import React from 'react';
import { FaEdit, FaTrash } from 'react-icons/fa';
import { Link } from 'react-router-dom';

const CompanyList = ({ companies, onDelete }) => {
  return (
    <div className="container mt-3">
      <h3>Företagslista</h3>
      <ul className="list-group">
        {companies.map((company) => (
          <li key={company.id} className="list-group-item d-flex justify-content-between align-items-center">
            <div>
              <strong>{company.companyName}</strong><br />
              <span>Address: {company.address}</span><br />
              <span>Phone: {company.companyPhone}</span>
            </div>
            <div>
              <Link
                to={`/update-company/${company.id}`}
                className="btn btn-info btn-sm mx-1"
                title="Update"
              >
                <FaEdit />
              </Link>
              <button
                className="btn btn-danger btn-sm mx-1"
                onClick={() => onDelete(company.id)}
                title="Delete"
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

export default CompanyList;

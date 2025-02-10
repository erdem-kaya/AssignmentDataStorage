import React from 'react';
import { Link } from 'react-router-dom';
import AddProject from '../components/Project/AddProject';

const Home = () => {
  return (
    <div className="d-flex flex-column justify-content-center align-items-center vh-100">
      <div className="text-center mb-4">
        {/* Butonlar */}
        <Link to="/customer" className="btn btn-dark m-2" style={{ fontSize: '20px', width: '200px' }}>
          Kunder
        </Link>
        <Link to="/employee" className="btn btn-dark m-2" style={{ fontSize: '20px', width: '200px' }}>
          Personel
        </Link>
        <Link to="/company" className="btn btn-dark m-2" style={{ fontSize: '20px', width: '200px' }}>
          Företag
        </Link>
        <Link to="/services" className="btn btn-dark m-2" style={{ fontSize: '20px', width: '200px' }}>
          Tjänsten
        </Link>
        <Link className="btn btn-dark m-2" style={{ fontSize: '20px', width: '200px' }}>
          Alla Projekt
        </Link>
      </div>
      <div className="col-md-6">
        <AddProject />
      </div>
    </div>
  );
};

export default Home;

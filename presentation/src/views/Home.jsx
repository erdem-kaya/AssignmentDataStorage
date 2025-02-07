import React from 'react'
import { Link } from 'react-router-dom'

const Home = () => {
  return (
    <div className="d-flex justify-content-center align-items-center vh-100">
      <div className="text-center">
        <Link to="/customer" className="btn btn-dark m-2" style={{ fontSize: '20px', width: '200px' }}>
          Kunder
        </Link>
        <Link to="/employee" className="btn btn-dark m-2" style={{ fontSize: '20px', width: '200px' }}>
          Personel
        </Link>
        <button className="btn btn-dark m-2" style={{ fontSize: '20px', width: '200px' }}>
          Lägg till projekt
        </button>
      </div>
    </div>
  )
}

export default Home
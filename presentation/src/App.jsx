import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './views/Home'
import CustomerPage from './components/Customer/CustomerPage'
import UpdateCustomerPage from './components/Customer/UpdateCustomerPage'; 
import EmployeePage from './components/Employee/EmployeePage'
import UpdateEmployeePage from './components/Employee/UptadeEmployeePage'
import CompanyPage from './components/Company/CompanyPage'
import UpdateCompanyPage from './components/Company/UpdateCompanyPage'
import UpdateServicePage from './components/Services/UpdateServicePage'
import ServicesPage from './components/Services/ServicesPage'


function App() {


  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/customer" element={<CustomerPage />} />
        <Route path="/employee" element={<EmployeePage />} />
        <Route path="/company" element={<CompanyPage />} />
        <Route path="/services" element={<ServicesPage />} />
        <Route path="/update-employee/:id" element={<UpdateEmployeePage />} />
        <Route path="/update-customer/:id" element={<UpdateCustomerPage />} />
        <Route path="/update-company/:id" element={<UpdateCompanyPage />} />
        <Route path="/update-service/:id" element={<UpdateServicePage />} />
        
      </Routes>
    </BrowserRouter>
  )
}

export default App

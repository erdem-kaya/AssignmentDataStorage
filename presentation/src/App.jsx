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


function App() {


  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/customer" element={<CustomerPage />} />
        <Route path="/employee" element={<EmployeePage />} />
        <Route path="/company" element={<CompanyPage />} />
        <Route path="/update-employee/:id" element={<UpdateEmployeePage />} />
        <Route path="/update-customer/:id" element={<UpdateCustomerPage />} />
        <Route path="/update-company/:id" element={<UpdateCompanyPage />} />
        
      </Routes>
    </BrowserRouter>
  )
}

export default App

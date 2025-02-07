import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './views/Home'
import Registration from './views/Registration'
import CustomerPage from './components/Customer/CustomerPage'

function App() {


  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/customer" element={<CustomerPage />} />
        <Route path="/registration" element={<Registration />} />

      </Routes>
    </BrowserRouter>
  )
}

export default App

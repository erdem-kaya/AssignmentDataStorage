import { useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './views/Home'
import AllLists from './views/AllLists'
import Registration from './views/Registration'

function App() {


  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/all-lists" element={<AllLists />} />
        <Route path="/registration" element={<Registration />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

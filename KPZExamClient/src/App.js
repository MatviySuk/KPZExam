import React from 'react';
import {BrowserRouter, Routes, Route} from "react-router-dom";
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import "./App.css";
import Header from './Components/Header/Header';
import AddEdit from './Components/pages/AddEdit';
import View from './Components/pages/ViewStudents';
import Assignments from './Components/pages/Assignments';

function App() {
  return (
    <div>
    {/* <div> 
      <Header />
    </div> */}
    <BrowserRouter> 
      <div className="App">
        <Header />
        <ToastContainer/>
        <Routes>

          <Route path="/" element= {<Assignments />} />
          <Route path = "/add" element = {<AddEdit />}/>
          <Route path = "/update/:id" element = {<AddEdit />}/>
          <Route path = "/viewStudents/:id" element = {<View />}/>
        </Routes>
      </div>
    </BrowserRouter>
    </div>
  );
}


export default App;

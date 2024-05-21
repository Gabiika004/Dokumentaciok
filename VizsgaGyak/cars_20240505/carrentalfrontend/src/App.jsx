import { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import AutoCard from './AutoCard';
import AutoForm from './AutoForm';

function App() {

  const [cars,setCars] = useState([]);
  const url = "http://localhost:8000/api/cars/";

  const getAllCarsAsync = async () =>{
    const response = await fetch(url);
    if (response.statusText==='OK') {
      const data = await response.json();
      setCars(data.data);
    }
    else{
      alert(response.message);
    }

  };

  useEffect(()=> {getAllCarsAsync();},[]);

  return (
    <>
    <header>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container">
          <button className="navbar-toggler" 
                  type="button" 
                  data-bs-toggle="collapse" 
                  data-bs-target="#navbarNav" 
                  aria-controls="navbarNav" 
                  aria-expanded="false" 
                  aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">
              <li className="nav-item">
                <a className="nav-link" href="#autoForm">Új autó felvétele</a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="https://petrik.hu/">Petrik honlap</a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <h1 className='container mt-3'>Petrik autókölcsönző</h1>
    </header>

    <main className='container'>
      <div className="row row-cols-1 row-cols-md-2 row-cols-lg-3">
      {cars.map(car => <AutoCard key={car.id} car = {car} url = {url} />)}
      </div>
      <div className="container mt-2" id='autoForm' >
        <AutoForm onSuccess={getAllCarsAsync} url = {url} />
      </div>
    </main>
    </>
  )
}

export default App

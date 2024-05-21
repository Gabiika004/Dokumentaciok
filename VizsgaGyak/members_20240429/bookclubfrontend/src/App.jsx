import { useState, useEffect } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css'
import MemberCard from './MemberCard';
import MemberForm from './MemberForm';

function App() {

  const [members,setMembers] = useState([]);
  const url = "http://localhost:8000/api/members/";

  const fetchMembers = async () => {
      const response = await fetch(url);
      const data = await response.json();
      console.log(data)
      setMembers(data.data);
      console.log(members)
  };

  useEffect(() => { fetchMembers();},[]);

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
                  <a className="nav-link" href="#newMember">Új tag felvétele</a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="https://petrik.hu/">Petrik honlap</a>
                </li>
              </ul>
            </div>
          </div>
        </nav>
        <div className="container mt-3">
          <h1>Petrik Könyvklub</h1>
        </div>
      </header>

      <main className='container'>
        <div className="row row-cols-1 row-cols-md-2 row-cols-lg-3">
          {members.map(member => <MemberCard key={member.id} member={member} url = {url} />)}
        </div>

        <div className="mt-3 row justify-content-center" id='newMember'>
            <MemberForm onSuccess={fetchMembers} url = {url}/>
        </div>
      </main>

      <footer>
  
      </footer>
    </>
  )
}

export default App

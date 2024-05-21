import React, { useState, useRef } from "react";
import PropTypes from 'prop-types';

function MemberForm(props) {
    const {url} = props;
    const{ onSuccess } = props;
    const [error,setError] = useState("");
    const nameRef = useRef(null);
    const genderRef = useRef(null);
    const birth_dateRef = useRef(null);

    const handleSumbit = event => {
        event.preventDefault();
        addNewMember();
    };

    const addNewMember = async (event) => {

        let data;
        if(genderRef.current.value === ""){
             data = {
                name: nameRef.current.value,
                birth_date: birth_dateRef.current.value,
            }
        }
        else{
            data = {
                name: nameRef.current.value,
                gender: genderRef.current.value,
                birth_date: birth_dateRef.current.value,
            }
        }

            const response = await fetch(url,{
    
                method: "POST",
                body: JSON.stringify(data),
                headers:{
                    "Content-Type": "application/json",
                    "Accept": "application/json"                
                },
            });
            if (response.ok) {
                clearForm();
                onSuccess();
                alert("Tag sikeresen felvéve!");
            }
            else{
                const responsData = await response.json();
                setError(responsData.message)
            }

     
    };

    const clearForm = () => {
        nameRef.current.value = "";
        genderRef.current.value ="";
        birth_dateRef.current.value = "";
        setError("");
    };

    return ( <form onSubmit={handleSumbit} className="text-center justify-content-center col-10">
        <h2 className="mb-3" >Új tag felvétele</h2>

        {error != "" ? (
            <div className="alert alert-danger" role="alert">{error}</div>
        ) : (
            ""
        )}

        <div className="input-group mb-3">
            <label className="input-group-text" htmlFor="nameInput">Teljes név:</label>   
            
            <input  type="text" 
                    className="form-control"
                    aria-label="Név" 
                    id="nameInput"
                    aria-describedby="Név"
                    ref={nameRef}/>
        </div>

        <div className="input-group mb-3 ">
            <label className="input-group-text" htmlFor="genderSelect">Nem</label>   

            <select className="form-select" 
                    id="genderSelect"
                    ref={genderRef}
                    defaultValue="">
                <option value="M">Férfi</option>
                <option value="F">Nő</option>
                <option value="">Egyéb</option>
            </select>
        </div>

        <div className="input-group mb-3">
            <label className="input-group-text" htmlFor="birthDayInput">Születési dátum:</label> 

            <input  type="date"
                    className="form-control" 
                    aria-label="Születési dátum" 
                    aria-describedby="Születési dátum"
                    id="birthDayInput"
                    ref={birth_dateRef}/>
        </div>

        <button className="btn btn-success m-2 col-3">Tagfelvétel</button>
    </form> );
}

MemberForm.propTypes = {
    onSuccess: PropTypes.func.isRequired,
    url: PropTypes.string.isRequired,
};

export default MemberForm;
import { useState, useEffect, useRef } from 'react';

function AutoForm(props) {
    const {url} = props;
    const [error,setError]= useState("");
    const brand_ref = useRef(null);
    const model_ref = useRef(null);
    const license_plate_number_ref = useRef(null);
    const daily_cost_ref = useRef(null);

    const handleSubmit = async (event)=>{
        event.preventDefault();
        await createNewCar();
    };

    const clearForm = () =>{
        brand_ref.current.value = "";
        model_ref.current.value = "";
        license_plate_number_ref.current.value = "";
        daily_cost_ref.current.value = null;
    };

    const createNewCar = async ()=>{
        const data = {
            "brand" : brand_ref.current.value,
            "model" : model_ref.current.value,
            "license_plate_number" : license_plate_number_ref.current.value,
            "daily_cost" : daily_cost_ref.current.value
        }

        try {
            const response = await fetch(url,{
                method: "POST",
                body: JSON.stringify(data),
                headers:{
                    "Content-Type" : "application/json",
                    "Accept" :  "application/json"
                }
            });

            if (response.ok) {
                setError("Sikeres felvétel!")
                clearForm();
            }
            else{
                const responseData = await response.json();
                setError(responseData.message);
            }
            
        } catch (error) {
            setError("Sajnáljuk valamilyen hiba történt!")
        }

    };

    const renderSwitch = (param) =>{
        switch(param) {
            case "":
                return "";
            case "Sikeres felvétel!":
                return <div className='alert alert-success' role='alert'>{param}</div>;
            default:
                return <div className='alert alert-danger' role='alert'>{param}</div>;
        }
      };

    return ( 
    <form className='text-center' onSubmit={handleSubmit}>
        <h3 className='m-3'>Új autó felvétele</h3>

        {renderSwitch(error)}

        <div className='row text-center'>
            <div className="col-12 col-md-12 col-lg-6">
                <div className="input-group m-1">   
                    <label htmlFor="brand"><span className="input-group-text" id="brand-addon">Márka</span></label>
                    <input  type="text" 
                            className="form-control" 
                            id='brand' 
                            aria-label="Márka" 
                            aria-describedby="brand-addon" 
                            ref={brand_ref}/>
                </div>
            </div>
            <div className="col-12 col-md-12 col-lg-6">
                <div className="input-group m-1">
                    <label htmlFor="model"><span className="input-group-text" id="model-addon">Modell</span></label>
                    <input  type="text" 
                            className="form-control" 
                            id='model' 
                            aria-label="Modell" 
                            aria-describedby="model-addon"
                            ref={model_ref}/>
                </div>
            </div>
        </div>
        <div className='row'>
            <div className="col-12 col-md-12 col-lg-6">
                <div className="input-group m-1">   
                    <label htmlFor="license_plate"><span className="input-group-text" id="license_plate-addon">Rendszám</span></label>
                    <input  type="text" 
                            className="form-control" 
                            id='license_plate' 
                            aria-label="Rendszám" 
                            aria-describedby="license_plate-addon"
                            ref={license_plate_number_ref}/>
                </div>
            </div>
            <div className="col-12 col-md-12 col-lg-6">
                <div className="input-group m-1">
                    <label htmlFor="daily_cost"><span className="input-group-text" id="daily_cost-addon">Napidíj (FT)</span></label>
                    <input  type="number" 
                            className="form-control" 
                            id='daily_cost' 
                            aria-label="Napidíj" 
                            aria-describedby="daily_cost-addon" 
                            min={5000}
                            ref={daily_cost_ref}/>
                </div>
            </div>
        </div>
        <div className='row'>
            <div className="col text-center">
                <button className="btn btn-success m-3">Új autó</button>
            </div>
        </div>
    </form>);
}

export default AutoForm;

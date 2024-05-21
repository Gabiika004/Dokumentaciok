import { useState } from "react";

function AutoCard(props) {

    const {car, url} = props;
    const [error,setError] = useState("");
    const imageUrl = "./images/" + car.brand + "_" + car.model + ".png";
    const rentUrl = url + car.id + "/rent";

    const rentCar = async () =>{
        alert(rentUrl);
        try {
            const response = await fetch(rentUrl,{
                method: "POST",
                headers:{
                    "Accept": "application/json"
                }
            });
            if(response.ok){
                alert("Sikeres kölcsönzés!");
            } else {
                const responsData = await response.json();
                alert(responsData.message);
            }
        } catch (error) {
            if (error.response && error.response.status) {
                alert(`Sajnáljuk valamilyen hiba történt! Hiba státuszkód: ${error.response.status}`);
            } else {
                alert("Sajnáljuk valamilyen hiba történt!");
            }
        }
    };
    
    return ( <>
    <div className="container">
        <div className="row">
            <div className="card col m-2" style={{ height: "100%" }}>
                <div   div className="card-body">
                    <h4 className="card-title">{car.license_plate_number}</h4>
                    <p className="card-text">Márka: {car.brand}</p>
                    <p className="card-text">Modell: {car.model}</p>
                    <p className="card-text">Napidíj: {car.daily_cost}</p>
                    <button className="btn btn-primary" onClick={() => rentCar()}>Kölcsönzés</button>
                </div>
                <div className="img-container" style={{ height: "300px", display: "flex", alignItems: "center", justifyContent: "center" }}>
                    <img src={imageUrl} className="card-img mb-2" alt="..." style={{ maxWidth: "100%", maxHeight: "100%" }} />
                </div>
            </div>
        </div>
    </div>
    </> );
}

export default AutoCard;
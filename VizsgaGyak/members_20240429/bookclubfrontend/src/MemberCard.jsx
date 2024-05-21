import PropTypes from 'prop-types'
import { useState, useEffect } from 'react'


function MemberCard(props) {

    const { member } = props ;
    const { url } = props ;
    const [gender, setGender] = useState("");

    useEffect(() => {
        function setGenderByMember() {
            switch (member.gender) {
                case "M":
                    setGender("male");
                    break;
                case "F":
                    setGender("female");
                    break;
                default:
                    setGender("other");
            }
        }

        setGenderByMember();
    }, [member.gender]);

    const payBill = async () => {
        const id = member.id;
        alert(id);
        const response = await fetch(url + id + "/pay/",{
            method: "POST",
            headers: {
                "Accept" : "application/json"
            }
        })

        if (response.ok) {
            alert("Sikeres befizetés!");
        }
        else{
            const data = await response.json();
            alert(data.message);
        }
    };


    return(
        <div className="container">
            <div className="row">
                <div className="card">
                    <div className="card-body">
                        <h5 className="card-title mt-3">{member.name}</h5>
                        <p className="card-text">Született: {member.birth_date}</p>
                        <p className="card-text">Csatlakozott: {member.created_at}</p>
                    </div>
                    <img src={`../images/${gender}.png`} className="card-img-fluid" alt={member.gender}/>
                    <div className="car-footer text-center">
                        <button className='btn btn-success m-2' onClick={() => payBill()} >Tagdíj befizetés</button>
                    </div>
                </div>
            </div>
        </div>
    );

}

MemberCard.propTypes = {
    member: PropTypes.object.isRequired,
    url: PropTypes.string.isRequired,
 };

export default MemberCard;
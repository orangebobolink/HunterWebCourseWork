import React from 'react';
import {useNavigate} from 'react-router-dom';

const AddAnimalCard = () => {
    const navigate = useNavigate();

    function redirect() {
        return navigate(`/animalcreate`);
    }

    return (
        <div className="group relative" onClick={redirect}>
            <div className="relative h-80 w-full overflow-hidden rounded-lg bg-white sm:aspect-h-1 sm:aspect-w-2 lg:aspect-h-1 lg:aspect-w-1 group-hover:opacity-75 sm:h-64">
                <img className="w-full h-full"
                     src={require("../../../images/plus.png")}
                     alt="add animal"/>
            </div>
        </div>
    );
};

export default AddAnimalCard;
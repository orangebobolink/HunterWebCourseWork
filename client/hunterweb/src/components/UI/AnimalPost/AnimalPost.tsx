import React, {FC} from 'react';
import {useNavigate} from 'react-router-dom';

interface Props {
    name:string,
    imageSrc:string,
    imageAlt?:string,
    href:string,
    description:string
}

const AnimalPost:FC<Props> = ({name, imageSrc, imageAlt, href, description}) => {
    const navigate = useNavigate();

    function redirect() {
        return navigate(`/animals/${name}`);
    }

    return (
        <div key={name} className="group relative" onClick={redirect}>
            <div className="relative h-80 w-full overflow-hidden rounded-lg bg-white sm:aspect-h-1 sm:aspect-w-2 lg:aspect-h-1 lg:aspect-w-1 group-hover:opacity-75 sm:h-64">
                <img
                    src={require(`../../../../src/images/${imageSrc}` )}
                    alt={imageAlt}
                    className="h-full w-full object-cover object-center"
                />
            </div>
            <h3 className="mt-6 text-sm text-gray-500">

                    <span className="absolute inset-0" />
                    {name}

            </h3>
            <p className="text-base font-semibold text-gray-900">{description}</p>
        </div>
    );
};

export default AnimalPost;
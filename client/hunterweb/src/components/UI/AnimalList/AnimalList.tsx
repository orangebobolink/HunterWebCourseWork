import React, {FC, useContext, useEffect, useState} from 'react';
import AnimalPost from '../AnimalPost/AnimalPost';
import AddAnimalCard from '../AddAnimalCard/AddAnimalCard';
import {Context} from '../../../index';
import {IAnimalDetail} from '../../../models/IAnimalDetail';
import AnimalService from '../../../services/AnimalService';
import {observer} from 'mobx-react-lite';

interface Props {
    animals:IAnimalDetail[]
}

const AnimalList: FC<Props> = ({animals}) => {
    const {store} = useContext(Context);

    return (
         
            <div className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
                <div className="mx-auto max-w-2xl py-16 sm:py-24 lg:max-w-none lg:py-32">
                    <h2 className="text-2xl font-bold text-gray-900">Трофеи</h2>
                    <div className="mt-6 space-y-12 lg:grid lg:grid-cols-3 lg:gap-x-6 lg:space-y-0">
                        {animals.map((animal) => (
                            <AnimalPost name={animal.name}
                                        englishName={animal.englishName}
                                        href={animal.imageUrl}
                                        imageSrc={animal.imageUrl}
                                        imageAlt={animal.name}
                                        description={animal.description}/>
                        ))}

                        {
                            store.user.roles.includes("admin")
                            ? <AddAnimalCard/>
                            : <div></div>
                        }
                    </div>
                </div>
            </div>
    
    );
};

export default observer(AnimalList);
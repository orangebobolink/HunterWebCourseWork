import React, {useContext, useEffect, useState} from 'react';
import {observer} from 'mobx-react-lite';
import {Context} from '../index';
import AnimalList from '../components/UI/AnimalList/AnimalList';
import {IAnimalDetail} from '../models/IAnimalDetail';
import AnimalService from '../services/AnimalService';
import {Spinner} from 'flowbite-react';

const AnimalPage = () => {
    const {store} = useContext(Context);
    const [animals, setAnimals] = useState<IAnimalDetail[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    const fetchData = async () => {
        const response = await AnimalService.getAll();
        setAnimals(response.data)
        setIsLoading(false)
    }

    useEffect(() => {
        setIsLoading(true)
        fetchData()
    }, []);

    return (
        <div className="bg-gray-100">
            {
             !isLoading
                ?
                <AnimalList animals={animals}/>
                :
                <Spinner  aria-label="Extra large spinner example"
                          size="xl"/>
             }
        </div>
    )
};

export default observer(AnimalPage);
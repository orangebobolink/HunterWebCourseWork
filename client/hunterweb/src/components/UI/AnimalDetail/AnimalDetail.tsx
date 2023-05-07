import React, {useContext, useEffect, useState} from 'react';
import {useParams} from 'react-router-dom';
import AnimalService from '../../../services/AnimalService';
import {IAnimalDetail} from '../../../models/IAnimalDetail';
import {Spinner, Table} from 'flowbite-react';
import {Context} from '../../../index';

const AnimalDetail = () => {
    const {name} = useParams() as any
    const [animal, setAnimal] = useState<IAnimalDetail>({
        name:'',
        imageUrl:'horn.jpg',
        description: '',
        huntingSeasons: [],
        tableId: ''}
    )
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const {store} = useContext(Context);

    const fetch = async ()=> {
        const response = await AnimalService.getByName(name.toString())
        console.log(response.data)
        setIsLoading(false)
        setAnimal(response.data)
    }

    useEffect(() => {
        setIsLoading(true)
        fetch()
    }, []);

    return (
        <div>
        { !isLoading ?
            <div className="container mx-auto w-1/3">
                <figure className="max-w-lg">
                    <img className="h-auto max-w-full rounded-lg"
                         src={require(`../../../../src/images/${animal.imageUrl}`)}
                         alt={animal.name}/>
                    <figcaption className="mt-2 text-sm text-center text-gray-500 dark:text-gray-400">
                        {animal.name}
                    </figcaption>
                </figure>

                <p className="mb-3 text-lg text-gray-500 md:text-xl dark:text-gray-400">{animal.description}</p>
                <Table>
                    <Table.Head>
                        <Table.HeadCell>
                            Начало сезона
                        </Table.HeadCell>
                        <Table.HeadCell>
                            Конец сезона
                        </Table.HeadCell>
                        <Table.HeadCell>
                            Описание
                        </Table.HeadCell>
                    </Table.Head>
                    <Table.Body className="divide-y">
                        {animal.huntingSeasons.map((season) =>
                            <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    {season.dateStart.toString()}
                                    .
                                    {season.dateStart.toString()}
                                </Table.Cell>
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    {season.dateEnd.toString().toString()}
                                    .
                                    {season.dateEnd.toString().toString()}
                                </Table.Cell>
                                <Table.Cell>
                                    {season.description}
                                </Table.Cell>
                            </Table.Row>
                        )}
                    </Table.Body>
                </Table>
    </div>
           :
           <Spinner/>
        }
        </div>
    );
};

export default AnimalDetail;
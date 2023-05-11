import React, {useContext, useEffect, useMemo, useState} from 'react';
import {useNavigate, useParams} from 'react-router-dom';
import AnimalService from '../../../services/AnimalService';
import {IAnimalDetail} from '../../../models/IAnimalDetail';
import {Button, Checkbox, Label, Modal, Spinner, Table, TextInput} from 'flowbite-react';
import {Context} from '../../../index';
import ModalHuntingSeason from '../Modal/ModalHuntingSeason/ModalHuntingSeason';
import {IHuntingSeason} from '../../../models/IHuntingSeason';
import ModalUpdateAnimal from '../Modal/ModalUpdateAnimal/ModalUpdateAnimal';
import HuntingSeasonService from '../../../services/HuntingSeasonService';

const AnimalDetail = () => {
    const {name} = useParams();
    const [animal, setAnimal] = useState<IAnimalDetail>({
        id:0,
        name:'',
        imageUrl:'horn.jpg',
        description: '',
        huntingSeasons: [],
        tableId: '',
        englishName:''}
    )
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const {store} = useContext(Context);
    const [showModal, setShowModal] = useState(false);
    const [showAnimalModal, setShowAnimalModal] = useState(false);
    const [isCreate, setIsCreate] = useState(false);
    const [dateStart, setDateStart] = useState<Date>(new Date())
    const [dateEnd, setDateEnd] = useState<Date>(new Date())
    const [description, setDescription] = useState("")
    const [selectId, setSelectId] = useState<number>(0)
    const navigate = useNavigate()

    const onClickCreate = () => {
        setDateStart(new Date())
        setDateEnd(new Date())
        setDescription("")
        setIsCreate(true)
        setShowModal(true);
    };

    const onClickShowAnimalModal = () => {
        setShowAnimalModal(true);
    };


    const onClickUpdate = (season:IHuntingSeason) => {
        setSelectId(season.id)
        setDateStart(season.dateStart)
        setDateEnd(season.dateEnd)
        setDescription(season.description)
        setIsCreate(false)
        setShowModal(true);
    };

    const onClickAnimalDelete = async () => {
        await AnimalService.deleteAnimal(animal.name)
        navigate("/animals")
    }

    const onClickDelete = async (id:number) => {
        await HuntingSeasonService.deleteSeason(id)
    };

    const onClose = () => {
        setShowModal(false);
    };

    const onCloseAnimalModal = () => {
        setShowAnimalModal(false);
    };

    const fetch = async ()=> {
        const response = await AnimalService.getByName(name!)
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
            <div className="container mx-auto w-2/3 flex flex-col items-center">
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
                        {
                            store.user.roles.includes("admin") &&
                            <Table.HeadCell>

                            </Table.HeadCell>
                        }
                    </Table.Head>
                    <Table.Body className="divide-y">
                        {animal.huntingSeasons.map((season) =>
                            <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    {`${new Date(season.dateStart).getMonth() + 1}.${new Date(season.dateStart).getDate()}`}
                                </Table.Cell>
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    {`${new Date(season.dateEnd).getMonth() + 1}.${new Date(season.dateEnd).getDate()}`}
                                </Table.Cell>
                                <Table.Cell>
                                    {season.description}
                                </Table.Cell>
                                {
                                    store.user.roles.includes("admin") &&
                                    <Table.Cell >
                                       <Button size="xs" onClick={e => onClickDelete(season.id)} className="mb-1 w-20">Удалить</Button>
                                        <Button size="xs" onClick={e=>onClickUpdate(season)} className="w-20">Обновить</Button>
                                    </Table.Cell>
                                }
                            </Table.Row>
                        )}
                    </Table.Body>
                </Table>

                {
                    store.user.roles.includes("admin") &&
                    <div>
                        <Button onClick={onClickCreate} size="xs" className="mt-3 w-20 self-center">Добавить сезон</Button>
                        <Button onClick={onClickShowAnimalModal} size="xs" className="mt-5 w-20 self-center">Обновить животное</Button>
                        <Button onClick={onClickAnimalDelete} size="xs" className="mt-5 w-20 self-center">Удалить</Button>
                    </div>
                }

                <ModalHuntingSeason showModal={showModal} onClose={onClose} isCreate={isCreate} dateS={dateStart}
                dateE={dateEnd} descript={description} id={selectId} animalId={animal.id!}/>

                <ModalUpdateAnimal showModal={showAnimalModal} onClose={onCloseAnimalModal} animal={animal}/>
             </div>
           :
           <Spinner/>
        }
        </div>
    );
};

export default AnimalDetail;
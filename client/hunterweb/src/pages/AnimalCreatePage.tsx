import React, {useRef, useState} from 'react';
import InputField from '../components/UI/InputField/InputField';
import {Button, FileInput, Label, Textarea, TextInput} from 'flowbite-react';
import AnimalService from '../services/AnimalService';
import {useNavigate} from 'react-router-dom';
import {IAnimalDetail} from '../models/IAnimalDetail';

const AnimalCreatePage = () => {
    const [name, setName] = useState("")
    const imageUrl = useRef<HTMLInputElement>(null)
    const [description, setDescription] = useState("")
    const [englishName, setEnglishName] = useState("")
    const navigate = useNavigate()

    const fetch = async () => {
        const url = imageUrl.current?.files?.[0].name

        if(url) {
            const animal: IAnimalDetail = {
                name: name,
                englishName: englishName,
                description: description,
                imageUrl: url!,
                tableId: "",
                huntingSeasons: []
            }

            await AnimalService.createAnimal(animal)
        }
    }
    const handly = () => {
        navigate("/animals")
    }

    return (
        <div className="container mx-auto w-1/3">
            <form className="flex flex-col gap-4 max-w-7xl" onSubmit={
                () => {

                    fetch();
                    //handly();
                }
            }>
                <InputField id="email1"
                            type="text"
                            required={true}
                            labelValue="Имя"
                            onChange={(e: any) => setName(e.target.value)}
                            value={name}
                            />
                <InputField id="englishname"
                            type="text"
                            required={true}
                            labelValue="Английское имя"
                            onChange={(e: any) => setEnglishName(e.target.value)}
                            value={englishName}
                />
                <div id="textarea">
                    <div className="mb-2 block">
                        <Label
                            htmlFor="comment"
                            value="Description"
                        />
                    </div>
                    <Textarea
                        id="comment"
                        placeholder="Leave a comment..."
                        required={true}
                        rows={4}
                        value={description}
                        onChange={(e: any) => setDescription(e.target.value)}
                    />
                </div>
                <FileInput id="email1"

                       required={true}
                       ref={imageUrl}/>


                <Button type="submit" className="w-1/2 self-center">Создать</Button>
            </form>
        </div>
    );
};

export default AnimalCreatePage;
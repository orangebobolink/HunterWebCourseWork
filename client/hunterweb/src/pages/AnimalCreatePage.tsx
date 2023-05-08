import React, {useState} from 'react';
import InputField from '../components/UI/InputField/InputField';
import {Button, Label, Textarea} from 'flowbite-react';
import AnimalService from '../services/AnimalService';
import {useNavigate} from 'react-router-dom';

const AnimalCreatePage = () => {
    const [name, setName] = useState("")
    const [imageUrl, serImageUrl] = useState("")
    const [description, setDescription] = useState("")
    const [englishName, setEnglishName] = useState("")
    const navigate = useNavigate()

    const fetch = async () => {
        await AnimalService.createAnimal(name,englishName, description, imageUrl )
    }
    const handly = () => {
        navigate("/")
    }

    return (
        <div className="container mx-auto w-1/3">
            <form className="flex flex-col gap-4 max-w-7xl" onSubmit={
                () => {
                    fetch();
                    handly();
                }
            }>
                <InputField id="email1"
                            type="text"
                            required={true}
                            labelValue="Имя"
                            onChange={(e: any) => setName(e.target.value)}
                            value={name}
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
                <InputField id="email1"
                            type="file"
                            required={true}
                            labelValue="Файл"
                            onChange={(e: any) => serImageUrl(e.target.value)}
                            value={imageUrl}
                />

                <Button type="submit" className="w-1/2 self-center">Создать</Button>
            </form>
        </div>
    );
};

export default AnimalCreatePage;
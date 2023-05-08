import React, {FC, useState} from 'react';
import {Button, Label, Modal, Textarea} from 'flowbite-react';
import InputField from '../InputField/InputField';
import {IAnimalDetail} from '../../../models/IAnimalDetail';

interface Props{
    showModal:boolean,
    onClose:()=>(void),
    animal:IAnimalDetail
}

const ModalUpdateAnimal : FC<Props> = ({showModal, onClose, animal}) => {

    const [name, setName] = useState(animal.name)
    const [imageUrl, setImageUrl] = useState("")
    const [description, setDescription] = useState(animal.description)

    return (
        <Modal show={showModal} size="md" popup={true} onClose={() => {
            onClose()
        }}>
            <Modal.Header />
            <Modal.Body>
                <div className="space-y-6 px-6 pb-4 sm:pb-6 lg:px-8 xl:pb-8">
                    <form>

                        <h3 className="text-xl font-medium text-gray-900 dark:text-white">
                             <p>Обновите трофей</p>
                        </h3>
                        <InputField id="dateStart"
                                    type="text"
                                    required={true}
                                    labelValue="Имя"
                                    value={name}
                                    onChange={(e: any) => setName(e.target.value)}/>
                        <InputField id="dateEnd" type="file" required={true} labelValue="Изображение"
                                    value={imageUrl}
                                    onChange={(e: any) => setImageUrl(e.target.value)}/>
                        <div id="textarea">
                            <div className="mb-2 block">
                                <Label
                                    htmlFor="comment"
                                    value="Ваш отзыв"
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
                        <div className="w-full mt-3">
                            <Button type="submit">
                                    Обновить
                            </Button>
                        </div>

                    </form>
                </div>

            </Modal.Body>
        </Modal>
    );
};

export default ModalUpdateAnimal;
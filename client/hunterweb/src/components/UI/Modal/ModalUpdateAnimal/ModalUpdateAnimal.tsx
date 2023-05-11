import React, {FC, useRef, useState} from 'react';
import {Button, FileInput, Label, Modal, Textarea} from 'flowbite-react';
import InputField from '../../InputField/InputField';
import {IAnimalDetail} from '../../../../models/IAnimalDetail';
import AnimalService from '../../../../services/AnimalService';

interface Props{
    showModal:boolean,
    onClose:()=>(void),
    animal:IAnimalDetail
}

const ModalUpdateAnimal : FC<Props> = ({showModal, onClose, animal}) => {
    const textAreaRef = useRef<HTMLTextAreaElement>(null);
    const [name, setName] = useState(animal.name)
    const imageUrl = useRef<HTMLInputElement>(null)
    const [description, setDescription] = useState(animal.description)

    return (
        <Modal show={showModal} size="md" popup={true} onClose={() => {
            onClose()
        }}>
            <Modal.Header />
            <Modal.Body>
                <div className="space-y-6 px-6 pb-4 sm:pb-6 lg:px-8 xl:pb-8">
                    <form onSubmit={async ()=> {
                        //const url = imageUrl.current?.files?.[0].name

                        //animal.imageUrl = url
                        animal.description = textAreaRef.current?.value!
                        debugger
                        await AnimalService.updateAnimal(animal)
                        onClose()

                    }}>

                        <h3 className="text-xl font-medium text-gray-900 dark:text-white">
                             <p>Обновите трофей</p>
                        </h3>

                        <FileInput id="dateEnd" required={false}
                                    ref={imageUrl}
                                    placeholder="Файл не выбран"
                                    />
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
                                ref={textAreaRef}
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
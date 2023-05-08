import React, {FC, useEffect, useMemo, useState} from 'react';
import {Button, Label, Modal, Textarea} from 'flowbite-react';
import InputField from '../../InputField/InputField';

interface Props{
    showModal:boolean,
    onClose:()=>(void),
    isCreate:boolean,
    dateS: Date,
    dateE: Date,
    descript:string,
}

const ModalHuntingSeason:FC<Props> = ({showModal,onClose, isCreate, dateS,dateE,descript}) => {
    const [dateStart, setDateStart] = useState<Date>(new Date())
    const [dateEnd, setDateEnd] = useState<Date>(new Date())
    const [description, setDescription] = useState("")

    const fetch = () => {
        debugger
        setDateStart(new Date(dateS))
        setDateEnd(new Date(dateE))
        setDescription(descript)
    }

    useMemo(() => {
        fetch()
    }, [dateS,dateE,descript, isCreate]);

    return (
        <Modal show={showModal} size="md" popup={true} onClose={() => {
            onClose()
        }}>
            <Modal.Header />
            <Modal.Body>
                <div className="space-y-6 px-6 pb-4 sm:pb-6 lg:px-8 xl:pb-8">
                     <form>

                        <h3 className="text-xl font-medium text-gray-900 dark:text-white">
                            {isCreate?
                            <p>Создайте новый сезон</p>
                            :
                            <p>Обновите сезон</p>}
                        </h3>
                        <InputField id="dateStart"
                                    type="date"
                                    required={true}
                                    labelValue="Дата начало"
                                    value={dateStart}
                                    onChange={(e: any) => setDateStart(e.target.value)}/>
                        <InputField id="dateEnd" type="date" required={true} labelValue="Дата окончания"
                                    value={dateEnd}
                                    onChange={(e: any) => setDateEnd(e.target.value)}/>
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
                                {
                                    isCreate
                                    ?
                                        "Создать"
                                    :
                                        "Обновить"
                                }
                            </Button>
                        </div>

                    </form>
                </div>

            </Modal.Body>
        </Modal>
    );
};

export default ModalHuntingSeason;
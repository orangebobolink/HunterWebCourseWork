import React, {FC, useEffect, useMemo, useRef, useState} from 'react';
import {Button, Label, Modal, Textarea} from 'flowbite-react';
import InputField from '../../InputField/InputField';
import HuntingSeasonService from '../../../../services/HuntingSeasonService';
import {IHuntingSeason} from '../../../../models/IHuntingSeason';

interface Props{
    showModal:boolean,
    onClose:()=>(void),
    isCreate:boolean,
    dateS: Date,
    dateE: Date,
    descript:string,
    id:number,
    animalId:number
}

const ModalHuntingSeason:FC<Props> = ({showModal,onClose, isCreate, id, dateS,dateE,descript,animalId}) => {
    const [dateStart, setDateStart] = useState<Date>(dateS)
    const [dateEnd, setDateEnd] = useState<Date>(dateE)
    const [description, setDescription] = useState(descript)

   // const fetch = () => {
    //    debugger
    //    setDateStart(new Date(dateS))
    //    setDateEnd(new Date(dateE))
    //    setDescription(descript)
    //}



   // useMemo(() => {
   //     fetch()
    //}, [dateS,dateE,descript, isCreate]);

    return (
        <Modal show={showModal} size="md" popup={true} onClose={() => {
            onClose()
        }}>
            <Modal.Header />
            <Modal.Body>
                <div className="space-y-6 px-6 pb-4 sm:pb-6 lg:px-8 xl:pb-8">
                     <form onSubmit={async () => {
                         const season : IHuntingSeason = {
                             id:id,
                             dateStart:dateStart,
                             dateEnd:dateEnd,
                             description:description,
                             animalId:animalId
                         }

                         if(isCreate) {
                             await HuntingSeasonService.create(season)
                         } else {
                             await HuntingSeasonService.update(season)
                         }
                     }}>

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
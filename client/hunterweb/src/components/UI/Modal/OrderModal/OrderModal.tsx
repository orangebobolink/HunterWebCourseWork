import React, {FC, useContext, useEffect, useState} from 'react';
import {Button, Label, Modal, Textarea} from 'flowbite-react';
import {IOrderDetail} from '../../../../models/IOrderDetail';
import {IUserDetail} from '../../../../models/IUserDetail';
import UserService from '../../../../services/UserService';

interface Props{
    showModal:boolean,
    onClose:()=>(void),
    order:IOrderDetail,
}

const OrderModal : FC<Props> = ({showModal, onClose, order}) => {
    const [user, setUser] = useState<IUserDetail>({
        firstName:"",
        phone:"",
        roles:[""],
        messangerName:"",
        email:""
    });

    const [isLoading, setIsLoading] = useState<boolean>(false);

    const fetchData = async () => {
        const response = await UserService.getByEmail(order.userEmail);
        setUser(response.data)
        setIsLoading(false)
    }

    useEffect(() => {
        setIsLoading(true)
        fetchData()
    }, [order]);

    return (
        <Modal show={showModal} size="md" popup={true} onClose={() => {
            onClose()
        }}>
            <Modal.Header />
            <Modal.Body>
                <div className="space-y-6">
                    <p className="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                        Электронная почта:&nbsp;{order.userEmail}
                    </p>
                    <p className="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                        Номер телефона:&nbsp;{user.phone}
                    </p>
                    <p className="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                        Мессанджер:&nbsp;{user.messangerName}
                    </p>
                    <p className="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                        Животные:&nbsp;{order.animalInfo}
                    </p>
                    <p className="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                        Количество дней:&nbsp;{order.countDates}
                    </p>
                    <p className="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                        Включить проживание:&nbsp;
                        {order.includeHouse ?
                        "Да": "Нет"}
                    </p>

                </div>
            </Modal.Body>
        </Modal>
    );
};

export default OrderModal;
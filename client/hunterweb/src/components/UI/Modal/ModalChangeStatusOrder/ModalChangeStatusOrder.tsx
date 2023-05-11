import React, {FC, useContext, useEffect, useState} from 'react';
import {Button, Label, Modal, Radio, Spinner, Textarea, TextInput} from 'flowbite-react';
import {IOrderDetail} from '../../../../models/IOrderDetail';
import {IUserDetail} from '../../../../models/IUserDetail';
import UserService from '../../../../services/UserService';
import {IStatus} from '../../../../models/IStatus';
import StatusService from '../../../../services/StatusService';
import {stat} from 'fs';
import OrderService from '../../../../services/OrderService';

interface Props{
    showModal:boolean,
    onClose:()=>(void),
    order:IOrderDetail,
}

const OrderModal : FC<Props> = ({showModal, onClose, order}) => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [selectStatus, setSelectStatus] = useState<string>("");
    const [statuses, setStatuses] = useState<IStatus[]>([{id:0, name:""}]);

    const fetchData = async () => {
        const response = await StatusService.getAll();
        setStatuses(response.data)
        setIsLoading(false)
    }

    useEffect(() => {
        setIsLoading(true)
        fetchData()
    }, [order]);

    const onClick = async () => {
        const status : IStatus = statuses.find(s => s.name === selectStatus)!
        order.statusName = status.name
        debugger
        await OrderService.update(order);
    }

    return (
        <Modal show={showModal} size="md" popup={true} onClose={() => {
            onClose()
        }}>
            <Modal.Header />
            <Modal.Body>
                <div className="space-y-6">
                    {!isLoading
                     ?

                            statuses.map((status)=>
                                status.name !== order.statusName &&
                                <div className="flex items-center gap-2">
                                    <Radio id={status.name}
                                           name="statuses"
                                           value={status.name}

                                           onChange={e=> setSelectStatus(e.target.value)}
                                    />
                                    <Label
                                        htmlFor={status.name}
                                        disabled={true}
                                    >
                                        {status.name}
                                    </Label>
                                </div>
                            )

                     : <Spinner/>}


                    <Button onClick={onClick}>Обновить</Button>
                </div>
            </Modal.Body>
        </Modal>
    );
};

export default OrderModal;
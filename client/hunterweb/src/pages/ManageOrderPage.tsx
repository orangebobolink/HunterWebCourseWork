import React, {useEffect, useState} from 'react';
import {IUserDetail} from '../models/IUserDetail';
import UserService from '../services/UserService';
import {IOrder} from '../models/IOrder';
import OrderService from '../services/OrderService';
import {Modal, Spinner} from 'flowbite-react';
import InformationUserTable from '../components/UI/table/InformationUserTable/InformationUserTable';
import OrderTable from '../components/UI/table/OrderTable/OrderTable';
import OrderModal from '../components/UI/Modal/OrderModal/OrderModal';
import {IOrderDetail} from '../models/IOrderDetail';
import ModalChangeStatusOrder from '../components/UI/Modal/ModalChangeStatusOrder/ModalChangeStatusOrder';

const ManageOrderPage = () => {
    const [isLoading, setIsLoading] = useState(false)
    const [orders, setOrders] = useState<IOrderDetail[]>([{
        id:0,
        userEmail: "",
        numberHunters: 0,
        countDates:0,
        includeHouse:false,
        additionalInfo:"",
        filingDate:new Date(),
        animalInfo:"",
        statusName:""
    }])
    const [selectOrder, setSelectOrder] = useState<IOrderDetail>({
        id:0,
        userEmail: "",
        numberHunters: 0,
        countDates:0,
        includeHouse:false,
        additionalInfo:"",
        filingDate:new Date(),
        animalInfo:"",
        statusName:""
    })

    const [showModal, setShowModal] = useState(false);
    const [showChangeModal, setShowChangeModal] = useState(false);

    const onClose = () => {
        setShowModal(false);
    };

    const onCloseChanges = () => {
        setShowChangeModal(false);
    };

    const onClick = (order:IOrderDetail) => {
        setSelectOrder(order)
        setShowModal(true);
    };

    const onClickChange = (order:IOrderDetail) => {
        setSelectOrder(order)
        setShowChangeModal(true);
    };

    const fetchData = async () => {
        const response = await OrderService.getAllDetails()
        setOrders(response.data)
        setIsLoading(true)
    }

    useEffect(() => {
        setIsLoading(true)
        fetchData()
    }, []);

    return (
        <div>
            {
                isLoading
                ?
                <div className="container mx-auto w-2/3">
                    <OrderTable orders={orders} onClick={onClick} onClickChange={onClickChange}/>
                </div>
                :
                    <Spinner/>
            }

            <OrderModal showModal={showModal} onClose={onClose} order={selectOrder}/>
            <ModalChangeStatusOrder showModal={showChangeModal} onClose={onCloseChanges} order={selectOrder}/>
        </div>
    );
};

export default ManageOrderPage;
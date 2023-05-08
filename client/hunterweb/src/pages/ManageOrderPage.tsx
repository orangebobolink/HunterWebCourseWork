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

const ManageOrderPage = () => {
    const [isLoading, setIsLoading] = useState(false)
    const [orders, setOrders] = useState<IOrder[]>([{
        id:0,
        userEmail: "",
        numberHunters: 0,
        countDates:0,
        includeHouse:false,
        additionalInfo:""
    }])
    const [selectOrderId, setSelectOrderId] = useState<number>(0)
    const [selectUserEmail, setSelectUserEmail] = useState<string>("")

    const [showModal, setShowModal] = useState(false);

    const onClose = () => {
        setShowModal(false);
    };

    const onClick = (order:IOrder) => {
        setSelectUserEmail(order.userEmail)
        setSelectOrderId(order.id)
        setShowModal(!showModal);
    };

    const fetchData = async () => {
        const response = await OrderService.getAll()
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
                    <OrderTable orders={orders}/>
                :
                    <Spinner/>
            }

            <OrderModal showModal={showModal} onClose={onClose} orderId={selectOrderId} userEmail={selectUserEmail}/>
        </div>
    );
};

export default ManageOrderPage;
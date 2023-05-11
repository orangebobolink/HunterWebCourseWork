import React, {FC} from 'react';
import {Button, Table} from 'flowbite-react';
import RolesDropdown from '../../Dropdown/RolesDropdown';
import {IOrder} from '../../../../models/IOrder';
import {IOrderDetail} from '../../../../models/IOrderDetail';

interface Props{
    order:IOrderDetail,
    onClick:(order:IOrderDetail)=>(void)
    onClickChange:(order:IOrderDetail)=>(void)
}

const OrderTableRow : FC<Props>= ({order, onClick, onClickChange}) => {
    return (
        <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
            <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                {order.userEmail}
            </Table.Cell>
            <Table.Cell>
                {(new Date(order.filingDate)).toDateString()}
            </Table.Cell>
            <Table.Cell>
                {order.statusName === "todo" && "Новый"}
                {order.statusName === "doing" && "В расмотрении"}
                {order.statusName === "done" && "Расмотрен"}
            </Table.Cell>
            <Table.Cell>
                <button
                    onClick={e => onClick(order)}
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                >
                    Информация
                </button>
            </Table.Cell>
            <Table.Cell>
                <button
                    onClick={e => onClickChange(order)}
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                >
                    Изменить статус
                </button>
            </Table.Cell>
        </Table.Row>
    );
};

export default OrderTableRow;
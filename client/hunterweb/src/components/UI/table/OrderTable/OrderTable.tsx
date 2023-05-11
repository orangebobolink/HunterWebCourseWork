import React, {FC} from 'react';
import {IOrder} from '../../../../models/IOrder';
import {Table} from 'flowbite-react';
import RolesDropdown from '../../Dropdown/RolesDropdown';
import InformationUserRow from '../InformationUserTable/InformationUser.Row';
import OrderTableRow from './OrderTable.Row';
import {IOrderDetail} from '../../../../models/IOrderDetail';

interface Props {
    orders:IOrderDetail[],
    onClick:(order:IOrderDetail)=>(void)
    onClickChange:(order:IOrderDetail)=>(void)
}

const OrderTable : FC<Props> = ({orders, onClick, onClickChange}) => {
    return (
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                    Электронная почта
                </Table.HeadCell>
                <Table.HeadCell>
                    Дата подачи
                </Table.HeadCell>
                <Table.HeadCell>
                    Статус
                </Table.HeadCell>
                <Table.HeadCell>
                  <span className="sr-only">
                    Информация
                  </span>
                </Table.HeadCell>
                <Table.HeadCell>
                  <span className="sr-only">
                    Изменить статус
                  </span>
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
                {
                    orders.map((order)=>
                        <OrderTableRow order={order}
                                       onClick={onClick}
                                       onClickChange={onClickChange}/>
                    )
                }
            </Table.Body>
        </Table>
    );
};

export default OrderTable;
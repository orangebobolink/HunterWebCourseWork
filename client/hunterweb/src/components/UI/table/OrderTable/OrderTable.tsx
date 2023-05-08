import React, {FC} from 'react';
import {IOrder} from '../../../../models/IOrder';
import {Table} from 'flowbite-react';
import RolesDropdown from '../../Dropdown/RolesDropdown';
import InformationUserRow from '../InformationUserTable/InformationUser.Row';
import OrderTableRow from './OrderTable.Row';

interface Props {
    orders:IOrder[]
}

const OrderTable : FC<Props> = ({orders}) => {
    return (
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                    Номер
                </Table.HeadCell>
                <Table.HeadCell>
                    Дата подачи
                </Table.HeadCell>
                <Table.HeadCell>
                    Электронная почта подавшего
                </Table.HeadCell>
                <Table.HeadCell>
                    Статус
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
                {
                    orders.map((order)=>
                        <OrderTableRow order={order}/>

                    )
                }
            </Table.Body>
        </Table>
    );
};

export default OrderTable;
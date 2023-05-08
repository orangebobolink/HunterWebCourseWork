import React, {FC} from 'react';
import {Table} from 'flowbite-react';
import RolesDropdown from '../../Dropdown/RolesDropdown';
import {IOrder} from '../../../../models/IOrder';

interface Props{
    order:IOrder
}

const OrderTableRow : FC<Props>= ({order}) => {
    return (
        <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
            <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                {user.email}
            </Table.Cell>
            <Table.Cell>
                {user.firstName}
            </Table.Cell>
            <Table.Cell>
                {user.phone}
            </Table.Cell>
            <Table.Cell>
                {user.messangerName}
            </Table.Cell>
            <Table.Cell>
                <RolesDropdown roles={user.roles} email={user.email}   />
            </Table.Cell>
        </Table.Row>
    );
};

export default OrderTableRow;
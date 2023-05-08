import React, {FC} from 'react';
import {Table} from 'flowbite-react';
import {IUser} from '../../../../models/IUser';
import {IUserDetail} from '../../../../models/IUserDetail';
import RolesDropdown from '../../Dropdown/RolesDropdown';

interface Props{
    user:IUserDetail
}

const InformationUserRow:FC<Props> = ({user}) => {

    const onClick = (email:string) => {

    }

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
            <Table.Cell>
                <button
                    onClick={e => onClick(user.email)}
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                >
                    Удалить
                </button>
            </Table.Cell>
        </Table.Row>
    );
};

export default InformationUserRow;
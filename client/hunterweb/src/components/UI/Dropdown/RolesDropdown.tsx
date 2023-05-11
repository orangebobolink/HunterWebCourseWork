import React, {FC} from 'react';
import {Dropdown} from 'flowbite-react';
import InformationUserRow from '../table/InformationUserTable/InformationUser.Row';
import RolesDropdownItem from './RolesDropdown.Item';
import {debug} from 'util';
import {IUserDetail} from '../../../models/IUserDetail';

interface Props {
    user:IUserDetail,
    onClickAddRole:(user:IUserDetail) => (void)
}

const RolesDropdown :FC<Props> = ({user, onClickAddRole}) => {


    return (
        <Dropdown
            label="Нажми чтобы узреть роли"
            inline={true}
            size="lg"
        >
            {
                user.roles.map((role) =>
                    <RolesDropdownItem role={role} user={user}/>
                )
            }
            <Dropdown.Item>
                <button
                    onClick={e => onClickAddRole(user)}
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                >
                    Добавить
                </button>
            </Dropdown.Item>
        </Dropdown>
    );
};

export default RolesDropdown;
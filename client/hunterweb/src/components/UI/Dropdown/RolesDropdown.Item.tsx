import React, {FC} from 'react';
import {Dropdown} from 'flowbite-react';
import RoleService from '../../../services/RoleService';
import UserService from '../../../services/UserService';
import {IUserDetail} from '../../../models/IUserDetail';

interface Props {
    role:string,
    user:IUserDetail
}

const RolesDropdownItem : FC<Props> = ({role, user}) => {
    return (
        <Dropdown.Item className="flex justify-between">
            <span>
                {role}
            </span>
            <span>
                <button
                    onClick={()=> {
                        user.roles = user.roles.filter(r => r !== role)
                        UserService.updateRole(user)
                    }}
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                >
                    Удалить
                </button>
            </span>
        </Dropdown.Item>
    );
};

export default RolesDropdownItem;
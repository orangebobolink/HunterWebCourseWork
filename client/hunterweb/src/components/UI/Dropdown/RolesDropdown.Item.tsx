import React, {FC} from 'react';
import {Dropdown} from 'flowbite-react';
import RoleService from '../../../services/RoleService';

interface Props {
    role:string,
    email:string
}

const RolesDropdownItem : FC<Props> = ({role, email}) => {
    return (
        <Dropdown.Item className="flex justify-between">
            <span>
                {role}
            </span>
            <span>
                <button
                    onClick={()=> {
                        RoleService.deleteRole(email, role)
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
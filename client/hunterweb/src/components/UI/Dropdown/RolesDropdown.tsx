import React, {FC} from 'react';
import {Dropdown} from 'flowbite-react';
import InformationUserRow from '../table/InformationUserTable/InformationUser.Row';
import RolesDropdownItem from './RolesDropdown.Item';
import {debug} from 'util';

interface Props {
    roles : string[],
    email:string
}

const RolesDropdown :FC<Props> = ({roles, email}) => {

    const onClick = () => {

    }

    return (
        <Dropdown
            label="Нажми чтобы узреть роли"
            inline={true}
            size="lg"
        >
            {
                roles.map((role) =>
                    <RolesDropdownItem role={role} email={email}/>
                )
            }
            <Dropdown.Item>
                <button
                    onClick={e => onClick()}
                    className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                >
                    Добавить
                </button>
            </Dropdown.Item>
        </Dropdown>
    );
};

export default RolesDropdown;
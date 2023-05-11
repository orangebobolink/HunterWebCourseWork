import React, {FC, useContext, useEffect, useState} from 'react';
import {Button, Label, Modal, Radio, Textarea} from 'flowbite-react';
import {IOrderDetail} from '../../../../models/IOrderDetail';
import {IUserDetail} from '../../../../models/IUserDetail';
import UserService from '../../../../services/UserService';
import RoleService from '../../../../services/RoleService';

interface Props{
    showModal:boolean,
    onClose:()=>(void),
    user:IUserDetail
}

const ModalUserRole : FC<Props> = ({showModal, onClose, user}) => {
    const [roles, setRoles] = useState<string[]>([])
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [selectedRole, setSelectedRole] = useState<string>("");

    const fetchData = async () => {
        const response = await RoleService.getAll();
        setRoles(response.data)
        setIsLoading(false)
    }

    useEffect(() => {
        setIsLoading(true)
        fetchData()
    }, []);

    const onClick = () => {

    }

    return (
        <Modal show={showModal} size="md" popup={true} onClose={() => {
            onClose()
        }}>
            <Modal.Header />
            <Modal.Body>
                <div className="space-y-6">
                    {
                        roles.filter(r => !user.roles.includes(r)).length !== 0 ?
                            <div>
                                {
                                    roles.map((r)=>
                                        !user.roles.includes(r) &&
                                        <div className="flex items-center gap-2">
                                            <Radio id={r}
                                                   name="roles"
                                                   value={r}
                                                   onChange={e=> setSelectedRole(e.target.value)}
                                            />
                                            <Label
                                                htmlFor={r}
                                                disabled={true}
                                            >
                                                {r}
                                            </Label>
                                        </div>

                                    )
                                }
                                    <Button onClick={onClick}>Сохранить</Button>
                            </div>
                        :
                        <p>У аккаунта уже все роли</p>
                    }

                </div>
            </Modal.Body>
        </Modal>
    );
};

export default ModalUserRole;
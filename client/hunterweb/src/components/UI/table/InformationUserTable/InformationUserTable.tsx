import React, {FC, useState} from 'react';
import {Table} from 'flowbite-react';
import InformationUserRow from './InformationUser.Row';
import {IUserDetail} from '../../../../models/IUserDetail';
import ModalUserRole from '../../Modal/ModalUserRoles/ModalUserRoles';

interface Props {
    users:IUserDetail[]
}

const InformationUserTable : FC<Props> = ({users}) => {

    const [showModal,setShowModal] = useState(false)
    const [selectUser,setSelectUser] = useState<IUserDetail>({
        firstName:"",
        messangerName:"",
        roles:[""],
        phone:"",
        email:""
    })

    const onClose = () => {
        setShowModal(false)
    }

    const onClickAddRole = (user:IUserDetail) => {
        setSelectUser(user)
        setShowModal(true)
    }

    return (
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                    Электронная почта
                </Table.HeadCell>
                <Table.HeadCell>
                    Имя
                </Table.HeadCell>
                <Table.HeadCell>
                    Телефон
                </Table.HeadCell>
                <Table.HeadCell>
                    Мессанджер
                </Table.HeadCell>
                <Table.HeadCell>
                    Роли
                </Table.HeadCell>
                <Table.HeadCell>
                  <span className="sr-only">
                    Удалить
                  </span>
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
                {
                    users.map((user)=>
                        <InformationUserRow user={user} onClickAddRole={onClickAddRole}/>
                    )
                }
                <ModalUserRole showModal={showModal} onClose={onClose} user={selectUser}/>
            </Table.Body>
        </Table>
    );
};

export default InformationUserTable;
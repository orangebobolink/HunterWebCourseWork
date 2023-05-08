import React, {FC} from 'react';
import {Table} from 'flowbite-react';
import InformationUserRow from './InformationUser.Row';
import {IUserDetail} from '../../../../models/IUserDetail';

interface Props {
    users:IUserDetail[]
}

const InformationUserTable : FC<Props> = ({users}) => {
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
                        <InformationUserRow user={user}/>

                    )
                }
            </Table.Body>
        </Table>
    );
};

export default InformationUserTable;
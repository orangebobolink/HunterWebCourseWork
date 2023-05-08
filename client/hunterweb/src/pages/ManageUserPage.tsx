import React, {useEffect, useState} from 'react';
import {Spinner, Table} from 'flowbite-react';
import InformationUserRow from '../components/UI/table/InformationUserTable/InformationUser.Row';
import {IUserDetail} from '../models/IUserDetail';
import UserService from '../services/UserService';
import InformationUserTable from '../components/UI/table/InformationUserTable/InformationUserTable';

const ManageUserPage = () => {
    const [isLoading, setIsLoading] = useState(false)
    const [users, setUsers] = useState<IUserDetail[]>([{
        firstName:"",
        roles: [""],
        email:"",
        phone:"",
        messangerName:""
    }])

    const fetchData = async () => {
        const response = await UserService.getAll()
        setUsers(response.data)
        setIsLoading(true)
    }

    useEffect(() => {
        setIsLoading(true)
        fetchData()
    }, []);

    return (
        <div>
        {
            !isLoading
            ?
            <InformationUserTable users={users}/>
            :
            <Spinner/>
        }
        </div>
    );
};

export default ManageUserPage;
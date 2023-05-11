import React, {useContext, useEffect, useState} from 'react';
import {IOrderDetail} from '../models/IOrderDetail';
import OrderService from '../services/OrderService';
import {IUserDetail} from '../models/IUserDetail';
import UserService from '../services/UserService';
import {Context} from '../index';
import {Spinner, Table} from 'flowbite-react';
import {Link} from 'react-router-dom';

const InformationUserPage = () => {
    const {store} = useContext(Context)
    const [isLoading, setIsLoading] = useState(false)
    const [user, setUser] = useState<IUserDetail>({
        firstName:"",
        roles:[""],
        messangerName:"",
        email:"",
        phone:""
    })

    const fetchData = async () => {
        const response = await UserService.getByEmail(store.user.email)
        setUser(response.data)
        setIsLoading(false)
    }

    useEffect(() => {
        setIsLoading(true)
        fetchData()
    }, []);

    return (
        <div className="container mx-auto w-1/4">
            {
                !isLoading ?
                <div> 
                    <Table>
                        <Table.Head>

                            <Table.HeadCell>
                              <span className="sr-only">
                                Variable
                              </span>
                            </Table.HeadCell>
                            <Table.HeadCell>
                              <span className="sr-only">
                                Value
                              </span>
                            </Table.HeadCell>
                        </Table.Head>
                        <Table.Body className="divide-y">
                            <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    Имя
                                </Table.Cell>

                                <Table.Cell>
                                    {user.firstName}
                                </Table.Cell>
                            </Table.Row>
                            <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    Email
                                </Table.Cell>

                                <Table.Cell>
                                    {user.email}
                                </Table.Cell>
                            </Table.Row>
                            <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    Телефон
                                </Table.Cell>

                                <Table.Cell>
                                    {user.phone}
                                </Table.Cell>
                            </Table.Row>
                            <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    Мессанджер
                                </Table.Cell>

                                <Table.Cell>
                                    {user.messangerName}
                                </Table.Cell>
                            </Table.Row>

                        </Table.Body>
                    </Table>
                    <Link className="text-white bg-gray-800 hover:bg-gray-900 focus:outline-none focus:ring-4 focus:ring-gray-300 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-2 dark:bg-gray-800 dark:hover:bg-gray-700 dark:focus:ring-gray-700 dark:border-gray-700"
                          to="/settings">
                        Настройки
                    </Link>
                </div>
                :
                    <Spinner/>
            }
        </div>

    );
};

export default InformationUserPage;
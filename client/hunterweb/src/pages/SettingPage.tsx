import React, {useContext, useEffect, useState} from 'react';
import {Accordion, Button, Sidebar, Spinner} from 'flowbite-react';
import {Context} from '../index';
import {IUserDetail} from '../models/IUserDetail';
import UserService from '../services/UserService';
import SettingCard from '../components/UI/Card/SettingCard';

const SettingPage = () => {
    const [visible, setVisible] = useState(false);
    const [render, setRender] = useState(false);
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
         <div>
            { !isLoading ?
                   <div className="container mx-auto w-1/3 mt-10 flex justify-between flex-col">
                       <div>
                           <SettingCard value={user.firstName} type="text" title="Имя" onClick={(value:string)=>{
                               var newuser = user
                               newuser.firstName = value
                               setUser(newuser)
                               UserService.update(user)
                           }}/>
                           <SettingCard value={user.phone} type="number" min={10000000} max={99999999} title="Телефон" onClick={(value:string)=>{
                               var newuser = user
                               newuser.phone = value
                               setUser(newuser)
                               UserService.update(user)
                           }}/>

                       </div>

                   </div>
                :
                    <Spinner/>

            }
         </div>
    );
};

export default SettingPage;
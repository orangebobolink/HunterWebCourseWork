import React, {FC, useContext, useState} from 'react';
import {Context} from '../../../index';
import {observer} from 'mobx-react-lite';
import "./LoginForm.module.css"
import cl from './LoginForm.module.css';
import DefaultInput from "../input/DefaultInput"
import DefaultButton from '../button/DefaultButton/DefaultButton';
import {Navigate, useNavigate} from 'react-router-dom';
import {Button, Label, TextInput} from 'flowbite-react';
import LinkButton from '../button/LinkButton/LinkButton';
import InputField from '../InputField/InputField';

const LoginForm: FC = () => {
    const [email, setEmail] = useState<string>('');
    const [password, setPassword] = useState('');
    const {store} = useContext(Context);
    const navigate = useNavigate();

    function handleRef() {
        return navigate(`/register`);
    }

    if (store.isAuth) {
        return <Navigate to='/'/>;
    }


    return (
        <div className="container mx-auto w-1/3">
            <form className="flex flex-col gap-4 max-w-7xl" onSubmit={
                () => {
                    store.login(email, password);
                }
            }>
                <InputField id="email1" type="email" required={true} labelValue="Электронная почта"
                            onChange={(e: any) => setEmail(e.target.value)}
                            value={email}
                            placeholder="name@flowbite.com"
                />

                <InputField id="password1" type="password" required={true} labelValue="Пароль"
                            onChange={(e: any) => setPassword(e.target.value)}
                            value={password}
                />

                <Button className='w-2/3 self-center' type="submit">Войти</Button>
                <Button className='w-2/3 self-center' onClick={handleRef} >Регистрация</Button>
            </form>
        </div>
);
};

export default observer(LoginForm);

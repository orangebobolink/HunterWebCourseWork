import React from 'react';
import LoginForm from '../components/UI/LoginForm/LoginForm';
import {observer} from 'mobx-react-lite';

const AuthPage = () => {
    return (
        <LoginForm/>
    );
};

export default observer(AuthPage);
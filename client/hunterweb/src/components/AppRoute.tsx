import React from 'react';
import {Route, Routes} from 'react-router-dom';
import HomePage from '../pages/HomePage';
import ErrorPage from '../pages/ErrorPage';
import AnimalPage from '../pages/AnimalPage';
import LoginPage from '../pages/LoginPage';
import RegisterPage from '../pages/RegisterPage';

const AppRoute = () => {
    return (
        <Routes>
            <Route path='/login'
                   element={<LoginPage/>}/>
            <Route path='/register'
                   element={<RegisterPage/>}/>
            <Route path='/animals'
                   element={<AnimalPage/>}/>
            <Route path='/'
                   element={<HomePage/>}/>
            <Route path='*'
                   element={<ErrorPage/>}/>
        </Routes>
    );
};

export default AppRoute;
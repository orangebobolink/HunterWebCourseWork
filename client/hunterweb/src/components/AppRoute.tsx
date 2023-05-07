import React, {useContext} from 'react';
import {Route, Routes} from 'react-router-dom';
import HomePage from '../pages/HomePage';
import ErrorPage from '../pages/ErrorPage';
import AnimalPage from '../pages/AnimalPage';
import LoginPage from '../pages/LoginPage';
import RegisterPage from '../pages/RegisterPage';
import AnimalDetail from './UI/AnimalDetail/AnimalDetail';
import AnimalCreatePage from '../pages/AnimalCreatePage';
import FeedbackPage from '../pages/FeedbackPage';
import {Context} from '../index';
import OrderPage from '../pages/OrderPage';

const AppRoute = () => {
    const {store} = useContext(Context)

    return (
        <Routes>
            <Route path='/feedback'
                   element={<FeedbackPage/>}/>
            <Route path='/login'
                   element={<LoginPage/>}/>
            <Route path='/order'
                   element={<OrderPage/>}/>
            <Route path='/register'
                   element={<RegisterPage/>}/>
            <Route path='/animalcreate'
                   element={<AnimalCreatePage/>}/>
            <Route path='/animals/:name'
                   element={<AnimalDetail/>}/>
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
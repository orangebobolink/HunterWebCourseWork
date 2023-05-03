import React, {useContext, useEffect} from 'react';
import './styles/App.css';
import AppRoute from './components/AppRoute';
import {BrowserRouter} from 'react-router-dom';
import Footer from './components/UI/footer/Footer';
import {Navbar} from 'flowbite-react';
import DefaultNavbar from './components/UI/navbar/DefaultNavbar';
import {observer} from 'mobx-react-lite';
import {Context} from './index';

function App() {
    const {store} = useContext(Context);

    useEffect(() => {
        if (localStorage.getItem('token')) {
            store.checkAuth();
        }
    }, []);

  return (
      <BrowserRouter>
        <div className='App'>
            <DefaultNavbar/>
            <div className="wrapper">
                <AppRoute/>
            </div>
            <div className="footer">
                <Footer/>
            </div>

        </div>
      </BrowserRouter>
  );
}

export default observer(App);

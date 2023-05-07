import React, {useContext} from 'react';
import {Avatar, Dropdown, Navbar} from 'flowbite-react';
import logo from "../../../images/logo.jpg"
import {observer} from 'mobx-react-lite';
import {Context} from '../../../index';
import LinkButton from '../button/LinkButton/LinkButton';
import {useNavigate} from 'react-router-dom';

const DefaultNavbar = () => {
    const {store} = useContext(Context);
    const navigate = useNavigate()

    const handleRef = () => {
        navigate("/")
    }

    return (
        <Navbar
            fluid={true}
            rounded={true}
        >
            <Navbar.Brand onClick={handleRef}>
                <img
                    src={logo}
                    className="mr-3 h-6 sm:h-9"
                    alt="Logo"
                />
                <span className="self-center whitespace-nowrap text-xl font-semibold dark:text-white">
                  Hunter
                </span>
            </Navbar.Brand>
            {store.isAuth
             ?
             <div className="flex md:order-2">
                 <Dropdown
                     arrowIcon={false}
                     inline={true}
                     label={<Avatar alt="User settings" img="https://flowbite.com/docs/images/people/profile-picture-5.jpg" rounded={true}/>}
                 >
                     <Dropdown.Header>
                         <span className="block truncate text-sm font-medium">
                          {store.user.email}
                        </span>
                     </Dropdown.Header>
                     <Dropdown.Item>
                         Информация
                     </Dropdown.Item>
                     <Dropdown.Item>
                         Настройки
                     </Dropdown.Item>
                     <Dropdown.Divider />
                     <Dropdown.Item onClick={()=>{
                       store.logout()
                     }}>
                         Выйти
                     </Dropdown.Item>
                 </Dropdown>
                 <Navbar.Toggle />
             </div>
             :
             <div className="flex md:order-2">
                <LinkButton to="/login">Войти</LinkButton>
             </div>
            }

            <Navbar.Collapse>
                <Navbar.Link
                    href="/"
                    active={true}
                >
                    Главная
                </Navbar.Link>
                <Navbar.Link href="/animals">
                    Трофеи
                </Navbar.Link>
                <Navbar.Link href="/order">
                    Оформить заказ
                </Navbar.Link>
                <Navbar.Link href="/feedback">
                    Отзывы
                </Navbar.Link>
                <Navbar.Link href="/contacts">
                    Контакты
                </Navbar.Link>
            </Navbar.Collapse>
        </Navbar>
    );
};

export default observer(DefaultNavbar);
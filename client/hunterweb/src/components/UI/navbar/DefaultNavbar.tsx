import React, {useContext} from 'react';
import {Avatar, Dropdown, Navbar} from 'flowbite-react';
import logo from "../../../images/logo.jpg"
import {observer} from 'mobx-react-lite';
import {Context} from '../../../index';
import LinkButton from '../button/LinkButton/LinkButton';
import {Link, useNavigate} from 'react-router-dom';

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
                         <Link to="/information">
                            Информация
                         </Link>
                     </Dropdown.Item>
                     <Dropdown.Item>
                         <Link to="/setting">
                            Настройки
                         </Link>
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
                    <Link to="/">Главная</Link>
                </Navbar.Link>
                <Navbar.Link>
                    <Link to="/animals">Трофеи</Link>
                </Navbar.Link>
                {
                    store.user.roles.includes("user")
                    &&
                        <Navbar.Link>
                            <Link to="/order">Оформить заказ</Link>
                        </Navbar.Link>

                }

                {
                    store.user.roles.includes("moderator")
                    &&
                    <Navbar.Link>
                        <Link to="/manageorder"> Управление заказами</Link>
                    </Navbar.Link>

                }

                {
                    store.user.roles.includes("admin")
                    &&
                    <Navbar.Link >
                        <Link to="/manageuser">Управление пользователями</Link>
                    </Navbar.Link>
                }
                <Navbar.Link>
                    <Link to="/manageuser">Отзывы</Link>
                </Navbar.Link>
                <Navbar.Link >
                    <Link to="/contacts">Контакты</Link>
                </Navbar.Link>
            </Navbar.Collapse>
        </Navbar>
    );
};

export default observer(DefaultNavbar);
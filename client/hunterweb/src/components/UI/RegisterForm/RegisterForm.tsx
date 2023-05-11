import React, {useContext, useEffect, useState} from 'react';
import {Button, Checkbox, Dropdown, Label, TextInput} from 'flowbite-react';
import {Context} from '../../../index';
import {observer} from 'mobx-react-lite';
import {IRegisterUser} from '../../../models/IRegisterUser';
import MessangerService from '../../../services/MessangerService';
import InputField from '../InputField/InputField';

const RegisterForm = () => {
    const {store} = useContext(Context)
    const [email, setEmail] = useState("");
    const [phone, setPhone] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [selectedMessnager, setSelectedMessnager] = useState("");
    const [messangers, setMessangers] = useState([""])

    const fetch = async ()=> {
        const response = await MessangerService.getAll()
        console.log(response.data)
        setMessangers(response.data)
    }

    useEffect(() => {
        fetch()
    }, []);

    const onClick = (m:string) => {
        setSelectedMessnager(m)
    }

    return (
        <div className="container mx-auto w-1/3">
            <form className="flex flex-col gap-4" onSubmit={
                () => {
                    const user : IRegisterUser = {
                        email:email,
                        phone:phone,
                        password:password,
                        firstName: firstName,
                        messangerName:selectedMessnager
                    }
                    store.registration(user)
                }
            }>
                <InputField id="s"
                            type="email"
                            required={true}
                            labelValue="Электронная почта"
                            placeholder="email@mail.ru"
                            value={email}
                            onChange={e=>setEmail(e.target.value)}
                />

                <InputField id="password"
                            type="password"
                            required={true}
                            labelValue="Пароль"
                            value={password}
                            onChange={e=>setPassword(e.target.value)}
                            pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}"
                            title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters"
                />

                <InputField id="name"
                            type="text"
                            required={true}
                            labelValue="Имя"
                            value={firstName}
                            onChange={e=>setFirstName(e.target.value)}

                />

                <InputField id="ssd"
                            type="tel"
                            required={true}
                            labelValue="Телефон"
                            value={phone}
                            onChange={e=>setPhone(e.target.value)}
                            pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}"
                            title="123-456-7890"
                />

                <Dropdown
                    label="В каком мессенджерах вам удобнее общаться"
                    dismissOnClick={false}
                >
                    {
                        messangers.map(m =>
                            <Dropdown.Item>
                                <Button onClick={e => onClick(m)}> {m}</Button>
                            </Dropdown.Item>
                        )
                    }

                </Dropdown>

                <div className="flex items-center gap-2">
                    <Checkbox id="agree" required={true}/>
                    <Label htmlFor="agree">
                        Я согласен с
                        <a
                            href="/forms"
                            className="text-blue-600 hover:underline dark:text-blue-500"
                        >
                            правилами пользования
                        </a>
                    </Label>
                </div>
                <Button type="submit">
                    Создать новый аккаунт
                </Button>
            </form>
        </div>
    );
};

export default observer(RegisterForm);
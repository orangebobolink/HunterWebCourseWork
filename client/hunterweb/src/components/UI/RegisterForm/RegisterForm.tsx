import React, {useContext} from 'react';
import {Button, Checkbox, Label, TextInput} from 'flowbite-react';
import {Context} from '../../../index';
import {observer} from 'mobx-react-lite';

const RegisterForm = () => {
    const {store} = useContext(Context)

    return (
        <div className="container mx-auto w-1/3">
            <form className="flex flex-col gap-4" onSubmit={
                () => {
                   //store.registration()
                }
            }>
                <div>
                    <div className="mb-2 block">
                        <Label
                            htmlFor="email2"
                            value="Электронная почта"

                        />
                    </div>
                    <TextInput
                        id="email2"
                        type="email"
                        placeholder="name@flowbite.com"
                        required={true}
                        shadow={true}
                    />
                </div>
                <div>
                    <div className="mb-2 block">
                        <Label
                            htmlFor="password2"
                            value="Пароль"
                        />
                    </div>
                    <TextInput
                        id="password2"
                        type="password"
                        required={true}
                        shadow={true}
                    />
                </div>
                <div>
                    <div className="mb-2 block">
                        <Label
                            htmlFor="repeat-password"
                            value="Повторите пароль"
                        />
                    </div>
                    <TextInput
                        id="repeat-password"
                        type="password"
                        required={true}
                        shadow={true}
                    />
                </div>
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
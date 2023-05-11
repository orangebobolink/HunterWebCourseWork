import React, {FC, useState} from 'react';
import {Button, Card, TextInput} from 'flowbite-react';
import {IUserDetail} from '../../../models/IUserDetail';

interface Props {
    value:string,
    title:string,
    onClick:(value:any)=>(void),
    type?:string,
    min?:number,
    max?:number
}

const SettingCard:FC<Props> = ({title,value, onClick, type, min, max}) => {
    const [isChange, setIsChange] = useState(false)
    const [newvalue, setNewValue] = useState(value)

    return (
        <Card>
            <h5 className="text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
                {title}
            </h5>
            {
                isChange
                ?
                <form onSubmit={e => onClick(newvalue)}>
                    <TextInput type={type} min={min} max={max} required={true} value={newvalue} onChange={(e: any) => setNewValue(e.target.value)}></TextInput>
                    <Button className="w-1/3 mt-4" type="submit">Сохранить</Button>
                </form>
                :
                <p className="font-normal text-gray-700 dark:text-gray-400">
                    {value}
                </p>
            }

            <Button className="w-1/3 self-center" onClick={()=> {
                if(isChange)
                    setNewValue(value)
                setIsChange(!isChange)
            }}>
                {
                    isChange ? "Отменить изменения"
                    : "Изменить"
                }
            </Button>
        </Card>
    );
};

export default SettingCard;
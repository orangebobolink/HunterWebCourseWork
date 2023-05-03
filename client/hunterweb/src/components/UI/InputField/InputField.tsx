import React, {FC} from 'react';
import {Label} from 'flowbite-react';
import DefaultInput from '../input/DefaultInput';

interface Props {
    onChange?:(e: any) => void,
    value?:string,
    id:string,
    type:string,
    placeholder?:string,
    required:boolean,
    labelValue:string
}

const InputField:FC<Props> = ({
                                onChange,
                                value,
                                id,
                                type,
                                placeholder,
                                  required,
                                labelValue
                              }) => {
    return (
        <div>
            <div className="mb-2 block">
                <Label
                    htmlFor={id}
                    value={labelValue}
                />
            </div>
            <DefaultInput
                onChange={onChange}
                value={value}
                id={id}
                type={type}
                placeholder={placeholder}
                required={required}
            />
        </div>
    );
};

export default InputField;
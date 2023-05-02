import React, {FC} from 'react';
import cl from './DefaultButton.module.css';
import {Link} from 'react-router-dom';

interface Props {
    children?: React.ReactNode;
    onClickParam?: (e: any) => void;
    onClick?: () => void;
}

const DefaultButton: FC<Props> = ({
                               children,
                               onClickParam,
                               onClick
                           }) => {
    return (
        <Link
            to='/'
            className="rounded-md bg-indigo-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
        >
            {children}
        </Link>
    );
};

export default DefaultButton;
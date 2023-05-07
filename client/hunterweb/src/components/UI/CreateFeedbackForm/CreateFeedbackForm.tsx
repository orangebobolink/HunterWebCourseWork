import React, {useContext} from 'react';
import {Context} from '../../../index';
import {observer} from 'mobx-react-lite';
import InputField from '../InputField/InputField';

const CreateFeedbackForm = () => {
    const {store} = useContext(Context)

    return (
        <div className="container mx-auto w-1/3">
            <InputField id="content" type="text" required={true} labelValue="ds"/>
        </div>
    );
};

export default observer(CreateFeedbackForm);
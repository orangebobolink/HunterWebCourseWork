import React, {useContext, useState} from 'react';
import {Context} from '../../../index';
import {observer} from 'mobx-react-lite';
import InputField from '../InputField/InputField';
import {Button, Label, Textarea} from 'flowbite-react';
import {IFeedback} from '../../../models/IFeedback';
import FeedbackService from '../../../services/FeedbackService';
import {useNavigate} from 'react-router-dom';

const CreateFeedbackForm = () => {
    const {store} = useContext(Context)
    const [mark, setMark] = useState(0)
    const [content, setContent] = useState("")
    const navigate = useNavigate()

    return (
        <div className="container mx-auto w-1/3" onSubmit={
            async ()=> {
                const feedback : IFeedback = {
                    userEmail: store.user.email,
                    mark:mark,
                    content: content,
                    dateCreate:new Date()
                }

                await FeedbackService.create(feedback)
            }
        }>
            <form className="flex flex-col gap-9 max-w-7xl"  >
                <InputField id="content"
                            type="number"
                            required={true}
                            labelValue="Оценка"
                            value={mark}
                            onChange={(e: any) => setMark(e.target.value)}
                            min={1}
                            max={5}
                />

                <div id="textarea">
                    <div className="mb-2 block">
                        <Label
                            htmlFor="comment"
                            value="Ваш отзыв"
                        />
                    </div>
                    <Textarea
                        id="comment"
                        placeholder="Leave a comment..."
                        required={true}
                        rows={4}
                        onChange={(e: any) => setContent(e.target.value)}
                        value={content}
                    />
                </div>

                <Button type="submit">Оставить отзыв</Button>
            </form>
        </div>
    );
};

export default observer(CreateFeedbackForm);
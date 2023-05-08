import React, {useContext, useEffect, useState} from 'react';
import {IFeedback} from '../models/IFeedback';
import FeedbackService from '../services/FeedbackService';
import Feedback from '../components/UI/Feedback/Feedback';
import {Spinner} from 'flowbite-react';
import {Context} from '../index';
import CreateFeedbackForm from '../components/UI/CreateFeedbackForm/CreateFeedbackForm';
import {observer} from 'mobx-react-lite';

const FeedbackPage = () => {
    const [feedbacks, setFeedbacks] = useState<IFeedback[]>([])
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const {store} = useContext(Context)

    const fetchData = async () => {
        const response = await FeedbackService.getAll();
        setFeedbacks(response.data)
        setIsLoading(false)
    }

    useEffect(() => {
        setIsLoading(true)
        fetchData()
    }, []);

    return (
        <div id="services"
             className="section relative pt-20 pb-8 md:pt-16 md:pb-0 bg-white">
            <div className="container w-full xl:max-w-6xl mx-auto px-4">

                <header className="text-center mx-auto mb-12 lg:px-20">
                    <h2 className="text-2xl leading-normal mb-2 font-bold text-black">Кто мы?</h2>
                    <p className="text-gray-500 leading-relaxed font-light text-xl mx-auto pb-2">Отзывы наших поколнников</p>
                </header>

                <div className="flex flex-row flex-wrap">
                    <div className="mx-auto mt-10 grid max-w-2xl grid-cols-1 gap-x-8 gap-y-16 border-t border-gray-200 pt-10 sm:mt-16 sm:pt-16 lg:mx-0 lg:max-w-none lg:grid-cols-3"
                         data-wow-duration="1s"
                        >
                        {
                            !isLoading
                            ?
                            feedbacks.map((feedback) => (
                                <Feedback feedback={feedback}/>
                            ))
                            : <Spinner/>
                        }
                    </div>
                </div>

                    {
                        store.user.roles.includes("user")
                        ?
                        <CreateFeedbackForm/>
                        :
                        <div>
                            <p>Чтобы оставить отзыв, вам требуется зарегистрироваться</p>
                        </div>
                    }

            </div>
        </div>
    );
};

export default observer(FeedbackPage);
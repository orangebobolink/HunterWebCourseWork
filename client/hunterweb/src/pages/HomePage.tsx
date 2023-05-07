import React, {useEffect, useState} from 'react';
import Feedback from '../components/UI/Feedback/Feedback';
import {IFeedback} from '../models/IFeedback';
import AnimalService from '../services/AnimalService';
import FeedbackService from '../services/FeedbackService';
import {Spinner} from 'flowbite-react';

const HomePage = () => {
    const [feedbacks, setFeedbacks] = useState<IFeedback[]>([])
    const [isLoading, setIsLoading] = useState<boolean>(false)

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
        <div className="container mx-auto bg-white py-24 sm:py-32">
            <div className="mx-auto max-w-7xl px-6 lg:px-8">
                <div className="mx-auto max-w-2xl lg:mx-0">
                    <h2 className="text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">
                        Сайт турохоты
                    </h2>
                    <p className="mt-2 text-lg leading-8 text-gray-600">
                        Лучшие из лучших
                    </p>
                </div>
                <div className="mx-auto mt-10 grid max-w-2xl grid-cols-1 gap-x-8 gap-y-16 border-t border-gray-200 pt-10 sm:mt-16 sm:pt-16 lg:mx-0 lg:max-w-none lg:grid-cols-3">
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
        </div>
    );
};

export default HomePage;